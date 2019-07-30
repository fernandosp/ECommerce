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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Order>> Gets([FromRoute] int id)
        {
            return Ok(_orderService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(_orderService.Get());
        }

        [HttpPost("{post}")]
        public ActionResult<string> Post([FromBody] Order order)
        {
            try
            {
                _orderService.SendOrder(order);

                return Ok("success");
            }
            catch (Exception exception)
            {
                return new StatusCodeResult(500);
            }

        }
    }
}