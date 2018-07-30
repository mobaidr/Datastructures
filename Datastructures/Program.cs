using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = BinarySearchTree.CreateBSTFor(new[] { 3, 100, 50, 200, -100, 35, 121, 2 });
            BinarySearchTree.InOrderTraversel(root);
            Console.ReadLine();
        }
    }
}
