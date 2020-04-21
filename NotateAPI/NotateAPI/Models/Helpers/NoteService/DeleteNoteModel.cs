using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace NotateAPI.Models.Helpers.NoteService
{
    public class DeleteNoteModel
    {
        [Required]
        public long NoteId { get; set; }
    }
}