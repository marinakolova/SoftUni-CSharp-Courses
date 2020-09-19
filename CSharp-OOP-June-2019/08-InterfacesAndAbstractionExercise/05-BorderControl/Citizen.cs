using System;
using System.Collections.Generic;
using System.Text;

namespace _05_BorderControl
{
    public class Citizen : IIdentifiable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Id { get; set; }
    }
}
