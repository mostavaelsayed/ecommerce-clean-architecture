﻿using ECommerce.Entities;

namespace ECommerce.Application.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
