namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var result = new StringBuilder();
            
            this.OrderDfsForString(0, result, this);

            return result.ToString().Trim();
        } 

        public List<T> GetLeafKeys()
        {
            var leafKeys = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (this.IsLeaf(currentNode))
                {
                    leafKeys.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return leafKeys;
        }

        public List<T> GetMiddleKeys()
        {
            var middleKeys = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (this.IsMiddle(currentNode))
                {
                    middleKeys.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return middleKeys;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leafNodes = this.OrderBfs()
                .Where(node => this.IsLeaf(node));

            int deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                int currentDepth = this.GetDepthFromLeafToParent(node);

                if (currentDepth > deepestNodeDepth)
                {
                    deepestNodeDepth = currentDepth;
                    deepestNode = node;
                }
            }

            return deepestNode;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestLeftomostNode();
            var currentNode = deepestNode;
            var resultPath = new Stack<T>();
            
            while (currentNode != null)
            {
                resultPath.Push(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            return new List<T>(resultPath);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            
            var currentPath = new List<T>();
            currentPath.Add(this.Key);
            
            int currentSum = Convert.ToInt32(this.Key);
            
            this.GetPathsWithSumDfs(this, result, currentPath, ref currentSum, sum);
            
            return result;
        }        

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<T>>();
            
            var allNodes = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (HasGivenSum(currentNode, sum))
                {
                    allNodes.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            foreach (var node in allNodes)
            {
                var currentNodeSum = this.GetSubtreeSumDfs(node);

                if (currentNodeSum == sum)
                {
                    result.Add(node);
                }
            }

            return result;
        }

        private void OrderDfsForString(int depth, 
            StringBuilder result, 
            Tree<T> subtree)
        {
            result
                .Append(new string(' ', depth))
                .Append(subtree.Key)
                .Append(Environment.NewLine);

            foreach (var child in subtree.Children)
            {
                this.OrderDfsForString(depth + 2, result, child);
            }
        }

        private bool IsLeaf(Tree<T> node)
        {
            return node.Children.Count == 0;
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.Parent == null;
        }

        private bool IsMiddle(Tree<T> node)
        {
            return node.Parent != null && node.Children.Count > 0;
        }

        private List<Tree<T>> OrderBfs()
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                result.Add(currentNode);                

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private int GetDepthFromLeafToParent(Tree<T> node)
        {
            int depth = 0;
            var current = node;

            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        private void GetPathsWithSumDfs(
            Tree<T> current, 
            List<List<T>> wantedPaths, 
            List<T> currentPath, 
            ref int currentSum, 
            int wantedSum)
        {
            foreach (var child in current.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathsWithSumDfs(child, wantedPaths, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                wantedPaths.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(current.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private bool HasGivenSum(Tree<T> currentNode, int sum)
        {
            int actualSum = this.GetSubtreeSumDfs(currentNode);

            return actualSum == sum;
        }

        private int GetSubtreeSumDfs(Tree<T> currentNode)
        {
            int currentSum = Convert.ToInt32(currentNode.Key);
            int childSum = 0;

            foreach (var childNode in currentNode.Children)
            {
                childSum += this.GetSubtreeSumDfs(childNode);
            }

            return currentSum + childSum;
        }
    }
}
