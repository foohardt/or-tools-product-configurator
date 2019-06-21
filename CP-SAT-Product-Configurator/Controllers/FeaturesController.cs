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
        private readonly ProductConfigurationService _productService;
        private readonly EngineService _engineService;
        private readonly GearService _gearService;

        public FeaturesController(
                ProductConfigurationService productConfigurationService,
                EngineService engineService,
                GearService gearService
            )
        {
            _productService = productConfigurationService;
            _engineService = engineService;
            _gearService = gearService;
        }

        [HttpGet]
        public ActionResult<List<Engine>> Get([FromQuery]int engine, int category)
        {
            _productService.ConfigureProduct();
            var engines = _engineService.Get();
            var gears = _gearService.Get();

            return engines;
        }

    }
}