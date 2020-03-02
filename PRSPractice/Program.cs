using PRSPracticeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PRSPracticeLibrary.Controllers;
using System.Linq;

namespace PRSPractice {
    class Program {
        static void Main(string[] args) {

            var u = new User();
            u.Id = 0;
            u.Firstname = "George";
            u.Lastname = "Meyer";
            u.IsAdmin = true;
            u.Password = "1234";
            u.Phone = null;
            u.Email = null;
            u.IsReviewer = true;
            u.Username = "gmey";

            var u1 = new UserController();
            u1.Insert(u);
            //Now to update
            
            var founduser = u1.GetByPk(1);

            founduser.Lastname = "Moose";

            u1.Update(1, founduser);

        }

    }
}
 