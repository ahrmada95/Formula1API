using formula1.Data;
using formula1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formula1API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Formula1DriverController : ControllerBase
    {

        private readonly Formula1Context _context;

        private readonly ILogger<Formula1DriverController> _logger;

        public Formula1DriverController(ILogger<Formula1DriverController> logger, Formula1Context context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet] // Get All Drivers
        public async Task<ActionResult<Response<IEnumerable<Driver?>>>> GetAllDrivers()
        {
            var drivers = await _context.Drivers.ToListAsync();

            return new Response<IEnumerable<Driver?>>(200, "Success", drivers); // Return all Drivers
        }

        [HttpGet("{id}")] // Get Specified Driver
        public async Task<ActionResult<Response<Driver?>>> GetAllDrivers(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);

            if (driver == null) new Response<Driver?>(404, "File Not Found"); // If specified Driver was not found

            return new Response<Driver?>(200, "Success", driver); // Return specified Driver
        }

        [HttpPost] // Create New Driver
        public async Task<ActionResult<Response<Driver?>>> PostDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return new Response<Driver?>(201, "Object created!"); // New Driver successfully created
        }

        [HttpPut("{id}")] // Update Existing Driver
        public async Task<ActionResult<Response<Driver?>>> PutDriver(int id, Driver driver)
        {
            if (id != driver.Id) return new Response<Driver?>(400, "Bad Request"); // If specified id and object id don't match, don't Car

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Attempt to update specified Driver
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id)) new Response<Driver?>(404, "File Not Found"); // If matching Driver was not found
                else throw;
            }

            return new Response<Driver?>(204, "No Content"); // Specified Driver was succesfully updated
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.Id == id);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class Formula1CarController : ControllerBase
    {

        private readonly Formula1Context _context;

        private readonly ILogger<Formula1CarController> _logger;

        public Formula1CarController(ILogger<Formula1CarController> logger, Formula1Context context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet] // Get All Cars
        public async Task<ActionResult<Response<IEnumerable<Car?>>>> GetAllCars()
        {
            var cars = await _context.Cars.ToListAsync();

            return new Response<IEnumerable<Car?>>(200, "Success", cars); // Return all Cars
        }

        [HttpGet("{id}")] // Get Specified Car
        public async Task<ActionResult<Response<Car?>>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            
            if(car == null) return new Response<Car?>(404, "File Not Found"); // Specified Car was not found

            return new Response<Car?>(200, "Success", car); // Return specified Car
        }

        [HttpPost] // Create New Car
        public async Task<ActionResult<Response<Car?>>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return new Response<Car?>(201, "Object Created");
        }

        [HttpPut("{id}")] // Update Existing Car
        public async Task<ActionResult<Response<Car?>>> PutCar(int id, Car car)
        {
            if (id != car.Id) return new Response<Car?>(400, "Bad Request"); // If specified id and object id don't match, don't Car

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // Attempt to update specified Car
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id)) return new Response<Car?>(404, "File Not Found"); // If matching Car was not found
                else throw;
            }

            return new Response<Car?>(204, "No Content"); // Specified Car was succesfully updated
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}