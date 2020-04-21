using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.UserService
{
    public class ConfirmModel
    {
        [Required, MinLength(10), MaxLength(100)]
        public string Login { get; set; }
        [Required, MinLength(4), MaxLength(7)]
        public string Code { get; set; }
    }
}