using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class EditUserException :Exception
    {
        public EditUserException(string Message) : base(Message) { }
    }
}
