using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Exceptions
{
    public class CommentException:Exception
    {
        public CommentException(string Message) : base(Message) { }
    }
}