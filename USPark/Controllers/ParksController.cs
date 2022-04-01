using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USPark.Models;

namespace USPark.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase {
    private readonly USParkContext _db;
    public ParksController(USParkContext db) {
      _db = db;
    }

    // GET api/parks?endpoint  (read)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string city, string state, string managedBy, string activities, string amenities, string events, bool ada) {
      var query = _db.Parks.AsQueryable();
      if (city != null) {
        query = query.Where(entry => entry.City == city);
      }
      if (state != 0) {
        query = query.Where(entry => entry.State == state);
      }
      if (managedBy != null) {
        query = query.Where(entry => entry.ManagedBy == managedBy);
      }
      if (activities != null) {
        query = query.Where(entry => entry.Activities == activities);
      }
      if (amenities != null) {
        query = query.Where(entry => entry.Amenities == amenities);
      }
      if (events != null) {
        query = query.Where(entry => entry.Events == events);
      }
      if (ada != null) {
        query = query.Where(entry => entry.ADA == ada);
      }
      return await _db.Parks.ToListAsync();
    }
    
    // GET: api/parks/id  (read)
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id) {
      var park = await _db.Parks.FindAsync(id);
      if (park == null) {
          return NotFound();
      }
      return park;
    }
    
    // POST api/parks  (create)
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park) {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);; // returns Park object; status: "201, Created"
    }

    // PUT: api/parks  (update)
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park) {
      if (id != park.ParkId) {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) {
        if (!ParkExists(id)) {
          return NotFound();
        } else {
          throw;
        }
      }
      return NoContent();
    }

    // DELETE: api/parks  (delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id) {
      var park = await _db.Parks.FindAsync(id);
      if (park == null) {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }
    private bool ParkExists(int id) {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}