using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class BSTNode
    {
        public int Value { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
    }

    public class BinarySearchTree
    {
        private BSTNode _root = null;

        class BSTNode
        {
            public int Value { get; set; }
            public BSTNode Left { get; set; }
            public BSTNode Right { get; set; }
        }

        public static void Test()
        {
            var tree = new BinarySearchTree();

            tree.CreateBSTFor(new[] { 3, 100, 50, 200, -100, 35, 121, 2 });
            tree.InOrderTraversel();
            tree.BreathFirstSearch();
            //var root = BinarySearchTree.CreateBSTFor(new[] { 3, 100, 50, 200, -100, 35, 121, 2 });
            //BinarySearchTree.InOrderTraversel(root);

            //int findValue = -100;
            //var node = BinarySearchTree.FindNode(root, findValue);
            //if (node != null) Console.WriteLine($"{findValue} found");
            //else Console.WriteLine($"{findValue} not found");
        }

        private bool IsBST(BSTNode root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.Value < min || root.Value > max)
                return false;

            return IsBST(root.Left, min, root.Value - 1) && IsBST(root.Right, root.Value + 1, max);
        }

        private IEnumerable<BSTNode> GetLeavesOf(BSTNode node)
        {
            if (node == null)
                yield break;

            if (node.Left != null)
                yield return node.Left;

            if (node.Right != null)
                yield return node.Right;
        }

        public void BreathFirstSearch()
        {
            var queue = new Queue<BSTNode>();
            StringBuilder sb = new StringBuilder();

            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                sb.Append($"{node.Value},");

                foreach (var leave in GetLeavesOf(node))
                    queue.Enqueue(leave);
            }

            Console.WriteLine("Breadth First Search");
            Console.WriteLine(sb.ToString());
        }

        public void CreateBSTFor(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                _root = AddNodeToBST(_root, value);
            }
        }

        BSTNode FindNode(BSTNode root, int value)
        {
            if (root == null)
                return null;

            if (root.Value == value)
                return root;
            else if (value < root.Value)
                return FindNode(root.Left, value);
            else
                return FindNode(root.Right, value);
        }


        void InOrderTraversel()
        {
            InOrderTraverselImpl(_root);

            void InOrderTraverselImpl(BSTNode root)
            {
                if (root.Left != null)
                    InOrderTraverselImpl(root.Left);

                Console.WriteLine(root.Value);

                if (root.Right != null)
                    InOrderTraverselImpl(root.Right);
            }
        }



        BSTNode AddNodeToBST(BSTNode root, int value)
        {
            if (root == null)
            {
                root = new BSTNode { Value = value };
            }
            else if (value < root.Value)
            {
                root.Left = AddNodeToBST(root.Left, value);
            }
            else
            {
                root.Right = AddNodeToBST(root.Right, value);
            }

            return root;
        }
    }
}
