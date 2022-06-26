using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProdavnicaLaptopova.Models;

namespace ProdavnicaLaptopova.Models
{
    public class LaptopBO
    {
        public int LaptopID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Morate uneti proizvodjaca")]
        public string Proizvodjac { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Morate uneti model")]
        public string Model { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Morate uneti cenu")]
        public float Cena { get; set; }
    }
}