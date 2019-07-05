using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CP_SAT_Product_Configurator.Models;
using CP_SAT_Product_Configurator.Services;

namespace CP_SAT_Product_Configurator.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ProductConfigurator _productConfigurator;

        public FeaturesController(ProductConfigurator productConfigurator)
        {
            _productConfigurator = productConfigurator;
        }

        [HttpGet]
        public ActionResult<Product> Get([FromQuery]EngineType engine, Category category)
        {
            return _productConfigurator.ConfigureProduct(engine, category);
        }

    }
}