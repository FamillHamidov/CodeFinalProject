using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Services.Order.Application.Commands;
using Travel.Services.Order.Application.Dtos;
using Travel.Services.Order.Domain.OrderAggregate;
using Travel.Services.Order.Infastructure;
using Travel.Shared.Dtos;

namespace Travel.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street,
                request.Address.ZipCode, request.Address.Line);
            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);
            request.OrderItems.ForEach(x =>
            {
                order.AddOrderItems(x.TourId, x.TourName, x.Price, x.Count);
            });
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = order.Id }, 200);
        }
    }
}
