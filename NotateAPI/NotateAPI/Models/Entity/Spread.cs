using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Models.Entity
{
    public class Spread
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadTime { get; set; }
        public Note Note { get; set; }
    }
}