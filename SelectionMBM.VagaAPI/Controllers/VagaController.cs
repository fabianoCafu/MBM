using Microsoft.AspNetCore.Mvc;
using SelectionMBM.VagaAPI.Service.Interface;
using SelectionMBM.VagaAPI.ViewModel;

namespace SelectionMBM.VagaAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VagaController : Controller
    {
        private readonly IVagaService _service;

        public VagaController(
            IVagaService repository)
        {
            _service = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("create")]
        public ActionResult<VagaViewModel> Create([FromBody] VagaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _service.Create(model);

            if (response)
            {
                return Ok(new { Message = "Vaga criada com sucesso." });
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult<VagaViewModel> Update([FromBody] VagaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var response = _service.Update(model);

                if (response)
                {
                    return Ok(new { Message = "Vaga atualizada com sucesso." });
                }

                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<VagaViewModel> Delete(string id)
        {
            var response = _service.Delete(id);

            if (response)
            {
                return Ok(new { Message = "Vaga removida com sucesso." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get/by-id/{id}")]
        public ActionResult<VagaViewModel> FindById(string id)
        {
            var response = _service.FindById(id);

            if (response is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("get/by-title/{tituloVaga}")]
        public ActionResult<List<VagaViewModel>> FindByTitle(string tituloVaga)
        {
            var response = _service.FindByTitle(tituloVaga);

            if (response is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("get/findall/")]
        public ActionResult<List<VagaViewModel>> FindAll()
        {
            var response = _service.FindAll();

            if (response is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("get/by-opportunity/{id}/")]
        public ActionResult<List<CandidatosViewModel>> FindByOpportunity(string id)
        {
            var response = _service.FindByOpportunity(id);

            if (response is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
