using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTask.Models
{
    public class Vertex
    {
        public string id; // Label
        public float x; // Horizontal location on screen
        public float y; // Vertical location on screen
        public double distanceFromStart;
        public Vertex previous;

        // Construcutor
        public Vertex(string id, float x, float y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return (id + " – " + x + " – " + y);
        }

    }
}
