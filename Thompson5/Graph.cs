/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #5                                    ***
*** DUE DATE : 4-19-23                                            ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code create a user-defnined Abstract   ***
***               Data Type using C# classes named Graph, Node    ***
***               and two interface named IProcessData &          ***
***               ISearchAlgorithm                                ***
***               Graph class describes the current state of a    ***
***               Graph class. Implementing the interfaces and    ***
***               containing an overloaded/parameterized          ***
***               constructor  and the field _nodes               ***
********************************************************************/

using System.Text.Json;

namespace GraphNS
{
    public class Graph : IProcessData, ISearchAlgorithms
    {
        private List<Node> _nodes;
        public Queue<Node> Queue { get; set;} = new Queue<Node>();
        public Stack<Node> Stack { get; set;} = new Stack<Node>();



        /********************************************************************
        *** METHOD: public Graph(string filePath)                         ***
        *********************************************************************
        *** DESCRIPTION : This constructor creates a new Graph object by  ***
        ***               initializing a list of nodes and then reading in***
        ***               data from a JSON file specified by the input    ***
        ***               argument 'filePath'. The ReadData method is     ***
        ***               called to parse the data and create Node        ***
        ***               objects, which are stored in the _nodes list.   ***
        *** INPUT ARGS : string filePath - the path to the JSON           ***
        **                                 file containing the graph data ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN :                                                      ***
        ********************************************************************/
        public Graph(string filePath)
        {
            _nodes = new List<Node>();
            ReadData(filePath);
        }

        
        /********************************************************************
        *** METHOD: private void ResetVisitedSet()                        ***
        *********************************************************************
        *** DESCRIPTION : This private method is used to reset the        ***
        ***               WasVisited property of each Node in the _nodes  ***
        ***               list to false. This is necessary before running ***
        ***               a search algorithm, as it ensures that each node***
        ***               is considered unvisited before the search begins***
        *** INPUT ARGS :                                                  ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN :                                                      ***
        ********************************************************************/
        private void ResetVisitedSet()
        {
            foreach (Node n in _nodes)
            {
                n.WasVisited = false;
            }
        }


        /********************************************************************
        *** METHOD: private Node? FindAdjacentUnvisitedNode(Node node)    ***
        *********************************************************************
        *** DESCRIPTION : This private method is used by the DepthFS and  ***
        ***               BreadthFS methods to find the first adjacent    ***
        ***               unvisited node to the current node being visited***
        ***               It iterates through the current node's          ***
        ***               AdjacentNodes list and returns the first node   ***
        ***               that is both adjacent and unvisited. If there   ***
        ***               are no adjacent unvisited nodes, it returns null***
        *** INPUT ARGS : Node node - the node to find adjacent            ***  
        ***                          unvisited nodes for                  ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN :                                                      ***
        ********************************************************************/
        private Node? FindAdjacentUnvisitedNode(Node node)
        {
            if (node.AdjacentNodes == null || _nodes == null)
            {
                return null;
            }

            for (int i = 0; i < node.AdjacentNodes.Count; i++)
            {
                if (i >= _nodes.Count)
                {
                    Console.WriteLine($"Error: index {i} is out of range for _nodes list (node ID: {node.Id})");
                    break;
                }

                if (_nodes[i].Id == node.Id)
                {
                    continue;
                }

                if (node.AdjacentNodes[i])
                {
                    if (!_nodes[i].WasVisited)
                    {
                        return _nodes[i];
                    }
                }
            }
            return null;
        }



        /********************************************************************
        *** METHOD: private static void ViewNode(Node node)               ***
        *********************************************************************
        *** DESCRIPTION : This private static method is used to print the ***
        ***               id of the specified node to the console. It is  ***
        ***               used by the DepthFS and BreadthFS methods to    ***
        ***               display the order in which nodes are visited.   ***
        *** INPUT ARGS : Node node - the node to print the id for         ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN :  void                                                ***
        ********************************************************************/
        private static void ViewNode(Node node)
        {
            if (node == null)
            {
                return;
            }else{
                Console.Write(node.Id.ToString() + " ");
            }
        }


        /********************************************************************
        *** METHOD: public void ReadData(string path)                     ***
        *********************************************************************
        *** DESCRIPTION : Reads JSON data from the given file path,       ***
        ***               deserializes it to a list of Node objects, and  ***
        ***               assigns it to the _nodes member variable. If the*** 
        ***               file doesn't exist, or is empty, error messages ***
        ***               are printed and no data is loaded. Ifthe JSON   ***
        ***               data can't be parsed, an error message is printed**
        ***               and no data is loaded.                          ***
        *** INPUT ARGS : string path - the path to the JSON file to read  ***
        *** OUTPUT ARGS : N/A                                             ***
        *** IN/OUT ARGS : N/A                                             ***
        *** RETURN : void                                                 ***
        ********************************************************************/
        public void ReadData(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"The file '{path}' does not exist.");
                return;
            }

            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Length == 0)
            {
                Console.WriteLine($"The file '{path}' is empty.");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(path);
                var nodes = JsonSerializer.Deserialize<List<Node>>(jsonString);
                _nodes = nodes ?? new List<Node>();

                jsonString = JsonSerializer.Serialize<List<Node>>(_nodes);
                File.WriteAllText(path, jsonString);
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error parsing JSON data: {e.Message}");
            }
        }



        /********************************************************************
        *** METHOD: public void BreadthFS(int start)                      ***
        *********************************************************************
        *** DESCRIPTION : Performs a breadth-first search starting at the ***
        ***               node at the given index in _nodes. Visited nodes***
        ***               are marked as such and printed to the console.  ***
        *** INPUT ARGS : int start - the index of the starting node       ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN : void                                                 ***
        ********************************************************************/
        public void BreadthFS(int start)
        {
            //checking if there is any node to start at in the list
            if (start < 0 || start >= _nodes.Count)
            {
                 Console.WriteLine($"Error: invalid start index {start} (nodes count: {_nodes.Count})");
                return;
            }
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



        /********************************************************************
        *** METHOD: public void DepthFS(int start)                        ***
        *********************************************************************
        *** DESCRIPTION : Performs a depth-first search starting at the   ***
        ***               node at the given index in _nodes. Visited nodes***
        ***               are marked as such and printed to the console.  ***
        *** INPUT ARGS : int start - the index of the starting node       ***
        *** OUTPUT ARGS :                                                 ***
        *** IN/OUT ARGS :                                                 ***
        *** RETURN : void                                                 ***
        ********************************************************************/
        public void DepthFS(int start)
        {
            if (start < 0 || start >= _nodes.Count)
            {
                Console.WriteLine($"Error: invalid start index {start} (nodes count: {_nodes.Count})");
                return;
            }

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
