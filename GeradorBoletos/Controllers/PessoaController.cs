using GeradorBoletos.Models;
using GeradorBoletos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeradorBoletos.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoa _pessoa;

        public PessoaController(IPessoa pessoa)
        {
            _pessoa = pessoa;
        }

        public async Task<IActionResult> Index()
        {
            var pessoas = await _pessoa.FindAll();
            return View(pessoas);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PessoaMd model)
        {
            if (ModelState.IsValid)
            {
                var response = await _pessoa.Create(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Update(int id)
        {
            var model = await _pessoa.FindById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(PessoaMd model)
        {
            if (ModelState.IsValid)
            {
                var response = await _pessoa.Update(model);
                if (response != null) return RedirectToAction(
                     nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _pessoa.FindById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(PessoaMd model)
        {
            var response = await _pessoa.DeleteById(model.Id);
            if (response) return RedirectToAction(
                    nameof(Index));
            return View(model);
        }
    }
}