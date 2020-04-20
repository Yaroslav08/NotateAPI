using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class GetUserException:Exception
    {
        public GetUserException(string Message) : base(Message) { }
    }
}
