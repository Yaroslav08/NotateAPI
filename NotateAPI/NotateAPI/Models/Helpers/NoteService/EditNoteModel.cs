using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.NoteService
{
    public class EditNoteModel
    {
        [Required]
        public long Id { get; set; }
        [Required, MinLength(5), MaxLength(100)]
        public string Header { get; set; }
        [MinLength(1), MaxLength(5000)]
        public string Text { get; set; }
    }
}