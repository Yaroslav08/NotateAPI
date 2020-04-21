using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.UserService
{
    public class LoginModel
    {
        [Required, MinLength(10), MaxLength(100)]
        public string Login { get; set; }
        [Required, MinLength(8), MaxLength(50)]
        public string Password { get; set; }
    }
}