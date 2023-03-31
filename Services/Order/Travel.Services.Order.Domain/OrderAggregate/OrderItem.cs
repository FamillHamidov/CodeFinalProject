using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Order.Domain.Core;

namespace Travel.Services.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public OrderItem(string tourId, string tourName, int count, decimal price)
        {
            TourId = tourId;
            TourName = tourName;
            Count = count;
            Price = price;
        }

        public string TourId { get; private set; }
        public string TourName { get; private set; } = null!;
        public int Count { get; private set; }
        public Decimal Price { get; private set; }
        public void UpdateOrderItem(string tourName, int count, decimal price)
        {
            TourName = tourName;
            Count = count;
            Price = price;
        }
    }
}
