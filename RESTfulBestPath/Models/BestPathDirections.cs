using System.Collections.Generic;

namespace RESTfulBestPath
{
    public class BestPathDirections
    {
        public List<string> nodePath { get; set; }
        public float totalDistance { get; set; }

        public BestPathDirections()
        {
            this.nodePath = new List<string>();
        }
        
    }
}