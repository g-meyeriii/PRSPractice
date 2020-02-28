using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using PRSPracticeLibrary.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PRSPracticeLibrary.Controllers {

    public class UserController {

        private AppDbContext context = new AppDbContext();

        public IEnumerable<User> GetAll() {
            return context.Users.ToList();
        }
        public User GetByPk(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.Users.Find(id);
        }
        public User Insert(User user) { //Have to make sure it is not null before we do anything
            
            if (user == null) throw new Exception("User can't be null");
            if (user.Username == null || user.Username.Length > 30) throw new Exception("Username is null or too long");
            if (user.Password == null || user.Password.Length > 30) throw new Exception("Password is null or too long");
            if (user.Firstname == null || user.Firstname.Length > 30) throw new Exception("Firstname is null or too long");
            if (user.Lastname == null || user.Lastname.Length > 30) throw new Exception("Lastname null or too long");
            if (user.Phone == null || user.Phone.Length > 12) throw new Exception("Phone is null or too long");
            if (user.Email == null || user.Email.Length > 255) throw new Exception("Email is null or too long");
            var userDb = context.Users.Find(user.Id);
            context.Users.Add(user);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return user; //Will now return the user id 
        }
        public bool Update(int id, User user) {
            if (user == null) throw new Exception("User can't be null");
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            if (user == null) throw new Exception("User can't be null");
            if (user.Username == null || user.Username.Length > 30) throw new Exception("Username is null or too long");
            if (user.Password == null || user.Password.Length > 30) throw new Exception("Password is null or too long");
            if (user.Firstname == null || user.Firstname.Length > 30) throw new Exception("Firstname is null or too long");
            if (user.Lastname == null || user.Lastname.Length > 30) throw new Exception("Lastname null or too long");
            if (user.Phone == null || user.Phone.Length > 12) throw new Exception("Phone is null or too long");
            if (user.Email == null || user.Email.Length > 255) throw new Exception("Email is null or too long");
            var userDb = context.Users.Find(user.Id);
            context.Users.Add(user);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true; 
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var user = context.Users.Find(id);
            if (id != user.Id) throw new Exception("Id and User.Id must match");
            // check the value and new exception
            
            return Delete(user);
        }

        public bool Delete(User id) { //two delete functions
            if (id == null) throw new Exception("UserId can't be null");
            context.Users.Remove(id);
            context.SaveChanges();
            return true;
        }

        public static IEnumerable<User> Login(string Username, string Password) {
            var login =(x => x.Username == Username && x => x.Password == Password);
            throw new Exception("Login failed, check UserId and Password");
            return login;
        }


        public UserController() { }
    }
}  
