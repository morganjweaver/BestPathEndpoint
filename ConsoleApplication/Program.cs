using System;

namespace ConsoleApplication
{
    class Program
    {
        static void TestShortestPath()
        {
            //Time to test! Start with trivial example.
            NodeMap testMap6Nodes = new NodeMap();
            for (var i = 'a'; i < 'g'; i++)
            {
                var n = new Node(i.ToString());
                testMap6Nodes.allNodes.Add(i.ToString(),n);
            }
            testMap6Nodes.allNodes["a"].nodeDictionary.Add("b", 4);
            testMap6Nodes.allNodes["a"].nodeDictionary.Add("c", 2);
            testMap6Nodes.allNodes["b"].nodeDictionary.Add("a", 4);
            testMap6Nodes.allNodes["b"].nodeDictionary.Add("e", 5);
            testMap6Nodes.allNodes["c"].nodeDictionary.Add("a", 2);
            testMap6Nodes.allNodes["c"].nodeDictionary.Add("f", 1);
            testMap6Nodes.allNodes["c"].nodeDictionary.Add("d", 3);
            testMap6Nodes.allNodes["f"].nodeDictionary.Add("c", 1);
            testMap6Nodes.allNodes["d"].nodeDictionary.Add("e", 1);
            testMap6Nodes.allNodes["d"].nodeDictionary.Add("c", 3);
            testMap6Nodes.allNodes["e"].nodeDictionary.Add("d", 1);
            testMap6Nodes.allNodes["e"].nodeDictionary.Add("b", 5);
            Console.WriteLine("Map populated; about to test path a-->b . . .");
            Console.WriteLine("Distance should be 6 . . . ");
            BestPathDirections result = testMap6Nodes.getBestPath(testMap6Nodes.allNodes["a"], 
                testMap6Nodes.allNodes["e"]);
            Console.WriteLine("Distance is %s", result.totalDistance);
            Console.WriteLine("Path is ");
            foreach(var loc in result.nodePath)
                Console.Write(" %s ", loc);
            

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestShortestPath();

        }
    }
}