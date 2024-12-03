using FornecePro_Com_Foto.Data;
using FornecePro_Com_Foto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FornecePro_Com_Foto.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CadastroController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CadastroModels> cadastros = _db.Cadastros;
            return View(cadastros);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastroModels cadastro)
        {
            if (ModelState.IsValid)
            {
                _db.Cadastros.Add(cadastro);
                _db.SaveChanges();

                // Usando TempData para enviar uma mensagem de sucesso
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CadastroModels cadastro = _db.Cadastros.FirstOrDefault(x => x.Id == id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost]
        public IActionResult Editar(CadastroModels cadastro)
        {
            if (ModelState.IsValid)
            {
                _db.Cadastros.Update(cadastro);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "Cadastro atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CadastroModels cadastro = _db.Cadastros.FirstOrDefault(x => x.Id == id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost]
        public IActionResult Excluir(CadastroModels cadastro)
        {
            if (cadastro == null)
            {
                return NotFound();
            }

            var cadastroToDelete = _db.Cadastros.FirstOrDefault(x => x.Id == cadastro.Id);

            if (cadastroToDelete != null)
            {
                _db.Cadastros.Remove(cadastroToDelete);
                _db.SaveChanges();

                TempData["SuccessMessage"] = "Cadastro excluído com sucesso!";
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
