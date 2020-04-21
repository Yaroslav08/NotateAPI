using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Models.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string About { get; set; }
        public bool IsVerifyd { get; set; }
        public string Photo { get; set; }
    }
}