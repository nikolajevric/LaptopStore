using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdavnicaLaptopova.Models.Interfaces
{
    interface IAuthRepository
    {
        bool IsValid(UserBO userBo);
        void AddUser(UserBO user);
        List<string> GetRolesForUser(string username);
    }
}
