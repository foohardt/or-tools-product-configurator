using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CP_SAT_Product_Configurator.Services;

namespace CP_SAT_Product_Configurator.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ProductConfigurationService service;

        public FeaturesController(ProductConfigurationService productConfigurationService)
        {
            service = productConfigurationService;
        }

        [HttpGet]
        public ActionResult<String> Get([FromQuery]int engine, int category)
        {
            service.ConfigureProduct();
            return null;
        }

    }
}