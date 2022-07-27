using Microsoft.AspNetCore.Mvc;
using cbf.Infrastructure;
using cbf.domain;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cbf.API.Controllers
{
    [Route("cbf.API/v1.0/Event")]
    [Produces("application/json")]
    [ApiController]    
    public class EventController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Event> Get()
        {
            var controllerEvent = new Event();
            List<Event>? ListEvent;
                                    
            try
            {
                ListEvent = controllerEvent.GetEvent();          
                return ListEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public Event Get(int id)
        {
            var controllerEvent = new Event();
            Event? ListEvent;

            try
            {
                ListEvent = controllerEvent.GetEventPerID(id);

                if (ListEvent == null)
                    throw new Exception("Event not found.");

                return ListEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Post([FromBody] ParametersEvent pEvent)
        {

            var controllerEvent = new Event();

            try
            {
                controllerEvent.InsertEvent(pEvent);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Put(int id, [FromBody] ParametersEvent parameters)
        {
            var controllerEvent = new Event();

            try
            {
                controllerEvent.UpdateEventPerID(id, parameters );
            }
            catch (Exception)
            {
                throw;
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Delete(int id)
        {

            var controllerEvent = new Event();
            
            try
            {
                controllerEvent.DeleteEventPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
