using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Entities;
using MovieApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        //to fetch data from database and used this in our endpoints
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get(int pageIndex = 0, int pageSize = 10)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                var movieCount = _context.Movie.Count();
                var movieList = _context.Movie.Include(x => x.Actors).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                response.Status = true;
                response.Message = "Success";
                response.Data = new { Movies = movieList, Count = movieCount };

                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something Went Wrong";

                return BadRequest(response);

            }

        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var movie = _context.Movie.Include(x => x.Actors).Where(x => x.Id == id).FirstOrDefault();
                //Condition to check where movie exist or not for particular id
                if (movie == null)
                {
                    response.Status = false;
                    response.Message = "Record Not EXists.";

                    return BadRequest(response);
                }
                response.Status = true;
                response.Message = "Success";
                response.Data = movie;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Something Went Wrong While Fetching by Id";

                return BadRequest(response);
                
            }
        }
        [HttpPost]
        public IActionResult Post(CreateMovieViewModel model)//we need to pass parameter according to data we want from the user input
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                if(ModelState.IsValid) //this will check the valid data from user input
                {
                    var actors = _context.Person.Where()
                }
            }
            catch(Exception ex) 
            { 
            }
        }
    }
}
