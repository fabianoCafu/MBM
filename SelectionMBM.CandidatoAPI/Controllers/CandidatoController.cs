using Microsoft.AspNetCore.Mvc;
using SelectionMBM.CandidatoAPI.Service.Interface;
using SelectionMBM.CandidatoAPI.ViewModel;

namespace SelectionMBM.CandidatoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoService _service;

        public CandidatoController(
            ICandidatoService repository)
        {
            _service = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost("create")]
        public ActionResult<CandidatoViewModel> Create([FromBody] CandidatoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _service.Create(model);

            if (response)
            {
                return Ok(new { Message = "Candidato criado com sucesso." });
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public ActionResult<CandidatoViewModel> Update([FromBody] CandidatoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = _service.Update(model);

            if (response)
            {
                return Ok(new { Message = "Candidato atualizado com sucesso." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<CandidatoViewModel> Delete(string id)
        {
            var response = _service.Delete(id);

            if (response)
            {
                return Ok(new { Message = "Candidato removido com sucesso." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("get/by-id/{id}")]
        public ActionResult<CandidatoViewModel> FindById(string id)
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

        [HttpGet("get/by-name/{nomeCandidato}")]
        public ActionResult<List<CandidatoViewModel>> FindByName(string nomeCandidato)
        {
            var response = _service.FindByName(nomeCandidato);

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
        public ActionResult<List<CandidatoViewModel>> FindAll()
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
    }
}
