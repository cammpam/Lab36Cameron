using Lab36Cameron.Data;
using Lab36Cameron.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab36Cameron.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly SongEntryDbContext _context;

        public FeaturesController(SongEntryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contributors> Get()
        {
            return _context.Contributors;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var conList = _context.Contributors.FirstOrDefault(m => m.Id == id);

            Contributors feat = new Contributors();
            feat.PlayList = _context.SongItem.Where(s => s.FeatId == id).ToList();
            feat.Title = conList.Title;

            return Ok(feat);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contributors list)
        {
            await _context.Contributors.AddAsync(list);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = list.Id }, list);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult>Put(int id, [FromBody] Contributors list)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var check = _context.Contributors.FirstOrDefault(c => c.Id == id);

            if (check != null)
            {
                check.Title = list.Title;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return Ok();     
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.Contributors.FirstOrDefault(d => d.Id == id);

            if (result != null)
            {
                _context.Contributors.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }




    }
}
