namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                int[] keys = line.Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int parentKey = keys[0];
                int childKey = keys[1];

                this.AddEdge(parentKey, childKey);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            //var firstKey = this.nodesBykeys.Keys.First();
            //return this.nodesBykeys[firstKey];

            foreach (var keyByNode in this.nodesBykeys)
            {
                if (keyByNode.Value.Parent == null)
                {
                    return keyByNode.Value;
                }
            }            

            return null;            
        }
    }
}
