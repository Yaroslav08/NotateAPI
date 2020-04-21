using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.UserService
{
    public class ChangeUsernameModel
    {
        [Required, MinLength(3), MaxLength(30)]
        public string Username { get; set; }
    }
}