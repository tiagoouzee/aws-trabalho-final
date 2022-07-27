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
    [Route("cbf.API/v1.0/Transfer")]
    [Produces("application/json")]
    [ApiController]    
    public class TransferController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public List<Transfer> Get()
        {
            var controllerTransfer = new Transfer();
            List<Transfer>? ListTransfer;
                                    
            try
            {
                ListTransfer = controllerTransfer.GetTransfer();          
                return ListTransfer;
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
        public Transfer Get(int id)
        {
            var controllerTransfer = new Transfer();
            Transfer? ListTransfer;

            try
            {
                ListTransfer = controllerTransfer.GetTransferPerID(id);

                if (ListTransfer == null)
                    throw new Exception("Transfer not found.");

                return ListTransfer;
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
        public void Post([FromBody] ParametersTransfer transfer)
        {

            var controllerTransfer = new Transfer();

            try
            {
                controllerTransfer.InsertTransfer(transfer);
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
        public void Put(int id, [FromBody] ParametersTransfer parameters)
        {
            var controllerTransfer = new Transfer();

            try
            {
                controllerTransfer.UpdateTransferPerID(id, parameters );
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

            var controllerTransfer = new Transfer();
            
            try
            {
                controllerTransfer.DeleteTransferPerID(id);                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
