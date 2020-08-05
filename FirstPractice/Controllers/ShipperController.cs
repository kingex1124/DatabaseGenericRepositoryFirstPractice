using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstPractice.Models;

namespace FirstPractice.Controllers
{
    public class ShipperController : Controller
    {
        Repository<Shippers> shipperRespository = new Repository<Shippers>(new NorthwindEntities());
        // GET: Shipper
        public ActionResult Index()
        {
            return View(shipperRespository.GetAll());
        }
    }
}