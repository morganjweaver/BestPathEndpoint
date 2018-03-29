using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApplication
{
    class Program
    {
        static NodeMap getMap()
        {
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
            return testMap6Nodes;
        }
        static void TestShortestPath(NodeMap map)
        {
            //Time to test! Start with trivial example.
            NodeMap testMap6Nodes = getMap();
            Console.WriteLine("Map populated; about to test path a-->b . . .");
            Console.WriteLine("Distance should be 6 . . . ");
            BestPathDirections result = testMap6Nodes.getBestPath(testMap6Nodes.allNodes["a"], 
                testMap6Nodes.allNodes["e"]);
            Console.WriteLine("Distance is {0}", result.totalDistance);
            Console.WriteLine("Path is ");
            foreach(var loc in result.nodePath)
                Console.Write(" {0} ", loc);
            

        }

        static void TestJSONDeserializer()
        {
            NodeMap map = getMap();
            string test = @"{'nodes': 'a': [ {'d',5},{'b':2}]}";
            //map.UpdateMap(test);
            //Console.WriteLine();
            IncomingNodeListJSON testList = new IncomingNodeListJSON();
            testList.nodes.Add("a", new Dictionary<string, float>());
            testList.nodes["a"].Add("b",3);
            testList.nodes["a"].Add("c",5);
            string jsonTestSer = JsonConvert.SerializeObject(testList);
            map.UpdateMap(jsonTestSer);
            Console.WriteLine(jsonTestSer);
            IncomingNodeListJSON undo = JsonConvert.DeserializeObject<IncomingNodeListJSON>(jsonTestSer);
            Console.Write("\n");




        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TestShortestPath();
            TestJSONDeserializer();

        }
    }
}