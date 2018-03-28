using System.Collections.Generic;

namespace ConsoleApplication
{
    public class NodeMap
    {
        public string ID { get; set; }
        public Dictionary<string, Node> allNodes = new Dictionary<string, Node>();
        
        //Djikstra's algo, a greedy, spanning tree algo that finds the shortest paths for all nodes:
        public BestPathDirections getBestPath(Node start, Node end)
        {
            BestPathDirections returnPath = new BestPathDirections();
            int runningTotalDistance = 0;
            Dictionary<string, float> pathLengths = start.nodeDictionary;
            Dictionary<string, bool> visitedYet = new Dictionary<string, bool>();
            Dictionary<string, List<string>> nodePaths = new Dictionary<string, List<string>>();
            
            //Here we initialize the data structures that hold the map of path lengths as the algo
            //explores each option, as well as a true/false map of visited nodes and finally a list
            //of the node sequence to arrive at each node:
            foreach (var location in start.nodeDictionary.Keys)
            {
                pathLengths[location] = int.MaxValue;
                visitedYet.Add(location, false);
                nodePaths.Add(location, new List<string>());

            }


        }

        
    }
}