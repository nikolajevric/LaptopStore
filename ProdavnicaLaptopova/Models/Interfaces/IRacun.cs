using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaLaptopova.Models.Interfaces
{
    interface IRacun
    {
        void Create();
        RacunBO GetById(int RacunID);
    }
}
