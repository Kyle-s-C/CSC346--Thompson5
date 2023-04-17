using System.Collections.Generic;

namespace GraphNS
{
    public interface ISearchAlgorithms
    {
        Queue<Node> Queue { get => Queue; set => Queue = value;}
        Stack<Node> Stack { get => Stack; set => Stack = value; }

        public abstract void BreadthFS(int start);
        public abstract void DepthFS(int start);
    }
}
