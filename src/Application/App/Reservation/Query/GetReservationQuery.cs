using Application.Abstract.Repositories;
using Application.App.Reservation.Response;
using Mapster;
using MediatR;

namespace Application.App.Reservation.Query
{
    public class GetReservationQuery : IRequest<IList<ReservationResponse>>
    {
    }

    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, IList<ReservationResponse>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetReservationQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IList<ReservationResponse>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.ListAsync(cancellationToken);
            return reservations.Adapt<IList<ReservationResponse>>();
        }
    }
}
