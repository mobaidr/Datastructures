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
        public static BSTNode CreateBSTFor(IEnumerable<int> values)
        {
            return CreateBSTForImpl(values);
        }


        public static void InOrderTraversel(BSTNode root)
        {
            if (root.Left != null)
                InOrderTraversel(root.Left);

            Console.WriteLine(root.Value);

            if (root.Right != null)
                InOrderTraversel(root.Right);
        }

        private static BSTNode CreateBSTForImpl(IEnumerable<int> values)
        {
            BSTNode root = null;

            foreach (var value in values)
            {
                root = AddNodeToBST(root, value);
            }

            return root;
        }

        private static BSTNode AddNodeToBST(BSTNode root, int value)
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
