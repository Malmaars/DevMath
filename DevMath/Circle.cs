using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Circle
    {
        public Vector2 Position
        {
            get; set;
        }

        public float Radius
        {
            get; set;
        }

        public bool CollidesWith(Circle circle)
        {
            // if D(Am, Bm) < Ar + Br, collide
            float Distance = (float)System.Math.Sqrt(((Position.x - circle.Position.x) * (Position.x - circle.Position.x)) + ((Position.y - circle.Position.y) * (Position.y - circle.Position.y)));
            if(Distance < Radius + circle.Radius)
            {
                return true;
            }

            return false;
        }
    }
}
