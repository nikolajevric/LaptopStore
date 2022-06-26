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
        [Authorize]
        public ActionResult Index()
        {
            List<Laptop> laptopovi = le.Laptop.ToList();
            return View(laptopovi);
        }

        [Authorize(Roles = "Magacioner")]
        public ActionResult Add()
        {
            return View("Add");
        }

        [Authorize(Roles = "Magacioner")]
        [HttpPost]
        public ActionResult Add(LaptopBO laptop)
        {
            ilaptop.Add(laptop);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Prodavac, Magacioner")]
        public ActionResult Edit()
        {
            return View("Edit");
        }

        [Authorize(Roles = "Prodavac, Magacioner")]
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

        [Authorize(Roles = "Prodavac")]
        public ActionResult Delete(int LaptopID)
        {
            ilaptop.Delete(LaptopID);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Kupac")]
        public ActionResult Racun(int id)
        {
            List<LaptopBO> laptopovi = new List<LaptopBO>();
            laptopovi.Add(ilaptop.GetById(id));
            return View("Racun", laptopovi);
        }
    }
}