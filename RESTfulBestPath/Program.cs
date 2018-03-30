using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RESTfulBestPath.Models;

namespace RESTfulBestPath
{
    public class Program
    {

        //static void TestShortestPath(NodeMap map)
        //{
        //    //Time to test! Start with trivial example.
        //    NodeMap testMap6Nodes = getMap();
        //    Console.WriteLine("Map populated; about to test path a-->b . . .");
        //    Console.WriteLine("Distance should be 6 . . . ");
        //    BestPathDirections result = testMap6Nodes.getBestPath(testMap6Nodes.allNodes["a"],
        //        testMap6Nodes.allNodes["e"]);
        //    Console.WriteLine("Distance is {0}", result.totalDistance);
        //    Console.WriteLine("Path is ");
        //    foreach (var loc in result.nodePath)
        //        Console.Write(" {0} ", loc);


        //}
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
