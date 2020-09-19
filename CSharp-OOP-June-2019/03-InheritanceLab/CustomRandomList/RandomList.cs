using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public List<string> TheList { get; set; }

        public RandomList()
        {
            this.TheList = new List<string>();
        }

        public string RandomString()
        {
            var rnd = new Random();
            int index = rnd.Next(0, this.TheList.Count);

            string element = this.TheList[index];
            this.TheList.RemoveAt(index);

            return element;
        }
    }
}
