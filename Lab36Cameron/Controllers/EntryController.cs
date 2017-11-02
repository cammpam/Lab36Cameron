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
    public class EntryController : ControllerBase
    {
        private readonly SongEntryDbContext _context;

        public EntryController(SongEntryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<SongItem> Get()
        {
            return _context.SongItem;
        }

        //Get action with model binding ID, and constrains
        [HttpGet("{id:int?}")]
        public IActionResult Get(int id)
        {
            //ananomous type = linq expression to grab first id(lambda expression)
            var result = _context.SongItem.FirstOrDefault(h => h.Id == id);
            //Return 200 code, success
            return Ok(result);
        }

        //Post
        [HttpPost]

        public async Task<IActionResult> Post([FromBody]SongItem item)
        {
            //Posting item to Db
            await _context.AddAsync(item);

            //waiting for changes to complete 
            await _context.SaveChangesAsync();

            //return Ok from get action
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        //Put
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]SongItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //find item by id
            var check = _context.SongItem.FirstOrDefault(i => i.Id == id);

            //updates an item in the database by id
            if (check != null)
            {
                check.Title = item.Title;
                _context.Update(check);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }


        //Delete Action
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _context.SongItem.FirstOrDefault(i => i.Id == id);

            //Removes item based off given id
            if(check != null)
            {
                _context.Remove(check);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }


    }


}

