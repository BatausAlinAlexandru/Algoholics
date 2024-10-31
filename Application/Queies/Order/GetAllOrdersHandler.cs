using Application.DTO;
using Domain.Aggregates.OrderAggregate.Repositories;
using MediatR;

namespace Application.Queies.Order
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDetailDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<UserAccountDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {

            var orders = await _orderRepository.GetOrdersAsync();
            return orders.Select(ua => new OrderDetailDTO
            {
                Id = ua.Id,
                Email = ua.UserAccountCredentials.Email,
                Password = ua.UserAccountCredentials.Password,
                UserAccountRole = ua.UserAccountCredentials.UserAccountRole,
            }).ToList();

        }
    }
}
