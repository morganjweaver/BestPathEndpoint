using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Node
    {
        //This node's dictionary stores keys (other buildings) and values (distance) of this node's relationship
        //with all other nodes.
        public string ID { get; set; }
        public Dictionary<string,float> nodeDictionary = new Dictionary<string, float>();
        
        
    }
    }
}