using BLL.Interfaces;
using DAL.Data;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BasketService : IBasketService
    {
        private readonly ApplicationDbContext _context;

        public BasketService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddDishToBasketAsync(Guid userId, Guid dishId)
        {
            var basketItem = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.UserId == userId && b.DishId == dishId);

            if (basketItem != null)
            {
                basketItem.Amount++;
            }
            else
            {
                _context.BasketItems.Add(new BasketItem
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    DishId = dishId,
                    Amount = 1
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
