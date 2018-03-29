using System.Collections.Generic;

namespace ConsoleApplication
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