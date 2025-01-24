using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Shape2D
    {

        public Shape2D() { }

        public virtual float CalculateArea()
        {
            Console.WriteLine("Undefined shape cannot have area.");
            return 0;
        }
        public virtual float CalculateAspectRatio()
        {
            Console.WriteLine("Undefined shape cannot have aspect ratio.");
            return 0;
        }

        public virtual float ContainsPoint(float x, float y)
        {
            Console.WriteLine("Undefined shape cannot have area.");
            return 0;
        }
    }
}
