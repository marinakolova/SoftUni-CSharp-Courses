using System;

namespace _04_Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            var phone = new Smartphone();
            var phoneNumbers = Console.ReadLine().Split();
            var sites = Console.ReadLine().Split();

            if (phoneNumbers.Length > 0)
            {
                phone.Call(phoneNumbers);
            }

            if (sites.Length > 0)
            {                
                phone.Browse(sites);
            }
        }
    }
}
