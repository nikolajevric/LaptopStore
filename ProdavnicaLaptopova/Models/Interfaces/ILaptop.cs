using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaLaptopova.Models.Interfaces
{
    interface ILaptop
    {
        List<LaptopBO> GetAll();
        void Add(LaptopBO laptop);
        LaptopBO GetById(int LaptopID);
        void Delete(int LaptopID);
        void update(LaptopBO laptopBo);
        void requestNewLaptop(LaptopBO laptopBo);

    }
}
