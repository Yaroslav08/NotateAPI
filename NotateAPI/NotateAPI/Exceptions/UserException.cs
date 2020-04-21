using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class UserException:Exception
    {
        public UserException(string Message) : base(Message) { }
    }
}
