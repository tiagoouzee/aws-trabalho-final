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
    [Route("cbf.API/v1.0/Player")]
    [Produces("application/json")]
    [ApiController]    
    public class PlayerController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Player> Get()
        {
            var controllerPlayer = new Player();
            List<Player>? ListPlayer;
                                    
            try
            {
                ListPlayer = controllerPlayer.GetPlayer();          
                return ListPlayer;
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
        public Player Get(int id)
        {
            var controllerPlayer = new Player();
            Player? ListPlayer;

            try
            {
                ListPlayer = controllerPlayer.GetPlayerPerID(id);

                if (ListPlayer == null)
                    throw new Exception("Player not found.");

                return ListPlayer;
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
        public void Post([FromBody] ParametersPlayer player)
        {

            var controllerPlayer = new Player();

            try
            {
                controllerPlayer.InsertPlayer(player);
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
        public void Put(int id, [FromBody] ParametersPlayer parameters)
        {
            var controllerPlayer = new Player();

            try
            {
                controllerPlayer.UpdatePlayerPerID(id, parameters );
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

            var controllerPlayer = new Player();
            
            try
            {
                controllerPlayer.DeletePlayerPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
