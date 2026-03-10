using BowlingLeagueAPI.Data;
using BowlingLeagueAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BowlersController : ControllerBase
    {
        private readonly BowlingContext _context;

        // Inject the database context via dependency injection
        public BowlersController(BowlingContext context)
        {
            _context = context;
        }

        // GET: api/bowlers
        // Returns bowlers who are on the Marlins or Sharks teams only
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BowlerDto>>> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team!.TeamName == "Marlins" || b.Team!.TeamName == "Sharks")
                .Select(b => new BowlerDto
                {
                    BowlerFirstName  = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerLastName   = b.BowlerLastName,
                    TeamName         = b.Team!.TeamName,
                    BowlerAddress    = b.BowlerAddress,
                    BowlerCity       = b.BowlerCity,
                    BowlerState      = b.BowlerState,
                    BowlerZip        = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber
                })
                .OrderBy(b => b.TeamName)
                .ThenBy(b => b.BowlerLastName)
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}
