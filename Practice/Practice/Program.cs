using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestSegmentTree();
            TestSegmentTreeFormationForSum();
        }

        static void TestSegmentTreeFormationForSum()
        {
            SegmentTreeLib lib = new SegmentTreeLib();
            List<int> input = new List<int>() { 5, 3, 2, 6, 1, 4 };
            List<int> output = lib.CreateSegementArray(input);
            // output.ForEach(entry => Console.WriteLine(entry));
            int result = lib.FindSum(2, 3);
            Console.WriteLine($"Sum result: {result}");
            Console.ReadLine();
        }

        static void TestSegmentTree()
        {
            ////Input:
            ////Heights: 5 3 2 6 1 4
            ////InFronts: 0 1 2 0 3 2
            ////Output: actual order is: 5 3 2 1 6 4

            SegmentTreeLib lib = new SegmentTreeLib();
            List<int> Heights = new List<int>() { 5, 3, 2, 6, 1, 4 } ;
            List<int> InFronts = new List<int>() { 0, 1, 2, 0, 3, 2 };
            List<int> output = lib.order(Heights, InFronts);
            output.ForEach(entry => Console.WriteLine(entry));
            Console.ReadLine();
        }
    }
}
