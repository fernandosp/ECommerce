using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Domain;
using ECommerce.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productTypeService) {
            _productTypeService = productTypeService;
        }

        [HttpGet("type/{all}")]
        public ActionResult<IEnumerable<ProductType>> Get() {
            return _productTypeService.GetAll();
        }

        [HttpGet("type/{name}")]
        public ActionResult<ProductType> GetByName(string name) {
            return _productTypeService.GetByName(name);
        }

        [HttpPost("type/{post}")]
        public ActionResult Post([FromBody]ProductType productType) {
            try {

                if (ModelState.IsValid) {
                    _productTypeService.Add(productType);
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