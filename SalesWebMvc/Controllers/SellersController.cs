using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()//Chamo contralador
        {
            var list = _sellerService.FindAll();//Controlador acessa o Model, paga o dado na lista
            return View(list);//E ntao encaminha esse dados p/ a view.
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]//Informo que é ação de Post e não de GET;
        [ValidateAntiForgeryToken] //Previne de ataques(CSRF)maliciosos usando minha validação.
        public IActionResult Create(Seller seller)//recebe um obj vendedor que veio da requisição (colocando o parâmetro)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));//Redireciona minha requisição p/ a ação Index. (ou somente RedirectToAction("Index"))
        }
    }
}
