using System;
using System.Collections.Generic;
using System.Text;

namespace NotateAPI.Exceptions
{
    public class NoteException:Exception
    {
        public NoteException(string Message):base(Message) { }
    }
}
