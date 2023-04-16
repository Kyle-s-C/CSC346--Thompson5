using System.Collections.Generic;

namespace GraphNS
{
    public interface ISearchAlgorithms
    {
        Queue<Node> Queue { get; }
        Stack<Node> Stack { get; }

        void BreadthFS(int start);
        void DepthFS(int start);
    }
}
