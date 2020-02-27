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
            //edit checking here
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
            if (id != user.Id) throw new Exception("Id and User.Id must match");//These two minimum checks
            //user.UpdatedTime(know)
            context.Entry(user).State = EntityState.Modified;//Don't add this to the system as new, it will be updated
                                                             //
            
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
            // check the value and new exception
           
            return Delete(user);
        }

        public bool Delete(User user) { //two delete functions
            //error check the value
            context.Users.Remove(user);
            context.SaveChanges();
            return true;
        }

        public UserController() { }

    }
}  
        
        
        //public User(string Username, string Password) { 
        //    if(Username != Username && Password != Password ){
        //        return null;
        // }

        //* Login(u, p) - Authenticates a user by username and password combination.This
        // reads the user table for the username and password passed in and returns
        //the instance if found; otherwise returns null.


