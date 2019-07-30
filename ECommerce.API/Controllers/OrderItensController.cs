using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.API.ViewModels;
using ECommerce.Domain;
using ECommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItensController : ControllerBase
    {

        private readonly IOrderItensService _orderItensService; 

        public OrderItensController(IOrderItensService iOrderItensService)
        {
            _orderItensService = iOrderItensService;
        }


        [HttpPost("orderitens/{post}")]
        public ActionResult Post([FromBody] PostOrderItensRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OrderItens orderItens = new OrderItens(request.IdProduct, request.Quantity);
                    _orderItensService.Add(orderItens, request.IdOrder);
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