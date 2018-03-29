using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace ConsoleApplication
{
    public class NodeMap
    {
        public string ID { get; set; }
        public Dictionary<string, Node> allNodes = new Dictionary<string, Node>();

        public NodeMap(string ID)
        {
            this.ID = ID;
        }
        //Djikstra's algo, a greedy, spanning tree algo that finds the shortest paths for all nodes:
        public int UpdateMap(string JSONput)
        {
            //TODO: Add try/catch here!
            
            IncomingNodeListJSON nodeUpdates = JsonConvert.DeserializeObject<IncomingNodeListJSON>(JSONput);
            foreach (string node in nodeUpdates.nodes.Keys)
            {
                foreach (var pair in nodeUpdates.nodes[node])
                {
                    if (allNodes[node].nodeDictionary.ContainsKey(pair.Key))
                        allNodes[node].nodeDictionary[pair.Key] = pair.Value;
                    else
                        allNodes[node].nodeDictionary.Add(pair.Key, pair.Value);
                }
               
            }
            return 0;
        }
        public BestPathDirections getBestPath(Node start, Node end)
        {
            BestPathDirections returnPath = new BestPathDirections();
            int runningTotalDistance = 0;
            Dictionary<string, float> pathLengths = new Dictionary<string, float>(); //shortest paths from source to given node
            Dictionary<string, bool> visitedYet = new Dictionary<string, bool>();
            Dictionary<string, string> nodeParent = new Dictionary<string, string>(); 
            //nodePaths holds the cheapest predecessor to each node; recursively backtrack to find path
            
            if (this.allNodes.Count == 0 || this.allNodes.Count == 1) //return for edge cases
            {
                returnPath.nodePath.Add("ERROR");
                returnPath.totalDistance = 0;
                return returnPath;
            }
            
            //Inner method chosen bc minDist not used anywhere else, needs all of BestPath's dictionaries
            string minDistance()
            {
                // Initialize min value
                float bestSoFar = int.MaxValue;
                string bestID = "ERROR"; //returns error otherwise
                
                 //for each node connected to current, compare distances to find smallest
                foreach (var node in pathLengths)
                {
                    //for all nodes not yet explored
                    if (visitedYet[node.Key] == false &&
                        node.Value <= bestSoFar)
                    {
                        bestSoFar = node.Value;
                        bestID = node.Key;
                    }
                }

                return bestID;
            }

            void getReturnPathSequence(string dest)
            {
                if (nodeParent[dest] == "NONE")
                {
                    returnPath.totalDistance = pathLengths[end.ID];
                    return;
                } //if source node, add total dist and return to caller
                    
                returnPath.nodePath.Add(nodeParent[dest]);
                getReturnPathSequence(nodeParent[dest]);
            }
            //Here we initialize the data structures that hold the map of path lengths as the algo
            //explores each option, as well as a true/false map of visited nodes and finally a list
            //of the node sequence to arrive at each node:
            foreach (var location in this.allNodes.Keys.ToList())
            {
                pathLengths[location] = int.MaxValue; //init all path dists to infinity til we learn otherwise
                visitedYet.Add(location, false); //haven't visited any nodes yet
                nodeParent.Add(location, "NONE"); //track cheapest last edge to current node, init all to undiscovered

            }

            pathLengths[start.ID] = 0; //init dist to self as 0 vs. MaxInt; start here
            
            
            foreach (var node in this.allNodes) //greater node map
            {
                //pick min from current node
                string currentNode = minDistance();
                visitedYet[currentNode] = true;

                foreach (var item in this.allNodes[currentNode].nodeDictionary) //for all nodes connected to current
                {
                    if (!visitedYet[item.Key] && (pathLengths[currentNode] +
                        allNodes[currentNode].nodeDictionary[item.Key] < pathLengths[item.Key]))
                    {
                        nodeParent[item.Key] = currentNode;
                        pathLengths[item.Key] = pathLengths[currentNode] +
                                                allNodes[currentNode].nodeDictionary[item.Key];
                    }
                }

            }
            returnPath.nodePath.Add(end.ID);//add final dest to beginning of list before recursive building of sequence
            getReturnPathSequence(end.ID);
            returnPath.nodePath.Reverse(); // !!! C/C++ definitely doesn't have this
            return returnPath;


        }

        
    }
}