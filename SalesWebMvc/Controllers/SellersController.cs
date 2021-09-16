using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;

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
    }
}
