using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using PRSPracticeLibrary.Controllers;
using System.Linq;


namespace PRSPracticeLibrary.Models {
    public class User {
        

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Request> Requests { get; set; }
        public virtual List<UserController> UserController { get; set; }

        

        public User() { }

        

           
        }
    }

}
