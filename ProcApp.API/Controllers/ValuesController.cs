using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcApp.API.Data;
using ProcApp.API.Dtos;
using ProcApp.API.Models;

namespace ProcApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository _repo;
        private readonly IMapper _mapper;
        public ValuesController(IValuesRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _repo.GetValues();

            var valuesToReturn = _mapper.Map<IEnumerable<ValueForListDto>>(values);

            return Ok(valuesToReturn);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _repo.GetValue(id);

            var valueToReturn = _mapper.Map<ValueForDetailedDto>(value);

            return Ok(valueToReturn);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddValue(Value value)
        {
            _repo.Add(value);
            var result = await _repo.SaveAll();
            return Ok(result);
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
        [HttpDelete]
        public async Task<IActionResult> DeleteValue(Value value)
        {
            _repo.Delete(value);
            var result = await _repo.SaveAll();

            return Ok(result);
        }
    }
}
