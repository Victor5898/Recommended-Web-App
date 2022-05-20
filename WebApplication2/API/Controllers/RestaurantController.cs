using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recommended.Data;
using System.Threading;
using WebApplication2.API.Controllers;
using WebApplication2.API.Entities.DTOs;
using WebApplication2.Data;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    public class RestaurantController : BaseApiController
    {
        private readonly RestaurantContext _context;

        public RestaurantController(RestaurantContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbRestaurant>>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();

        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DbRestaurant>> GetRestaurant(int id)
        {
            return await _context.Restaurants.FindAsync(id);

        }

        [HttpPost]
        public async Task<ActionResult<DbRestaurant>> Register(RestaurantDTO restaurant)
        {
            var newRestaurant = new DbRestaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Description = restaurant.Description,
                ImagePath =  restaurant.ImagePath
            };

            _context.Restaurants.Add(newRestaurant);

            await _context.SaveChangesAsync();

            return newRestaurant;
        }
    }
}
