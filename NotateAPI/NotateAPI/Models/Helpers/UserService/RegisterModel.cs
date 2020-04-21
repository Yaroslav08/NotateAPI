using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.UserService
{
    public class RegisterModel
    {
        public RegisterModel(string Fullname, string Log, string Pass)
        {
            FullName = Fullname;
            Login = Log;
            Password = Pass;
        }
        [Required, MinLength(3), MaxLength(70)]
        public string FullName { get; set; }
        [Required, MinLength(10), MaxLength(100)]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(50)]
        public string Password { get; set; }
    }
}