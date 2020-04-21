using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotateAPI.Models.Helpers.CommentService
{
    public class CreateCommentModel
    {
        [Required]
        public long NoteId { get; set; }
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
    }
}
