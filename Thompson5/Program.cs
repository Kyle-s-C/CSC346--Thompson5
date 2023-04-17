namespace GraphNS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the path to the graph data file
            string graphDataPath = "graph_data.json";

            try
            {
                // Create a new Graph object using the graph data file
                Graph graph = new Graph(graphDataPath);

                // Perform a Breadth First Search starting from node 0
                Console.WriteLine("Breadth First Search:");
                graph.BreadthFS(0);

                // Perform a Depth First Search starting from node 0
                Console.WriteLine("Depth First Search:");
                graph.DepthFS(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}





