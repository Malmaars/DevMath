using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector2
    {
        public float x;
        public float y;

        public float Magnitude
        {
            //stelling van pythagoras.
            get { return (float)System.Math.Sqrt(x * x + y * y); } 
        }

        public Vector2 Normalized
        {
            //x en y delen door de magnitude
            get { return new Vector2(x / Magnitude, y / Magnitude); }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.x * rhs.x + lhs.y * rhs.y);
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            // Lerp is een plek tussen punt a en punt b, met t tussen 0 en 1. t is het percentage waar het is, bij a is 0%, b is 100%

            //bx - ax = x afstand
            //by - ay = y afstand
            //hier pakken we beide het percentage van en voegen dat op aan a en dan hebben we altijd een punt tussen a en b.

            float xDistance = b.x - a.x;
            float yDistance = b.y - a.y;
            float newX = a.x + (xDistance * t);
            float newY = a.y + (yDistance * t);

            return new Vector2(newX, newY);
        }


        public static float Angle(Vector2 lhs, Vector2 rhs)
        {
            /*float a = lhs.Magnitude;
            float b = rhs.Magnitude;
            float c = lhs.x * rhs.x + lhs.y * rhs.y;

            float angle = (float)System.Math.Cos(c / (a * b));
            return angle; */

            //Ok ik ben er klaar mee. De error waar ik nu al de hele dag mee bezig was bleek
            //dit te zijn. ik snap nog steeds niet wat er fout was aan de vorige formule >:(

            Vector2 v = lhs - rhs;
            return -(float)Math.Atan2(v.x, v.y) - (0.5f * (float)Math.PI);
        }

        public static Vector2 DirectionFromAngle(float angle)
        {
            float Vy = (float)System.Math.Sin(DevMath.DegToRad(angle));
            float Vx = (float)System.Math.Sin(DevMath.DegToRad(angle));

            return new Vector2(Vx, Vy);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public static Vector2 operator *(Vector2 lhs, float scalar)
        {
            return new Vector2(scalar * lhs.x, scalar * lhs.y);
        }

        public static Vector2 operator /(Vector2 lhs, float scalar)
        {
            return new Vector2((lhs.x / scalar), (lhs.y / scalar));
        }
    }
}
