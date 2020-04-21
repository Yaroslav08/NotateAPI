using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Models.Entity
{
    public class Note
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public string PrivateKey { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime Create { get; set; }
        public bool IsEdited { get; set; }
        public DateTime? LastEdit { get; set; }
        public User User { get; set; }
        public int CommentCount { get; set; }
        public bool CanCommented { get; set; }
        public List<Comment> Comments { get; set; }
    }
}