using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TPO_Lab1;

using TPO_Lab5.Models;
using TPO_Lab5.Repository;

namespace TPO_Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopContainer _sh;

        public HomeController(ShopContainer sh, ILogger<HomeController> logger)
        {
            _sh = sh;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult Index(int price)
        {
            ViewData["Error"] = _sh.ErrorMessage ?? "";

            

            return View((_sh.GetShop.GetAllProducts, price));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewProduct(string name, int count, int price)
        {

            try
            {
                _sh.GetShop.NewProduct(name, new Product { CountProduct = count, Price = price });
                _sh.ErrorMessage = "";
            }
            catch ( Exception ex)
            {
                _sh.ErrorMessage = ex.Message;
            }
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(string dlName)
        {
            try
            {
                _sh.GetShop.DeleteProduct(dlName);
                _sh.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                _sh.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ChangeProduct(string changeName, int changePrice)
        {
            try
            {
                _sh.GetShop.ChangePrice(changeName, changePrice);
                _sh.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                _sh.ErrorMessage = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ImportProduct(string importName, int importCount)
        {
            try
            {
                _sh.GetShop.Bringing(importName, importCount);
                _sh.ErrorMessage = "";
            }
            catch (Exception ex)
            {
                _sh.ErrorMessage = ex.Message;
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BuyProduct(string buyName, int buyCount)
        {

            try
            {
                int result = _sh.GetShop.Buy(buyName, buyCount);
                _sh.ErrorMessage = "";
                return RedirectToAction("Index", new { price = result });
            }
            catch (Exception ex)
            {
                _sh.ErrorMessage = ex.Message;
                return RedirectToAction("Index");
            }


        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
