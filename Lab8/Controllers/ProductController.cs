using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab8.Handlers;
using Lab8.Models;

namespace Lab8.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsHandler productsHandler;
        public ProductsController()
        {
            productsHandler = new ProductsHandler();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllProducts()
        {
            var products = productsHandler.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}