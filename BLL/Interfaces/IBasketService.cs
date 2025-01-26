using DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBasketService
    {
        Task AddDishToBasketAsync(Guid userId, Guid dishId);
    }
}
