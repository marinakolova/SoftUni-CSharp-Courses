using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Ferrari
{
    public interface ICar
    {
        string Model { get; set; }

        string Driver { get; set; }

        string UseBrakes();

        string PushTheGasPedal();
    }
}
