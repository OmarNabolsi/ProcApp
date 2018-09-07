using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcApp.API.Data;
using ProcApp.API.Models;

namespace ProcApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.SingleOrDefaultAsync(v => v.Id == id);
            if (value == null)
                return NotFound($"Value with Id {id} does not exist!");
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue(Value value)
        {
            await _context.Values.AddAsync(value);
            await _context.SaveChangesAsync();
            return Ok(value);
        }

        // PUT api/values/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateValue(int id, Value value)
        // {
        //     var valueExits = await _context.Values.AnyAsync(v => v.Id == id);
        //     if (!valueExits)
        //         return NotFound("Failed to update the value!");
            
        //     _context.Values.Update(value);
        //     await _context.SaveChangesAsync();
        //     return Ok(value);
        // }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            var valueExits = await _context.Values.AnyAsync(v => v.Id == id);
            if (!valueExits)
                return NotFound("Value does not exist!");
            
            var value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
            _context.Values.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Value was deleted successfully!");
        }
    }
}
