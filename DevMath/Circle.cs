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
            float Distance = System.Math.Sqrt(((Position.x - circle.Position.x) * (Position.x - circle.Position.x)) + ((Position.y - circle.Position.y) * (Position.y - circle.Position.y)));
            if(Distance < Radius + circle.Radius)
            {
                return true
            }

            return false
        }

        public bool LineCollision(Line line)
        {
            float a = -1 / line.DirectionalCoefficient;
            float b = -1 * ((a * Position.x) / Position.y);
            float aLine = line.DirectionalCoefficient;
            float bLine = -1 * (line.DirectionalCoefficient * line.Position.x) / line.Position.y;
            // formule voor de line: Position.y = a * Position.x + b
            //snijpunt met de lijnen is het dichtsbijzijnde punt relatief tot de cirkel
            Vector2 cross = new Vector2(((bLine - b)/(a - aLine)),( -(aLine * a * bLine) + aLine * aLine * b + a * a * bLine - aLine * a * b));

            //Nu we het snijpunt hebben kunnen we de afstand tussen het midden van de cirkel en de lijn berekenen
            float distance = System.Math.Sqrt(((Position.x - cross.Position.x) * (Position.x - cross.Position.x)) + ((Position.y - cross.Position.y) * (Position.y - cross.Position.y)));
            if(distance < Radius)
            {
                return true;
            }

            return false;
        }
    }
}
