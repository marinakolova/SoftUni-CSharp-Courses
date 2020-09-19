using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class AddCollection
    {
        public List<string> Collection { get; set; }

        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public int Add(string element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}
