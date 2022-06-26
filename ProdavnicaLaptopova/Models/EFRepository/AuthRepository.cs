using ProdavnicaLaptopova.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdavnicaLaptopova.Models.EFRepository
{
    public class AuthRepository : IAuthRepository
    {
        ProdavnicaLaptopovaEntities le = new ProdavnicaLaptopovaEntities();
        public void AddUser(UserBO user)
        {
            if (IsValid(user)) return;

            User userModel = new User
            {
                Password = user.Password,
                Username = user.Username,
                Email = user.Email
            };
            le.User.Add(userModel);
            le.SaveChanges();
        }

        public List<string> GetRolesForUser(string username)
        {
            User userModel = le.User.FirstOrDefault(t => t.Username == username);
            return userModel?.UserRole.Select(t => t.Role.Naziv).ToList();
        }

        public bool IsValid(UserBO userBo)
        {
            bool isValid =
               le.User.Any(t => t.Username == userBo.Username && t.Password == userBo.Password);
            return isValid;
        }
    }
}