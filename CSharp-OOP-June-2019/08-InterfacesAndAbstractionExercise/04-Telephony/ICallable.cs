using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Telephony
{
    public interface ICallable
    {
        void Call(string[] phoneNumbers);
    }
}
