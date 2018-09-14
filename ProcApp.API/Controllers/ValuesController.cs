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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateValue(int id, ValueForUpdateDto valueForUpdateDto) 
        {
            var valueFromRepo = await _repo.GetValue(id);

            _mapper.Map(valueForUpdateDto, valueFromRepo);

            valueFromRepo.LastUpdated = DateTime.Now;

            if (await _repo.SaveAll())
                return NoContent();
            
            throw new Exception($"Updating value {id} failed on save");
        }

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
