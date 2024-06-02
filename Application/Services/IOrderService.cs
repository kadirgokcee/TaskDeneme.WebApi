﻿using Application.Features.Orders.Commands.CreateOrderCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IOrderService
    {
        Task CreateOrder(CreateOrderCommand request);
    }
}
