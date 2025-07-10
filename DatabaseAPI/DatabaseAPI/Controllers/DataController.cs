using DatabaseAPI.Data;
using DatabaseAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly MainContext _context;

        public DataController(MainContext context)
        {
            _context = context;
        }

        [Route("activities")]
        [HttpGet]
        public List<Activity> Get(CancellationToken cancellationToken)
        {
            // Simulate a delay to mimic database access
            var activities = _context.Activities.ToList();
            return activities;
        }
    }
}
