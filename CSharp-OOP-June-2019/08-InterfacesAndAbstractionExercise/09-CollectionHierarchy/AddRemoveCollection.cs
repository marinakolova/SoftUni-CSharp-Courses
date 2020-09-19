using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class AddRemoveCollection
    {
        public List<string> Collection { get; set; }

        public AddRemoveCollection()
        {
            this.Collection = new List<string>();
        }

        public int Add(string element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string lastElement = this.Collection[this.Collection.Count - 1];
            this.Collection.RemoveAt(this.Collection.Count - 1);
            return lastElement;
        }
    }
}
