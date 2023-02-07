using Application.Abstract.Repositories;
using Application.App.Reservation.Response;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Application.App.Reservation.Command
{
    public class CreateReservationCommand : IRequest<ReservationResponse>
    {
        public long? CarId { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime ReservedUntil { get; set; }
    }

    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ReservationResponse>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMemoryCache _memoryCache;

        public CreateReservationCommandHandler(IReservationRepository reservationRepository, IMemoryCache memoryCache)
        {
            _reservationRepository = reservationRepository;
            _memoryCache = memoryCache;
        }

        public async Task<ReservationResponse> Handle(CreateReservationCommand request,
            CancellationToken cancellationToken)
        {
            if (request.ReservedAt < DateTime.Now || request.ReservedUntil < DateTime.Now.AddMinutes(10))
            {
                throw new BadHttpRequestException("Reservation can't be created in past or on very short duration");
            }

            if (request.ReservedAt > request.ReservedAt.AddHours(24))
            {
                throw new BadHttpRequestException("Reservation can't be created in more then in next 24 hours");
            }

            var range = request.ReservedUntil - request.ReservedAt;

            if (range.Minutes > 120)
            {
                throw new BadHttpRequestException("Can't be created reservation more then 120 minutes");
            }

            // TODO: it's bad idea, another way to get data by filtering in query all reservations
            var key = $"{Constants.ReservationPrefix}-{request.ReservedAt.TimeOfDay.Minutes}-{request.ReservedUntil.TimeOfDay.Minutes}-{request.CarId}";

            var isCarReservedOnThisPointOfTime = _memoryCache.TryGetValue<Domain.Models.Reservation>(key, out _);

            if (isCarReservedOnThisPointOfTime)
            {
                throw new BadHttpRequestException("Can't be created reservation - car is already reserved in this time slot");
            }

            var reservation = request.Adapt<Domain.Models.Reservation>();
            reservation.Range = range;

            var result = _reservationRepository.Add(reservation);
            await _reservationRepository.SaveChangesAsync(cancellationToken);

            _memoryCache.Set(key, reservation, range);

            return result.Adapt<ReservationResponse>();
        }
    }
}
