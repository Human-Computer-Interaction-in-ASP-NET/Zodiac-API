using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Lab5.Controllers
{
    [Route("api/zodiac")]
    [ApiController]
    [EnableCors("HealthPolicy")]
    public class ZodiacController : ControllerBase
    {
        [HttpGet("{year}")]
        public IActionResult GetZodiacAnimal(int year)
        {
            if (year < 1900 || year > 2024){
                return Ok(new ZodiacObject("In between 1900 and 2024 please", ""));
            }
            string[] zodiacAnimals = { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat" };
            int index = (year - 1900) % 12;
            if (index < 0)
            {
                index += 12;
            }
            string zodiacAnimal = zodiacAnimals[index];

            // Construct the image URL based on the zodiac animal
            string imageUrl = $"/Users/sahilrai/Developer/BCIT/dotnet/lab5/wwwroot/images/{zodiacAnimal.ToLower()}.png";

            // Check if the image file exists
            string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string imagePath = Path.Combine(wwwrootPath, "images", $"{zodiacAnimal.ToLower()}.png");
            if (!System.IO.File.Exists(imageUrl))
            {
                return NotFound(); // Return a 404 if the image does not exist
            }

            var zodiacObject = new ZodiacObject(zodiacAnimal, imageUrl);
            return Ok(zodiacObject);
        }
    }
}
