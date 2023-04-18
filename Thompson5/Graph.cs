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
        *** DESCRIPTION : <detailed English description of the method> ***
        *** INPUT ARGS : <list of all input parameter names> ***
        *** OUTPUT ARGS : <list of all output parameter names> ***
        *** IN/OUT ARGS : <list of all input/output parameter names> ***
        *** RETURN : <return type and return value name> ***
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
        *** METHOD <name of method> ***
        *********************************************************************
        *** DESCRIPTION : <detailed English description of the method> ***
        *** INPUT ARGS : <list of all input parameter names> ***
        *** OUTPUT ARGS : <list of all output parameter names> ***
        *** IN/OUT ARGS : <list of all input/output parameter names> ***
        *** RETURN : <return type and return value name> ***
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
        *** METHOD <name of method> ***
        *********************************************************************
        *** DESCRIPTION : <detailed English description of the method> ***
        *** INPUT ARGS : <list of all input parameter names> ***
        *** OUTPUT ARGS : <list of all output parameter names> ***
        *** IN/OUT ARGS : <list of all input/output parameter names> ***
        *** RETURN : <return type and return value name> ***
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
        *** METHOD <name of method> ***
        *********************************************************************
        *** DESCRIPTION : <detailed English description of the method> ***
        *** INPUT ARGS : <list of all input parameter names> ***
        *** OUTPUT ARGS : <list of all output parameter names> ***
        *** IN/OUT ARGS : <list of all input/output parameter names> ***
        *** RETURN : <return type and return value name> ***
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
        *** METHOD <name of method> ***
        *********************************************************************
        *** DESCRIPTION : <detailed English description of the method> ***
        *** INPUT ARGS : <list of all input parameter names> ***
        *** OUTPUT ARGS : <list of all output parameter names> ***
        *** IN/OUT ARGS : <list of all input/output parameter names> ***
        *** RETURN : <return type and return value name> ***
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
