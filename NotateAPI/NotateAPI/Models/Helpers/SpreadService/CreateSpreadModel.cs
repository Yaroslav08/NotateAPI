using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Models.Helpers.SpreadService
{
    public class CreateSpreadModel
    {
        public string Title { get; set; }
        public int ToId { get; set; }
        public long NoteId { get; set; }
    }
}