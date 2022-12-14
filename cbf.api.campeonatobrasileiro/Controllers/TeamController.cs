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
    [Route("cbf.API/v1.0/Team")]
    [Produces("application/json")]
    [ApiController]    
    public class TeamController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Team> Get()
        {
            var controllerTeam = new Team();
            List<Team>? ListTeam;
                                    
            try
            {
                ListTeam = controllerTeam.GetTeam();          
                return ListTeam;
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
        public Team Get(int id)
        {
            var controllerTeam = new Team();
            Team? ListTeam;

            try
            {
                ListTeam = controllerTeam.GetTeamPerID(id);

                if (ListTeam == null)
                    throw new Exception("Team not found.");

                return ListTeam;
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
        public void Post([FromBody] ParametersTeam team)
        {

            var controllerTeam = new Team();

            try
            {
                controllerTeam.InsertTeam(team);
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
        public void Put(int id, [FromBody] ParametersTeam parameters)
        {
            var controllerTeam = new Team();

            try
            {
                controllerTeam.UpdateTeamPerID(id, parameters );
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

            var controllerTeam = new Team();
            
            try
            {
                controllerTeam.DeleteTeamPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
