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
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }

        }

    }
}