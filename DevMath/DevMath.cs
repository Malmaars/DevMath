using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class DevMath
    {
        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public static float DistanceTraveled(float startVelocity, float acceleration, float time)
        {
            throw new NotImplementedException();
        }

        public static float Clamp(float value, float min, float max)
        {
            throw new NotImplementedException();
        }

        public static float RadToDeg(float angle)
        {
            return angle / System.Math.PI * 180;
        }

        public static float DegToRad(float angle)
        {
            return angle / 180 * System.Math.PI;
        }
    }
}
