using System;
using System.Collections.Generic;
using System.Text;

namespace _09_CollectionHierarchy
{
    public class MyList
    {
        public List<string> Collection { get; set; }

        public MyList()
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
            string firstElement = this.Collection[0];
            this.Collection.RemoveAt(0);
            return firstElement;
        }
    }
}
