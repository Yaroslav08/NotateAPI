using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.NoteService
{
    public class CreateNoteModel
    {
        public CreateNoteModel(string Header, string Text)
        {
            this.Header = Header;
            this.Text = Text;
        }
        [Required, MinLength(5), MaxLength(100)]
        public string Header { get; set; }
        [MinLength(1), MaxLength(5000)]
        public string Text { get; set; }
    }
}