﻿using System;
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
    public class OrderItensController : ControllerBase
    {

        private readonly IOrderItensService _orderItensService; 

        public OrderItensController(IOrderItensService iOrderItensService)
        {
            _orderItensService = iOrderItensService;
        }


        [HttpPost("orderitens/{post}")]
        public ActionResult Post([FromBody] OrderItens orderItens)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _orderItensService.Add(orderItens);
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