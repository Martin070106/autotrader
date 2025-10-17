using autotrader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace autotrader.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Car> GetAllRecord()
        {
            using (var context = new CarDbContext())
            {
                var cars = context.Cars.ToList();

                if (cars != null)
                {
                    return Ok(cars);
                }
                return BadRequest(new {mesage = "Sikertelen lekérdezés."});
            }
           
        }
        [HttpPost]
        public ActionResult<Car> AddNewRecord(Car car)
        {
            using (var context = new CarDbContext())
            {
                var newCar = new Car
                {
                    Brand = car.Brand,
                    Type = car.Type,
                    Color = car.Color,
                    Year = car.Year
                };
                if(newCar != null)
                {
                    context.Cars.Add(newCar);
                    context.SaveChanges();
                    return StatusCode(201, newCar);
                }
                return BadRequest(new { message = "Sikertelen feltöltés" });
                
            }

        }
    }
}
