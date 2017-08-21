using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask.Models
{
    public class Edge
    {
        public Vertex Vertex1; // Vertex one
        public Vertex Vertex2; // Vertex two
        public float Distance; // DIstance or similar
        public float Cost; // Cost or multiplier factor

        // Contructor
        public Edge(Vertex Vertex1, Vertex Vertex2, float distance, float cost)
        {
            this.Vertex1 = Vertex1;
            this.Vertex2 = Vertex2;
            this.Distance = distance;
            this.Cost = cost;
        }
    }
}
