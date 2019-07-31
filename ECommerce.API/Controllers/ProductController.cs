using ECommerce.Domain;
using ECommerce.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _productService.GetAll();
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public ActionResult<Product> Get(string name)
        {
            return _productService.GetByName(name);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Add(product);
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