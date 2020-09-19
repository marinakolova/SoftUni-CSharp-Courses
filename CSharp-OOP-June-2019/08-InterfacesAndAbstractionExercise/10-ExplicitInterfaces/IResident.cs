using System;
using System.Collections.Generic;
using System.Text;

namespace _10_ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; set; }

        string Country { get; set; }

        string GetName();
    }
}
