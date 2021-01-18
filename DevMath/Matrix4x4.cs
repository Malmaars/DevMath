using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevMath
{
    public class Matrix4x4
    {
        public float[][] m = new float[4][] { new float[4], new float[4], new float[4], new float[4] };

        public Matrix4x4(float[][] paramM)
        {
            m = paramM; 
        }

        public static Matrix4x4 Identity
        {
            get
            {
                float[][] mat = new float[4][] { new float[4], new float[4], new float[4], new float[4] };
                for (int i = 0; i < 4; i++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if(k == i)
                        {
                            mat[i][k] = 1;
                        }

                        else
                        {
                            mat[i][k] = 0;
                        }
                    }
                }

                return new Matrix4x4(mat);
            }
        }

        public float Determinant
        {
            get
            {
                float[][] m3A = new float[3][] { new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m3B = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m3C = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] m3D = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] } };

                float A = m[0][0];
                float B = m[0][1];
                float C = m[0][2];
                float D = m[0][3];

                float deterA = M3Determinant(m3A);
                float deterB = M3Determinant(m3B);
                float deterC = M3Determinant(m3C);
                float deterD = M3Determinant(m3D);

                return A * deterA - B * deterB + C * deterC - D * deterD;
            }
        }

        public float M3Determinant(float[][] Matrix3)
        {
            float det2A = (Matrix3[0][0] * (Matrix3[1][1] * Matrix3[2][2] - Matrix3[1][2] * Matrix3[2][1]));
            float det2B = (Matrix3[0][1] * (Matrix3[1][0] * Matrix3[2][2] - Matrix3[1][2] * Matrix3[2][0]));
            float det2C = (Matrix3[0][2] * (Matrix3[1][0] * Matrix3[2][1] - Matrix3[1][1] * Matrix3[2][0]));

            return det2A + det2B + det2C;
        }

        public Matrix4x4 Inverse
        {
            get 
            {
                float[][] M00Mat = new float[3][] { new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] M01Mat = new float[3][] { new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[2][0], m[2][2], m[2][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] M02Mat = new float[3][] { new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[2][0], m[2][1], m[2][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] M03Mat = new float[3][] { new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[2][0], m[2][1], m[2][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };

                float[][] M10Mat = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[2][1], m[2][2], m[2][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] M11Mat = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[2][0], m[2][2], m[2][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] M12Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[2][0], m[2][1], m[2][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] M13Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[2][0], m[2][1], m[2][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };

                float[][] M20Mat = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[3][1], m[3][2], m[3][3] } };
                float[][] M21Mat = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[3][0], m[3][2], m[3][3] } };
                float[][] M22Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[3][0], m[3][1], m[3][3] } };
                float[][] M23Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[3][0], m[3][1], m[3][2] } };

                float[][] M30Mat = new float[3][] { new float[3] { m[0][1], m[0][2], m[0][3] }, new float[3] { m[1][1], m[1][2], m[1][3] }, new float[3] { m[2][1], m[2][2], m[2][3] } };
                float[][] M31Mat = new float[3][] { new float[3] { m[0][0], m[0][2], m[0][3] }, new float[3] { m[1][0], m[1][2], m[1][3] }, new float[3] { m[2][0], m[2][2], m[2][3] } };
                float[][] M32Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][3] }, new float[3] { m[1][0], m[1][1], m[1][3] }, new float[3] { m[2][0], m[2][1], m[2][3] } };
                float[][] M33Mat = new float[3][] { new float[3] { m[0][0], m[0][1], m[0][2] }, new float[3] { m[1][0], m[1][1], m[1][2] }, new float[3] { m[2][0], m[2][1], m[2][2] } };

                float m00 = M3Determinant(M00Mat) * (1/ Determinant);
                float m01 = -M3Determinant(M01Mat) * (1 / Determinant);
                float m02 = M3Determinant(M02Mat) * (1 / Determinant);
                float m03 = -M3Determinant(M03Mat) * (1 / Determinant);

                float m10 = -M3Determinant(M10Mat) * (1 / Determinant);
                float m11 = M3Determinant(M11Mat) * (1 / Determinant);
                float m12 = -M3Determinant(M12Mat) * (1 / Determinant);
                float m13 = M3Determinant(M13Mat) * (1 / Determinant);

                float m20 = M3Determinant(M20Mat) * (1 / Determinant);
                float m21 = -M3Determinant(M21Mat) * (1 / Determinant);
                float m22 = M3Determinant(M22Mat) * (1 / Determinant);
                float m23 = -M3Determinant(M23Mat) * (1 / Determinant);

                float m30 = -M3Determinant(M30Mat) * (1 / Determinant);
                float m31 = M3Determinant(M31Mat) * (1 / Determinant);
                float m32 = -M3Determinant(M32Mat) * (1 / Determinant);
                float m33 = M3Determinant(M33Mat) * (1 / Determinant);

                float[][] iM = new float[4][] { new float[4] { m00, m01, m02, m03 }, new float[4] { m10, m11, m12, m13 }, new float[4] { m20, m21, m22, m23 }, new float[4] { m30, m31, m32, m33 } };

                return new Matrix4x4(iM);

            }
        }

        public static Matrix4x4 Translate(Vector3 translation)
        {
            Matrix4x4 tempM = Identity;

            tempM.m[0][3] = translation.x;
            tempM.m[1][3] = translation.y;
            tempM.m[2][3] = translation.z;

            return tempM;
        }

        public static Matrix4x4 Rotate(Vector3 rotation)
        {
            //Er zijn 2 manieren om deze te berekenen
            throw new NotImplementedException();
        }

        public static Matrix4x4 RotateX(float rotation)
        {
            Matrix4x4 tempM = Identity;

            tempM.m[1][1] = (float)System.Math.Cos(rotation);
            tempM.m[1][2] = (float)System.Math.Asin(rotation);
            tempM.m[2][1] = (float)System.Math.Sin(rotation);
            tempM.m[2][2] = (float)System.Math.Cos(rotation);

            return tempM;

        }

        public static Matrix4x4 RotateY(float rotation)
        {
            Matrix4x4 tempM = Identity;

            tempM.m[0][0] = (float)System.Math.Cos(rotation);
            tempM.m[0][2] = (float)System.Math.Asin(rotation);
            tempM.m[2][0] = (float)System.Math.Sin(rotation);
            tempM.m[2][2] = (float)System.Math.Cos(rotation);

            return tempM;
        }

        public static Matrix4x4 RotateZ(float rotation)
        {
            Matrix4x4 tempM = Identity;

            tempM.m[0][0] = (float)System.Math.Cos(rotation);
            tempM.m[0][1] = (float)System.Math.Asin(rotation);
            tempM.m[1][0] = (float)System.Math.Sin(rotation);
            tempM.m[1][1] = (float)System.Math.Cos(rotation);

            return tempM;
        }

        public static Matrix4x4 Scale(Vector3 scale)
        {
            Matrix4x4 tempM = Identity;

            tempM.m[0][0] = scale.x;
            tempM.m[1][1] = scale.y;
            tempM.m[2][2] = scale.z;

            return tempM;
        }

        public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs)
        {
            float[][] multiM = new float[4][]
            {
                new float[4]{
                    (lhs.m[0][0] * rhs.m[0][0] + lhs.m[0][1] * rhs.m[1][0] + lhs.m[0][2] * rhs.m[2][0] + lhs.m[0][3] * rhs.m[3][0]),
                    (lhs.m[1][0] * rhs.m[0][0] + lhs.m[1][1] * rhs.m[1][0] + lhs.m[1][2] * rhs.m[2][0] + lhs.m[1][3] * rhs.m[3][0]),
                    (lhs.m[2][0] * rhs.m[0][0] + lhs.m[2][1] * rhs.m[1][0] + lhs.m[2][2] * rhs.m[2][0] + lhs.m[2][3] * rhs.m[3][0]),
                    (lhs.m[3][0] * rhs.m[0][0] + lhs.m[3][1] * rhs.m[1][0] + lhs.m[3][2] * rhs.m[2][0] + lhs.m[3][3] * rhs.m[3][0])},
                new float[4]{
                    (lhs.m[0][0] * rhs.m[0][1] + lhs.m[0][1] * rhs.m[1][1] + lhs.m[0][2] * rhs.m[2][1] + lhs.m[0][3] * rhs.m[3][1]),
                    (lhs.m[1][0] * rhs.m[0][1] + lhs.m[1][1] * rhs.m[1][1] + lhs.m[1][2] * rhs.m[2][1] + lhs.m[1][3] * rhs.m[3][1]),
                    (lhs.m[2][0] * rhs.m[0][1] + lhs.m[2][1] * rhs.m[1][1] + lhs.m[2][2] * rhs.m[2][1] + lhs.m[2][3] * rhs.m[3][1]),
                    (lhs.m[3][0] * rhs.m[0][1] + lhs.m[3][1] * rhs.m[1][1] + lhs.m[3][2] * rhs.m[2][1] + lhs.m[3][3] * rhs.m[3][1])},
                new float[4]{
                    (lhs.m[0][0] * rhs.m[0][2] + lhs.m[0][1] * rhs.m[1][2] + lhs.m[0][2] * rhs.m[2][2] + lhs.m[0][3] * rhs.m[3][2]),
                    (lhs.m[1][0] * rhs.m[0][2] + lhs.m[1][1] * rhs.m[1][2] + lhs.m[1][2] * rhs.m[2][2] + lhs.m[1][3] * rhs.m[3][2]),
                    (lhs.m[2][0] * rhs.m[0][2] + lhs.m[2][1] * rhs.m[1][2] + lhs.m[2][2] * rhs.m[2][2] + lhs.m[2][3] * rhs.m[3][2]),
                    (lhs.m[3][0] * rhs.m[0][2] + lhs.m[3][1] * rhs.m[1][2] + lhs.m[3][2] * rhs.m[2][2] + lhs.m[3][3] * rhs.m[3][2])},
                new float[4]{
                    (lhs.m[0][0] * rhs.m[0][3] + lhs.m[0][1] * rhs.m[1][3] + lhs.m[0][2] * rhs.m[2][3] + lhs.m[0][3] * rhs.m[3][3]),
                    (lhs.m[1][0] * rhs.m[0][3] + lhs.m[1][1] * rhs.m[1][3] + lhs.m[1][2] * rhs.m[2][3] + lhs.m[1][3] * rhs.m[3][3]),
                    (lhs.m[2][0] * rhs.m[0][3] + lhs.m[2][1] * rhs.m[1][3] + lhs.m[2][2] * rhs.m[2][3] + lhs.m[2][3] * rhs.m[3][3]),
                    (lhs.m[3][0] * rhs.m[0][3] + lhs.m[3][1] * rhs.m[1][3] + lhs.m[3][2] * rhs.m[2][3] + lhs.m[3][3] * rhs.m[3][3])}
            };


            return new Matrix4x4(multiM);
        }

        public static Vector4 operator *(Matrix4x4 lhs, Vector4 rhs)
        {
            float x = rhs.x * lhs.m[0][0] + rhs.x * lhs.m[0][1] + rhs.x * lhs.m[0][2] + rhs.x * lhs.m[0][3];
            float y = rhs.y * lhs.m[1][0] + rhs.y * lhs.m[1][1] + rhs.y * lhs.m[1][2] + rhs.y * lhs.m[1][3];
            float z = rhs.z * lhs.m[2][0] + rhs.z * lhs.m[2][1] + rhs.z * lhs.m[2][2] + rhs.z * lhs.m[2][3];
            float w = rhs.w * lhs.m[3][0] + rhs.w * lhs.m[3][1] + rhs.w * lhs.m[3][2] + rhs.w * lhs.m[3][3];

            return new Vector4(x, y, z, w);
        }
    }
}
