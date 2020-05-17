using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Exceptions
{
    public class SpreadException:Exception
    {
        public SpreadException(string Message) : base(Message) { }
    }
}