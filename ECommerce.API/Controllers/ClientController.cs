using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;
using ECommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {

        private readonly IClientService _ClientService;
        public ClientController(IClientService ClientService) {
            _ClientService = ClientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get() {
            return _ClientService.GetAll();
        }

        [HttpGet("{cpf}")]
        public ActionResult<Client> GetByCpf([FromRoute] string cpf) {
            return _ClientService.GetByCPF(cpf);
        }

        [Route("[action]/{email}")]
        [HttpGet]
        public ActionResult<Client> GetByEmail([FromRoute] string email) {
            return _ClientService.GetByEmail(email);
        }

        [HttpPost("client/{post}")]
        public ActionResult post([FromBody]Client client) {
            try {

                if (ModelState.IsValid) {
                    _ClientService.Add(client);
                    return Ok("success");
                }
                else {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception) {
                return new StatusCodeResult(500);
            }

        }

    }
}