using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaLaptopova.Models
{
    public class LaptopBO
    {
        public int LaptopID { get; set; }
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public float Cena { get; set; }
    }
}