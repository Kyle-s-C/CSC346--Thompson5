using System.Collections.Generic;

namespace GraphNS
{
    public class Node
    {
        public int Id { get; set; }
        public bool WasVisited { get; set; }
        public List<bool> AdjacentNodes { get; set; } = new List<bool>();
    }
}


