using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public float Magnitude
        {
            get 
            { return System.Math.Sqrt(x * x + y * y + z * z); }
        }

        public Vector3 Normalized
        {
            get { return new Vector3(x / Magnitude, y / Magnitude, z / Magnitude); }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.x, v.y, 0);
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z);
        }

        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3((lhs.y * rhs.z - lhs.z * rhs.y), (lhs.z * rhs.x - lhs.x * rhs.z), (lhs.x * rhs.y - lhs.y * rhs.x));
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            float xDistance = b.x - a.x;
            float yDistance = b.y - a.y;
            float zDistance = b.z - a.z;
            float newX = a.x + (xDistance * t);
            float newY = a.y + (yDistance * t);
            float newZ = a.z + (zDistance * t);

            return new Vector3(newX, newY, newZ);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public static Vector3 operator *(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar);
        }

        public static Vector3 operator /(Vector3 lhs, float scalar)
        {
            return new Vector3(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar);
        }
    }
}
