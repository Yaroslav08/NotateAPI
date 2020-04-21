using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.UserService
{
    public class UserEditModel
    {
        [Required, MinLength(3), MaxLength(70)]
        public string FullName { get; set; }
        [MinLength(1), MaxLength(250)]
        public string About { get; set; }
    }
}