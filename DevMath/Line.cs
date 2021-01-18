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
            //dit is in graden
            get { return (Direction.y - Position.y) / (Direction.x - Position.x); }
            private set { }
        }

        public bool IntersectsWith(Circle circle)
        {
            float a = -1 / DirectionalCoefficient;
            float b = -1 * ((a * circle.Position.x) / circle.Position.y);
            float aLine = DirectionalCoefficient;
            float bLine = -1 * (DirectionalCoefficient * Position.x) / Position.y;
            // formule voor de line: Position.y = a * Position.x + b
            //snijpunt met de lijnen is het dichtsbijzijnde punt relatief tot de cirkel
            Vector2 cross = new Vector2(((bLine - b) / (a - aLine)), (-(aLine * a * bLine) + aLine * aLine * b + a * a * bLine - aLine * a * b));

            //Nu we het snijpunt hebben kunnen we de afstand tussen het midden van de cirkel en de lijn berekenen
            float distance = (float)System.Math.Sqrt(((circle.Position.x - cross.x) * (circle.Position.x - cross.x)) + ((circle.Position.y - cross.y) * (circle.Position.y - cross.y)));
            if (distance < circle.Radius)
            {
                return true;
            }

            return false;
        }
    }
}
