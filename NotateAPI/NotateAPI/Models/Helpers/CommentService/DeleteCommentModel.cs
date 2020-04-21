using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NotateAPI.Models.Helpers.CommentService
{
    public class DeleteCommentModel
    {
        [Required]
        public long CommentId { get; set; }
    }
}
