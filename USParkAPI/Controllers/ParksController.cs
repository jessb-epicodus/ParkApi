using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using USParkAPI.Models;

namespace USParkAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase {
    private readonly USParkAPIContext _db;
    public ParksController(USParkAPIContext db) {
      _db = db;
    }

    // GET api/parks?endpoint  (read)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string city, string state, string managedBy, string activities, string amenities, bool ada) {
      var query = _db.Parks.AsQueryable();
      if (name != null) {
        query = query.Where(entry => entry.Name == name);
      }
      if (city != null) {
        query = query.Where(entry => entry.City == city);
      }
      if (state != null) {
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
      if (ada == true) {
        query = query.Where(entry => entry.ADA == ada);
      }
      return await query.ToListAsync();
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

    // PUT: api/parks/${id}  (update)
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
    private bool ParkExists(int id){
      return _db.Parks.Any(e => e.ParkId == id);
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
  }
}