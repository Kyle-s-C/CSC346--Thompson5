using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GraphNS
{
    public class Graph : IProcessData, ISearchAlgorithms
    {
        private List<Node> _nodes;

        public Graph(string filePath)
        {
            _nodes = new List<Node>();
            ReadData(filePath);
        }

        public Queue<Node> Queue { get; } = new Queue<Node>();
        public Stack<Node> Stack { get; } = new Stack<Node>();

        private void ResetVisitedSet()
        {
            foreach (var node in _nodes)
            {
                node.WasVisited = false;
            }
        }

        private Node? FindAdjacentUnvisitedNode(Node node)
        {
            for (int i = 0; i < node.AdjacentNodes.Count; i++)
            {
                if (node.AdjacentNodes[i] && !_nodes[i].WasVisited)
                {
                    return _nodes[i];
                }
            }
            return null;
        }

        private static void ViewNode(Node node)
        {
            Console.Write($"{node.Id} ");
        }

        public void ReadData(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File '{path}' not found.");
            }

            string jsonString = File.ReadAllText(path);
            _nodes = JsonSerializer.Deserialize<List<Node>>(jsonString)!;
        }



        public void BreadthFS(int start)
        {
            ResetVisitedSet();
            var startNode = _nodes[start];
            Queue.Enqueue(startNode);
            startNode.WasVisited = true;
            ViewNode(startNode);

            while (Queue.Count > 0)
            {
                var currentNode = Queue.Dequeue();
                Node? nextNode;
                while ((nextNode = FindAdjacentUnvisitedNode(currentNode)) != null)
                {
                    nextNode.WasVisited = true;
                    ViewNode(nextNode);
                    Queue.Enqueue(nextNode);
                }
            }
            Console.WriteLine();
        }

        public void DepthFS(int start)
        {
            ResetVisitedSet();
            var startNode = _nodes[start];
            Stack.Push(startNode);
            startNode.WasVisited = true;
            ViewNode(startNode);

            while (Stack.Count > 0)
            {
                var currentNode = Stack.Peek();
                var nextNode = FindAdjacentUnvisitedNode(currentNode);

                if (nextNode == null)
                {
                    Stack.Pop();
                }
                else
                {
                    nextNode.WasVisited = true;
                    ViewNode(nextNode);
                    Stack.Push(nextNode);
                }
            }
            Console.WriteLine();
        }
    }
}
