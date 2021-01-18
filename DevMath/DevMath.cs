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
            float Distance = 0;
            float velocity = startVelocity;
            for(int i = 0; i < time; i++)
            {
                Distance += velocity;
                velocity += acceleration;
            }
            return Distance;
        }

        public static float Clamp(float value, float min, float max)
        {
            if(value < min)
            {
                return min;
            }

            if(value > max)
            {
                return max;
            }

            return value;
        }

        public static float RadToDeg(float angle)
        {
            return (float)(angle * (180 / System.Math.PI));
        }

        public static float DegToRad(float angle)
        {
            return (float)(angle * (System.Math.PI / 180));
        }
    }
}
