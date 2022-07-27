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
    [Route("cbf.API/v1.0/Participant")]
    [Produces("application/json")]
    [ApiController]    
    public class ParticipantController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Participant> Get()
        {
            var controllerParticipant = new Participant();
            List<Participant>? ListParticipant;
                                    
            try
            {
                ListParticipant = controllerParticipant.GetParticipant();          
                return ListParticipant;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{idTournament}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Participant> Get(int idTournament)
        {
            var controllerParticipant = new Participant();
            List<Participant>? ListParticipant;

            try
            {
                ListParticipant = controllerParticipant.GetParticipantPerIdTournament(idTournament);

                if (ListParticipant == null)
                    throw new Exception("Participant not found.");

                return ListParticipant;
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
        public void Post([FromBody] ParametersParticipant participant)
        {

            var controllerParticipant = new Participant();

            try
            {
                controllerParticipant.InsertParticipant(participant);
            }
            catch (Exception)
            {
                throw;
            }
        }

       // DELETE api/<ValuesController>/5
        [HttpDelete("")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Delete([FromBody] ParametersParticipant participant)
        {

            var controllerParticipant = new Participant();
            
            try
            {
                controllerParticipant.DeleteParticipantPerID(participant.idTournament, participant.idTeam);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
