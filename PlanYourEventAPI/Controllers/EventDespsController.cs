using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanYourEventAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlanYourEventAPI.Controllers
{
    [Route("api/[controller]")]
    public class EventDespsController : Controller
    {
        // connect
        DbModel db;
        private EventDesp eventDesp;

        public EventDespsController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<EventDesp> Get()
        {
            return db.EventDesps.OrderBy(p => p.ED_Name).ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var eventdesp = db.EventDesps.SingleOrDefault(p=>p.EDId == id );
            if (eventdesp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(eventdesp);
            }
        

    }

    // POST api/<controller>
    [HttpPost]
        public ActionResult Post([FromBody]EventDesp eventDesp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.EventDesps.Add(eventDesp);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = eventDesp.EDId }, eventDesp);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]EventDesp eventDesp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(eventDesp).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = eventDesp.EDId }, eventDesp);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = db.EventDesps.SingleOrDefault(p => p.EDId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                db.EventDesps.Remove(eventDesp);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
