using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask.Models
{
    class Dijkstra
    {
        public List<Vertex> Vertices;

        public List<Edge> edges;
        // Constructor 
        public Dijkstra()
        {
            Vertices = new List<Vertex>(); // Holds the Vertices
            edges = new List<Edge>(); // Holds the connections
        }

        // Dijkstra calculation algorithm 
        public void Execute()
        {
            while (Vertices.Count > 0)
            {
                // For each smallset Vertex
                Vertex smallest = ExtractSmallest();

                // Get the adjacents 
                List<Vertex> adjacentVertices = AdjacentRemainingVertices(smallest);
                // for each adjacent Vertex calculate the distance

                int size = adjacentVertices.Count;

                for (int i = 0; i < size; ++i)
                {
                    Vertex adjacent = adjacentVertices.ElementAt(i);

                    double distance = Distance(smallest, adjacent) + smallest.distanceFromStart;

                    if (distance < adjacent.distanceFromStart)
                    {
                        adjacent.distanceFromStart = distance;
                        adjacent.previous = smallest;
                    }
                }
            }
        }

        private List<Vertex> AdjacentRemainingVertices(Vertex smallest)
        {
            throw new NotImplementedException();
        }

        private double Distance(Vertex smallest, Vertex adjacent)
        {
            throw new NotImplementedException();
        }

        private Vertex ExtractSmallest()
        {
            int min = Int32.MaxValue;

            foreach (var vert in Vertices)
            {
                if(vert.)
            }
        }
    }
}
