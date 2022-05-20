using Microsoft.AspNetCore.Mvc;
using WebApplication2.API.Data;
using WebApplication2.API.Entities;
using WebApplication2.API.Entities.DTOs;

namespace WebApplication2.API.Controllers
{
    public class ReviewController : BaseApiController
    {
        private readonly ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        /*[HttpPost("review")]
        public async Task<ActionResult<ReviewDTO>> Post(ReviewDTO reviewDTO, int userId, int restaurantId)
        {

            if(reviewDTO != null)
            {
                var review = new DbReview()
                {

                    RatingPoints = reviewDTO.RatingPoints,
                    Comment = reviewDTO.Comment,
                };

            }
        }*/
    }
}
