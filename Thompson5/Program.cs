

namespace GraphNS
{
    class Program
    {
        static void Main(string[] args)
        {
            string graphDataPath = "graph_data.json";

            try
            {
                // Create a new Graph object using the graph data file
                Graph graph = new Graph(graphDataPath);

                // Perform a Breadth First Search starting from node 0
                Console.WriteLine("Breadth First Search: 0");
                graph.BreadthFS(0);

                Console.WriteLine("Breadth First Search: 1");
                graph.BreadthFS(1);

                Console.WriteLine("Breadth First Search: 2");
                graph.BreadthFS(2);
                Console.WriteLine("Breadth First Search: 3");
                graph.BreadthFS(3);
                Console.WriteLine("Breadth First Search: 4");
                graph.BreadthFS(4);

                // Perform a Depth First Search starting from node 0
                Console.WriteLine("Depth First Search: 0");
                graph.DepthFS(0);
                Console.WriteLine("Depth First Search: 1");
                graph.DepthFS(1);
                Console.WriteLine("Depth First Search: 2");
                graph.DepthFS(2);
                Console.WriteLine("Depth First Search: 3");
                graph.DepthFS(3);
                Console.WriteLine("Depth First Search: 4");
                graph.DepthFS(4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}





