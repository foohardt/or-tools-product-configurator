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
        private readonly ModelService _modelService;

        public ModelsController(ModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public ActionResult<List<Model>> Get()
        {
            return _modelService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetModel")]
        public ActionResult<Model> Get(string id)
        {
            var model = _modelService.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPost]
        public ActionResult<Model> Create(Model model)
        {
            _modelService.Create(model);

            return CreatedAtRoute("GetModel", new { id = model.Id.ToString() }, model);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Model  modelIn)
        {
            var book = _modelService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _modelService.Update(id, modelIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var model = _modelService.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            _modelService.Remove(model.Id);

            return NoContent();
        }
    }
}