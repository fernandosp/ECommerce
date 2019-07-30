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
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _ClientService;
        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> Get()
        {
            return _ClientService.GetAll();
        }

        [HttpGet]
        public ActionResult<Client> GetByCpf(string cpf)
        {
            return _ClientService.GetByCPF(cpf);
        }

        [HttpGet]
        public ActionResult<Client> GetByEmail(string email)
        {
            return _ClientService.GetByEmail(email);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Client Client)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _ClientService.Add(Client);
                    return Ok("success");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }

        }

    }
}