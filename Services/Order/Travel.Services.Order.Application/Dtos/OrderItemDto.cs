using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Services.Order.Application.Dtos
{
    public class OrderItemDto
    {
        public string? TourId { get;  set; }
        public string? TourName { get;  set; }
        public int Count { get;  set; }
        public Decimal Price { get;  set; }
    }
}
