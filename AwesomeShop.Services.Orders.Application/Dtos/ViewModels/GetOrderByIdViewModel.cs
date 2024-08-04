using AwesomeShop.Services.Orders.Core.Entities;

namespace AwesomeShop.Services.Orders.Application.Dtos.ViewModels
{
    public class GetOrderByIdViewModel
    {
        public GetOrderByIdViewModel(Guid id, decimal totalPrice, DateTime createdAt, string status)
        {
            Id = id;
            TotalPrice = totalPrice;
            CreatedAt = createdAt;
            Status = status;
        }

        public Guid Id { get; private set; }
        public decimal TotalPrice { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Status { get; private set; }

        public static GetOrderByIdViewModel FromEntity(Order order) =>
            new GetOrderByIdViewModel(order.Id, order.TotalPrice, order.CreatedAt, order.Status.ToString());

    }

}
