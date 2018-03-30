﻿using System.Collections.Generic;

namespace RESTfulBestPath
{
    //classes for JSON deserialization
    public class IncomingNodeListJSON
    {
        public Dictionary<string, Dictionary<string,float>> nodes { get; set; }
		public string ID { get; set; }

        public IncomingNodeListJSON()
        {
            this.nodes = new Dictionary<string, Dictionary<string,float>>();
        }
    }
   
}