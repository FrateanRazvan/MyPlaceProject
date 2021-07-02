﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPlace.Data;
using MyPlace.Models;
using MyPlace.Services;
using MyPlace.ViewModels;

namespace MyPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RoomsController> _logger;
        private readonly IMapper _mapper;
        private readonly RoomService _roomService;

        public RoomsController(ApplicationDbContext context, ILogger<RoomsController> logger, IMapper mapper, RoomService roomService)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _roomService = roomService;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();

            
        }

        [HttpGet]
        [Route("filter/maxSize={maxSize}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoomsByMaxSize(int maxSize)
        {
            return await _context.Rooms.Where(r => r.RoomSize <= maxSize).ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomViewModel>> GetRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            var roomViewModel = _mapper.Map<RoomViewModel>(room);

            return roomViewModel;
        }

        //GET: api/Rooms/1/Comments
        [HttpGet("{id}/Comments")]
        public ActionResult<IEnumerable<RoomWithCommentsViewModel>> GetCommentsForRoom(int id)
        {
            
            var query = _context.Rooms.Where(room => room.Id == id).Include(room => room.Comments).Select(room => _mapper.Map<RoomWithCommentsViewModel>(room));
            return query.ToList();
        }

        //POST: api/Rooms/1/Comments
        [HttpPost("{id}/Comments")]
        public IActionResult PostCommentForRoom(int id, Comment comment)
        {

            var room = _context.Rooms.Where(r => r.Id == id).Include(r => r.Comments).FirstOrDefault();

            if(room == null)
            {
                return NotFound();
            }

            room.Comments.Add(comment);
            _context.Entry(room).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomViewModel>> PostRoom(RoomViewModel roomRequest)
        {
            Room room = _mapper.Map<Room>(roomRequest);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
