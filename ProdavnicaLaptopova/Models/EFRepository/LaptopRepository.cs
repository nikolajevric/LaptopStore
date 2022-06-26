using ProdavnicaLaptopova.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaLaptopova.Models.EFRepository
{
    public class LaptopRepository : ILaptop
    {
        public ProdavnicaLaptopovaEntities le = new ProdavnicaLaptopovaEntities();
        public void Add(LaptopBO laptop)
        {
            Laptop dbLaptop = new Laptop();
            dbLaptop.Model = laptop.Model;
            dbLaptop.Proizvodjac = laptop.Proizvodjac;
            dbLaptop.Cena = laptop.Cena;
            dbLaptop.LaptopID = laptop.LaptopID;

            le.Laptop.Add(dbLaptop);
            le.SaveChanges();
        }


        public void Delete(int LaptopID)
        {
            Laptop laptop = le.Laptop.Single(t => t.LaptopID == LaptopID);
            le.Laptop.Remove(laptop);
            le.SaveChanges();
        }

        public List<LaptopBO> GetAll()
        {
            List<LaptopBO> laptop = new List<LaptopBO>();
            foreach (Laptop l in le.Laptop)
            {
                LaptopBO laptopBO = new LaptopBO()
                {
                    Cena = (float)l.Cena,
                    LaptopID = l.LaptopID,
                    Model = l.Model,
                    Proizvodjac = l.Proizvodjac
                };
                laptop.Add(laptopBO);
            }
            return laptop;
        }

        public LaptopBO GetById(int LaptopID)
        {
            Laptop dbLaptop = le.Laptop.Where(t => t.LaptopID == LaptopID).FirstOrDefault();
            LaptopBO laptopBO = new LaptopBO();
            laptopBO.Cena = (float)dbLaptop.Cena;
            laptopBO.LaptopID = dbLaptop.LaptopID;
            laptopBO.Model = dbLaptop.Model;
            laptopBO.Proizvodjac = dbLaptop.Proizvodjac;

            return laptopBO;
        }

        public void kreirajRacun(int laptopId)
        {
            Laptop laptop = le.Laptop.FirstOrDefault(l => l.LaptopID == laptopId);

        }

        public void update(LaptopBO laptopBo)
        {
            Laptop laptop = le.Laptop.FirstOrDefault(t => t.LaptopID == laptopBo.LaptopID);
            laptop.Cena = laptopBo.Cena;
            laptop.LaptopID = laptopBo.LaptopID;
            laptop.Model = laptopBo.Model;
            laptop.Proizvodjac = laptopBo.Proizvodjac;
            try
            {
                le.SaveChanges();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}