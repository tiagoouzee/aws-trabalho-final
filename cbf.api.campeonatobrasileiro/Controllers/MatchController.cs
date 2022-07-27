using Microsoft.AspNetCore.Mvc;
using cbf.Infrastructure;
using cbf.domain;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cbf.API.Controllers
{
    [Route("cbf.API/v1.0/Match")]
    [Produces("application/json")]    
    [ApiController]    
    public class MatchController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Match> Get()
        {
            var controllerMatch = new Match();
            List<Match>? ListMatch;
                                    
            try
            {
                ListMatch = controllerMatch.GetMatch();          
                return ListMatch;
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
        public Match Get(int id)
        {
            var controllerMatch = new Match();
            Match? ListMatch;

            try
            {
                ListMatch = controllerMatch.GetMatchPerId(id);

                if (ListMatch == null)
                    throw new Exception("Match not found.");

                return ListMatch;
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
        public void Post([FromBody] ParametersMatch match)
        {

            var controllerMatch = new Match();

            try
            {
                controllerMatch.InsertMatch(match);
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
        public void Put(int id, [FromBody] ParametersMatch parameters)
        {
            var controllerMatch = new Match();

            try
            {
                controllerMatch.UpdateMatchPerID(id, parameters );
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

            var controllerMatch = new Match();
            
            try
            {
                controllerMatch.DeleteMatchPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
