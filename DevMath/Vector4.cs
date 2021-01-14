using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public float Magnitude
        {
            get
            { return System.Math.Sqrt(x * x + y * y + z * z + w * w); }
        }

        public Vector4 Normalized
        {
            get { return new Vector3(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude); }
        }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static implicit operator Vector4(Vector3 v)
        {
            return new Vector4(v.x, v.y, v.z, 0);
        }

        public static float Dot(Vector4 lhs, Vector4 rhs)
        {
            return (lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z + lhs.w * rhs.w);
        }

        public static Vector4 Lerp(Vector4 a, Vector4 b, float t)
        {
            float xDistance = b.x - a.x;
            float yDistance = b.y - a.y;
            float zDistance = b.z - a.z;
            float wDistance = b.w - a.w;
            float newX = a.x + (xDistance * t);
            float newY = a.y + (yDistance * t);
            float newZ = a.z + (zDistance * t);
            float newW = a.w + (wDistance * t);

            return new Vector4(newX, newY, newZ, newW);
        }

        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w + rhs.w);
        }

        public static Vector4 operator -(Vector4 v)
        {
            return new Vector4(-v.x, -v.y, -v.z, -v.w);
        }

        public static Vector4 operator *(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.x * scalar, lhs.y * scalar, lhs.z * scalar, lhs.w * scalar);
        }

        public static Vector4 operator /(Vector4 lhs, float scalar)
        {
            return new Vector4(lhs.x / scalar, lhs.y / scalar, lhs.z / scalar, lhs.w / scalar);
        }
    }
}
