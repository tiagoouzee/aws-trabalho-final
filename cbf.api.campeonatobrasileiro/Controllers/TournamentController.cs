using Microsoft.AspNetCore.Mvc;
using cbf.Infrastructure;
using cbf.domain;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cbf.API.Controllers
{
    [Route("cbf.API/v1.0/Tournament")]
    [Produces("application/json")]
    [ApiController]    
    public class TournamentController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Tournament> Get()
        {
            var controllerTournament = new Tournament();
            List<Tournament>? ListTournament;
                                    
            try
            {
                ListTournament = controllerTournament.GetTournament();          
                return ListTournament;
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
        public Tournament Get(int id)
        {
            var controllerTournament = new Tournament();
            Tournament? ListTournament;

            try
            {
                ListTournament = controllerTournament.GetTournamentPerID(id);

                if (ListTournament == null)
                    throw new Exception("Tournament not found.");

                return ListTournament;
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
        public void Post([FromBody] ParametersTournament tournament)
        {
            var controllerTournament = new Tournament();

            try
            {
                controllerTournament.InsertTournament(tournament);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/start")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void start(int idTournament,int idMatch)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Start Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Start Match";
                pEvent.idTeamGeneratorEvents = 0;
                    
                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Start Match");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/interval")]
        public void interval(int idTournament, int idMatch)
        {
            var controllerEvent = new Event();
            

            try
            {
                
                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Interval Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Interval Match";
                pEvent.idTeamGeneratorEvents = 0;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Interval Match");

            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/add")]
        public void add(int idTournament, int idMatch)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Add Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Add Match";
                pEvent.idTeamGeneratorEvents = 0;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Add Match");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/end")]
        public void end(int idTournament, int idMatch)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "End Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "End Match";
                pEvent.idTeamGeneratorEvents = 0;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "End Match");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/goal/team/{idTeamGeneratorsEvents}")]
        public void goal(int idTournament, int idMatch, int idTeamGeneratorsEvents)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Goal Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Goal Match";
                pEvent.idTeamGeneratorEvents = idTeamGeneratorsEvents;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Goal Match");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/advertence/team/{idTeamGeneratorsEvents}")]
        public void advertence(int idTournament, int idMatch, int idTeamGeneratorsEvents)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Advertence Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Advertence Match";
                pEvent.idTeamGeneratorEvents = idTeamGeneratorsEvents;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Advertence Match");

            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<ValuesController>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("/Tournament/{idTournament}/Match/<idMatch>/event/substitution/team/{idTeamGeneratorsEvents}")]
        public void substitution(int idTournament, int idMatch, int idTeamGeneratorsEvents)
        {
            var controllerEvent = new Event();

            try
            {

                var pEvent = new ParametersEvent();

                pEvent.idMatch = idMatch;
                pEvent.typeEvents = "Substitution Match";
                pEvent.dateEvent = DateTime.Now;
                pEvent.description = "Substitution Match";
                pEvent.idTeamGeneratorEvents = idTeamGeneratorsEvents;

                controllerEvent.InsertEvent(pEvent);

                var pRabbitMQ = new cbf.Infrastructure.MessageQeue.RabbitMQ();
                string jsonString = JsonSerializer.Serialize(pEvent);
                pRabbitMQ.Enviar(jsonString, "Substitution Match");

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
        public void Put(int id, [FromBody] ParametersTournament parameters)
        {
            var controllerTournament = new Tournament();

            try
            {
                controllerTournament.UpdateTournamentPerID(id, parameters );
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

            var controllerTournament = new Tournament();
            
            try
            {
                controllerTournament.DeleteTournamentPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
