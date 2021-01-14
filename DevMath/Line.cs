using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Line
    {
        public Vector2 Position
        {
            get; set;
        }

        public Vector2 Direction
        {
            get; set;
        }

        public float Length
        {
            get; set;
        }

        public float DirectionalCoefficient
        {
            //delta y gedeeld door delta x
            get { (Direction.y - Position.y) \ (Direction.x - Position.x) }
            private set;
        }
    }
}
