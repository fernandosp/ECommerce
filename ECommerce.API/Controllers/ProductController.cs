using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;
using ECommerce.Service;
using ECommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}