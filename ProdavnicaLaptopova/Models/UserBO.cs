﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaLaptopova.Models
{
    public class UserBO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}