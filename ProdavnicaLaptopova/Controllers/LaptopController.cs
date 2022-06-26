using ProdavnicaLaptopova.Models;
using ProdavnicaLaptopova.Models.EFRepository;
using ProdavnicaLaptopova.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProdavnicaLaptopova.Controllers
{
    public class LaptopController : Controller
    {
        ILaptop ilaptop = new LaptopRepository();
        ProdavnicaLaptopovaEntities le = new ProdavnicaLaptopovaEntities();
        // GET: Laptop
/*        public LaptopController()
        {
            ilaptop = new LaptopRepository();
        }*/
        public ActionResult Index()
        {
            List<Laptop> laptopovi = le.Laptop.ToList();
            return View(laptopovi);
        }
        public ActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(LaptopBO laptop)
        {
            ilaptop.Add(laptop);
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Edit(LaptopBO laptopBo)
        {
            if (laptopBo.LaptopID == 0)
            {
                ilaptop.Add(laptopBo);
            } else
            {
                ilaptop.update(laptopBo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int LaptopID)
        {
            ilaptop.Delete(LaptopID);
            return RedirectToAction("Index");
        }
    }
}