using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()//Chamo contralador
        {
            var list = _sellerService.FindAll();//Controlador acessa o Model, paga o dado na lista
            return View(list);//E ntao encaminha esse dados p/ a view.
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]//Informo que é ação de Post e não de GET;
        [ValidateAntiForgeryToken] //Previne de ataques(CSRF)maliciosos usando minha validação.
        public IActionResult Create(Seller seller)//recebe um obj vendedor que veio da requisição (colocando o parâmetro)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));//Redireciona minha requisição p/ a ação Index. (ou somente RedirectToAction("Index"))
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Delete com POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));//Redireciona depois de apagar pra pag/tela inicial do CRUD
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}

