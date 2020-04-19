using System;
using System.Collections.Generic;
using System.Text;
namespace NotateAPI.Exceptions
{
    public class APIReadResponseException : Exception
    {
        public APIReadResponseException(string Message) : base(Message) { }
    }
}