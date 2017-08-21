using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphTask.Models;

namespace GraphTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the tree from the sample
            Tree<int> tree =
                new Tree<int>(7,
                    new Tree<int>(19,
                        new Tree<int>(1),
                        new Tree<int>(12),
                        new Tree<int>(31)),
                    new Tree<int>(21),
                    new Tree<int>(14,
                        new Tree<int>(23),
                        new Tree<int>(6))
                );
            Tree<int> treee = new Tree<int>(1);
            treee.

            // Traverse and print the tree using Depth-First-Search
            tree.TraverseDFS();

            // Console output:
            // 7
            //       19
            //        1
            //        12
            //        31
            //       21
            //       14
            //        23
            //        6
        }
    }
}
