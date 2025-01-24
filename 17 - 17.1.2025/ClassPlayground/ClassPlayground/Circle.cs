using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Circle : Shape2D
    {
        public float radius;

        public override float CalculateArea()
        {
            return (float)Math.PI * radius * radius;
        }

        /*public override float ContainsPoint(float x, float y)
        {
            return Math.Sqrt(x * x + y * y) <= radius;
        }*/

    }
}
