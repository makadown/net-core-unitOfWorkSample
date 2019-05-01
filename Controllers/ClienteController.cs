using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using unitOfWorkSample.Core;
using unitOfWorkSample.Core.Models;

namespace unitOfWorkSample.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {
        private readonly IUnitOfWork _uow;

        public ClienteController (IUnitOfWork unitOfWork) {
            _uow = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll () {
            return Ok(_uow.Repository<Clientes>().GetAll());
            // return Ok(_uow.Repository.ClienteRepository.GetAll());
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public ActionResult<string> Get (int id) {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}