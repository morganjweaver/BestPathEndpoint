using System.Collections.Generic;

namespace ConsoleApplication
{
    //classes for JSON deserialization
    public class IncomingNodeListJSON
    {
        public Dictionary<string, Dictionary<string,float>> nodes { get; set; }

        public IncomingNodeListJSON()
        {
            this.nodes = new Dictionary<string, Dictionary<string,float>>();
        }
    }
   
}