using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class APIAuthException:Exception
    {
        public APIAuthException(string Message) : base(Message) { }
    }
}
