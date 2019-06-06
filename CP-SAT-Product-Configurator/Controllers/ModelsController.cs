using System.Collections.Generic;
using CP_SAT_Product_Configurator.Models;
using CP_SAT_Product_Configurator.Services;
using Microsoft.AspNetCore.Mvc;

namespace CP_SAT_Product_Configurator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly VehicleModelService _vehiclemodelService;

        public ModelsController(VehicleModelService modelService)
        {
            _vehiclemodelService = modelService;
        }

        [HttpGet]
        public ActionResult<List<VehicleModel>> Get()
        {
            return _vehiclemodelService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetModel")]
        public ActionResult<VehicleModel> Get(string id)
        {
            var book = _vehiclemodelService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public ActionResult<VehicleModel> Create(VehicleModel model)
        {
            _vehiclemodelService.Create(model);

            return CreatedAtRoute("GetBook", new { id = model.Id.ToString() }, model);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, VehicleModel  modelIn)
        {
            var book = _vehiclemodelService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _vehiclemodelService.Update(id, modelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var model = _vehiclemodelService.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            _vehiclemodelService.Remove(model.Id);

            return NoContent();
        }
    }
}