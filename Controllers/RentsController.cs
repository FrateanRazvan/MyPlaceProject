using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPlace.Data;
using MyPlace.Models;
using MyPlace.ViewModels.Rents;

namespace MyPlace.Controllers
{
    [Authorize(AuthenticationSchemes = "Identity.Application, Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RentsController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public RentsController(ApplicationDbContext context, ILogger<RentsController> logger, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult> GetRents()
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = _context.Rents.Where(r => r.ApplicationUser.Id == user.Id).Include(r => r.Rooms).FirstOrDefault();
            var resultViewModel = _mapper.Map<RentsForUserResponse>(result);

            return Ok(resultViewModel);
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(int id, Rent rent)
        {
            if (id != rent.ID)
            {
                return BadRequest();
            }

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent>> RegisterRent(NewRentRequest request)
        {
            var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            List<Room> rentedRooms = new List<Room>();
            request.RentRoomsIds.ForEach(roomId => {
                var roomWithId = _context.Rooms.Find(roomId);

                if(roomWithId != null)
                {
                    rentedRooms.Add(roomWithId);
                }
            });

            if(rentedRooms.Count == 0)
            {
                return BadRequest();
            }

            var rent = new Rent
            {
                ApplicationUser = user,
                Max_participants = request.Max_participants,
                Name = request.Name,
                Rooms = rentedRooms,
                Start_date = request.Start_date.GetValueOrDefault(),
                End_date = request.End_date.GetValueOrDefault()
            };

            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.ID == id);
        }
    }
}
