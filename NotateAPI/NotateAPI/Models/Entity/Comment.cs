using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Models.Entity
{
    public class Comment
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Create { get; set; }
        public User User { get; set; }
    }
}