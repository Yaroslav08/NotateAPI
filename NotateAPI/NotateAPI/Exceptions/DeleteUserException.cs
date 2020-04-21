using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class DeleteUserException:Exception
    {
        public DeleteUserException(string Message) : base(Message) { }
    }
}
