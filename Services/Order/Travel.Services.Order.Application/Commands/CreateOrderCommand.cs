using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Order.Application.Dtos;
using Travel.Shared.Dtos;

namespace Travel.Services.Order.Application.Commands
{
    public class CreateOrderCommand:IRequest<Response<CreatedOrderDto>>
    {
        public string? BuyerId { get; set; }
        public List<OrderItemDto>? OrderItems{ get; set; }
        public AddressDto? Address{ get; set; }
    }
}
