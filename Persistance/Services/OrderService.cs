﻿using Domain.Entities;
using Domain.Repositories.OrderRepositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Application.Features.Orders.Commands.CreateOrderCommand;

namespace Persistance.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly IOrderCommandRepository _commandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderCommandRepository commandRepository, IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateOrder(CreateOrderCommand request)
        {
            Order order = new()
            {
                Id = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                CustomerName = request.CustomerName,
                FirmaId = request.FirmaId,
                OrderDate = DateTime.Now,
                ProductId = request.ProductId,
            };
            await _commandRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
