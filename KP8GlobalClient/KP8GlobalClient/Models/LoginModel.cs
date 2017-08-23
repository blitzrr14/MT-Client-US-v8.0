using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace KP8GlobalClient.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        public String Password { get; set; }
        public String FName { get; set; }
        public String Branch { get; set; }
        public String StationNo { get; set; }
        public String Server { get; set; }
        public String Role { get; set; }
        public String ErrorMessage { get; set; }
        public String CommentArea { get; set; }        
    }

    public class UserAdminLogin
    {
        public LoginModel getUserLogin()
        {
            return new LoginModel() { Username = "admin",
                                      Password = "admin",
                                      FName = "Administrator",
                                      Branch = "ML CHILLING MIST",
                                      StationNo = "1",
                                      Server = "Network",
                                      Role = "KP-Admin"
                                    };
        }
    }
}