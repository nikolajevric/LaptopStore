using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaLaptopova.Models
{
    public class RacunBO
    {
        public int RacunID { get; set; }
        public float Iznos { get; set; }
        public int Storniran { get; set; }
        public int LaptopID { get; set; }
    }
}