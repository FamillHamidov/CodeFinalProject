using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Order.Domain.Core;

namespace Travel.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public string BuyerId { get; private set; }
        public Address Address { get; private set; }
        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems=>_orderItems;
        public Order( string buyerId, Address address)
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }
        public void AddOrderItems(string tourId, string tourName, decimal price, int count)
        {
            var existTour = _orderItems.Any(x => x.TourId == tourId);
            if (!existTour)
            {
                var newOrderItem = new OrderItem(tourId, tourName, count, price);
                _orderItems.Add(newOrderItem);
            }
        }
        public decimal TotalPrice() => _orderItems.Sum(x => x.Price * x.Count);
        
    }
}
