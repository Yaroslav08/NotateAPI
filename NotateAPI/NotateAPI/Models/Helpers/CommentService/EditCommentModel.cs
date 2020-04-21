using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotateAPI.Models.Helpers.CommentService
{
    public class EditCommentModel
    {
        [Required]
        public long CommentId { get; set; }
        [Required, MinLength(1), MaxLength(500)]
        public string Text { get; set; }
    }
}
