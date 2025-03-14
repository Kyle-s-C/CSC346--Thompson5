﻿/********************************************************************
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
***               Program.cs runs everything                      ***
********************************************************************/

namespace GraphNS
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Graph g2 = new Graph("testing.json");
            Graph graph = new Graph("C:\\Users\\kytho\\OneDrive\\Desktop\\OOP\\graph_data.json");



            try
            {
                // Create a new Graph object using the graph data file
                

                // Perform a Breadth First Search starting from node 0
                Console.WriteLine("Breadth First Search: 0");
                graph.BreadthFS(0);
                Console.WriteLine();
                Console.WriteLine("Breadth First Search: 1");
                graph.BreadthFS(1);
                Console.WriteLine();
                Console.WriteLine("Breadth First Search: 2");
                graph.BreadthFS(2);
                Console.WriteLine();
                Console.WriteLine("Breadth First Search: 3");
                graph.BreadthFS(3);
                Console.WriteLine();
                Console.WriteLine("Breadth First Search: 4");
                graph.BreadthFS(4);
                Console.WriteLine();

                // Perform a Depth First Search starting from node 0
                Console.WriteLine("Depth First Search: 0");
                graph.DepthFS(0);
                Console.WriteLine();
                Console.WriteLine("Depth First Search: 1");
                graph.DepthFS(1);
                Console.WriteLine();
                Console.WriteLine("Depth First Search: 2");
                graph.DepthFS(2);
                Console.WriteLine();
                Console.WriteLine("Depth First Search: 3");
                graph.DepthFS(3);
                Console.WriteLine();
                Console.WriteLine("Depth First Search: 4");
                graph.DepthFS(4);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}





