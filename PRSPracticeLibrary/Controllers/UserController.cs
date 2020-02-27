using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using PRSPracticeLibrary.Models;

namespace PRSPracticeLibrary.Controllers {

    class UserController {
        private AppDbContext context = new AppDbContext();
        private static User user;

        //public static BcConnection bcConnection { get; set; }

        //public static List<Users> GetAllUsers() {
        //    var sql = "Select* From User";
        //    var command = new SqlCommand(sql, bcConnection.Connection);
        //    var reader = command.ExecuteReader();
        //    if (!reader.HasRows) {
        //        throw new Exception("No users found");
        //        reader.Close();
        //        return new List<Users>();
        //    }
        //}

        //public static Models.User GetUserByPk(int id) {
        //    var sql = $"Select* From User where Id ={id}";
        //    var command = new SqlCommand(bcConnection.Connection);
        //    var reader = command.ExecuteReader();
        //    if (!reader.HasRows) {
        //        throw new Exception("User Id not found");
             }
        }  
        
        public static 




        //public User(string Username, string Password) { 
        //    if(Username != Username && Password != Password ){
        //        return null;
        // }

        //* Login(u, p) - Authenticates a user by username and password combination.This
        // reads the user table for the username and password passed in and returns
        //the instance if found; otherwise returns null.






        public UserController() { }

        
    }
}
