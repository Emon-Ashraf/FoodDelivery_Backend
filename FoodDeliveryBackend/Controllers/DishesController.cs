using BLL.Interfaces;
using DAL.Models;
using DTO;
using DTO.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodDeliveryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishesController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDishes([FromQuery] DishFilterModel filter)
        {
            try
            {
                var categories = filter.Categories.Select(c => c.ToString()).ToList();
                var result = await _dishService.GetDishesAsync(categories, filter.Vegetarian, filter.Sorting, filter.Page);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "Error", message = "An error occurred while fetching dishes.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(Guid id)
        {
            try
            {
                var result = await _dishService.GetDishByIdAsync(id);
                return result != null ? Ok(result) : NotFound(new { status = "Error", message = "Dish not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "Error", message = "An error occurred while fetching the dish.", details = ex.Message });
            }
        }
    }
}
