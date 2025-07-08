using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SelectionMBM.Web.Models;
using SelectionMBM.Web.Service.IService;

namespace SelectionMBM.Web.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ILogger<CandidatoController> _logger;
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(
            ILogger<CandidatoController> logger,
            ICandidatoService cadidatoService)
        {
            _candidatoService = cadidatoService ?? throw new ArgumentNullException(nameof(cadidatoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> DeleteCandidato(Guid id)
        {
            var respeonse = await _candidatoService.DeleteCandidatoById(id);

            if (respeonse is not null)
            {
                return RedirectToAction(nameof(IndexCandidato));
            }

            return View();
        }

        public async Task<IActionResult> IndexCandidato(string? nomeCadidato = null)
        {
            var model = new List<CandidatoViewModel>();
            
            if (string.IsNullOrWhiteSpace(nomeCadidato))
            {
                model = await _candidatoService.FindAllCandidatos(); 
            }
            else
            {
                model = await _candidatoService.FindCandidatoByName(nomeCadidato);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateCandidato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidato(CandidatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _candidatoService.CreateCandidato(model);

                if (response is not null)
                {
                    return RedirectToAction(nameof(IndexCandidato));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCandidato(Guid id)
        {
            var response = await _candidatoService.FindCandidatoById(id);

            if (response is not null)
            {
                return View(response);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditCandidato(CandidatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _candidatoService.UpdateCandidato(model);

                if (response is not null)
                {
                    return RedirectToAction(nameof(IndexCandidato));
                } 
            }

            return View(model);
        } 
    }
}
