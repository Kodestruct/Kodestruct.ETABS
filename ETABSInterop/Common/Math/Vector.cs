using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kodestruct.ETABS.Interop.Common.Mathematics
{
    /// <summary>
    /// Vector4 class is used to store vector 
    /// and contain method to handle the vector
    /// </summary>
    public class Vector4
    {
        #region Class member variables and properties
        /// <summary>
        /// The coordinate x value
        /// </summary>
        private double m_x;

        /// <summary>
        /// The coordinate y value
        /// </summary>
        private double m_y;

        /// <summary>
        /// The coordinate z value
        /// </summary>
        private double m_z;

        /// <summary>
        /// The coordinate w value
        /// </summary>
        private double m_w = 1.0f;

        /// <summary>
        /// The coordinate x value
        /// </summary>
        public double X
        {
            get
            {
                return m_x;
            }
            set
            {
                m_x = value;
            }
        }

        /// <summary>
        ///The coordinate y value 
        /// </summary>
        public double Y
        {
            get
            {
                return m_y;
            }
            set
            {
                m_y = value;
            }
        }

        /// <summary>
        /// The coordinate z value
        /// </summary>
        public double Z
        {
            get
            {
                return m_z;
            }
            set
            {
                m_z = value;
            }
        }

        /// <summary>
        /// The coordinate w value
        /// </summary>
        public double W
        {
            get
            {
                return m_w;
            }
            set
            {
                m_w = value;
            }
        }
        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        public Vector4(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// constructor, transform Point3D to vector
        /// </summary>
        public Vector4(Point3D v)
        {
            this.X = (double)v.X;
            this.Y = (double)v.Y;
            this.Z = (double)v.Z;
        }


        /// <summary>
        /// constructor, transform 2 Point3D 's to vector
        /// </summary>
        public Vector4(Point3D vStart, Point3D vEnd)
        {
            this.X = (double)vEnd.X - (double)vStart.X;
            this.Y = (double)vEnd.Y - (double)vStart.Y;
            this.Z = (double)vEnd.Z - (double)vStart.Z;
        }

        /// <summary>
        /// add two vectors
        /// </summary>
        /// <param name="va">first vector</param>
        /// <param name="vb">second vector</param>
        /// <returns>add result of two vectors</returns>
        public static Vector4 operator +(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.X + vb.X, va.Y + vb.Y, va.Z + vb.Z);
        }

        /// <summary>
        /// subtraction of two vectors
        /// </summary>
        /// <param name="va">first vector</param>
        /// <param name="vb">second vector</param>
        /// <returns>subtraction of two vectors</returns>
        public static Vector4 operator -(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.X - vb.X, va.Y - vb.Y, va.Z - vb.Z);
        }

        /// <summary>
        /// get vector multiplied by a doubleing type value
        /// </summary>
        /// <param name="v">vector</param>
        /// <param name="factor">multiplier of doubleing type</param>
        /// <returns> the result vector </returns>
        public static Vector4 operator *(Vector4 v, double factor)
        {
            return new Vector4(v.X * factor, v.Y * factor, v.Z * factor);
        }

        /// <summary>
        /// get vector divided by a doubleing type value
        /// </summary>
        /// <param name="v">vector</param>
        /// <param name="factor">doubleing type value</param>
        /// <returns> vector divided by a doubleing type value</returns>
        public static Vector4 operator /(Vector4 v, double factor)
        {
            return new Vector4(v.X / factor, v.Y / factor, v.Z / factor);
        }


        /// <summary>
        /// aequality of 2 vectors
        /// </summary>
        /// <param name="va">first vector</param>
        /// <param name="vb">second vector</param>
        /// <returns>add result of two vectors</returns>
        public static bool operator ==(Vector4 va, Vector4 vb)
        {
            if (va.X == vb.X && va.Y ==vb.Y && va.Z == vb.Z)
            {
                return true;  
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Vector4 va, Vector4 vb)
        {
            if (va.X == vb.X && va.Y == vb.Y && va.Z == vb.Z)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// dot multiply this vector with another vector
        /// </summary>
        /// <param name="v">vector</param>
        /// <returns> dot multiply result of two vectors </returns>
        public double DotProduct(Vector4 v)
        {
            return (this.X * v.X + this.Y * v.Y + this.Z * v.Z);
        }

        /// <summary>
        /// cross multiply vector
        /// </summary>
        /// <param name="v">second vector</param>
        /// <returns> cross multiply result of two vectors</returns>
        public Vector4 CrossProduct(Vector4 v)
        {
            return new Vector4(this.Y * v.Z - this.Z * v.Y, this.Z * v.X
                - this.X * v.Z, this.X * v.Y - this.Y * v.X);
        }

        /// <summary>
        /// dot multiply two vectors
        /// </summary>
        /// <param name="va">first vector</param>
        /// <param name="vb">second vector</param>
        /// <returns> dot product result of two vectors</returns>
        public static double DotProduct(Vector4 va, Vector4 vb)
        {
            return (va.X * vb.X + va.Y * vb.Y + va.Z * vb.Z);
        }

        /// <summary>
        /// cross multiply two vectors
        /// </summary>
        /// <param name="va">first vector</param>
        /// <param name="vb">second vector</param>
        /// <returns> cross multiply result of two vectors</returns>
        public static Vector4 CrossProduct(Vector4 va, Vector4 vb)
        {
            return new Vector4(va.Y * vb.Z - va.Z * vb.Y, va.Z * vb.X
                - va.X * vb.Z, va.X * vb.Y - va.Y * vb.X);
        }

        /// <summary>
        /// convert to unit vector
        /// </summary>
        public void Normalize()
        {
            double length = GetLength();
            if (length == 0)
            {
                length = 1;
            }
            this.X /= length;
            this.Y /= length;
            this.Z /= length;
        }

        /// <summary>
        /// convert to unit vector
        /// </summary>
        public Vector4 GetNormalizedVector()
        {
            double length = GetLength();
            if (length == 0)
            {
                length = 1;
            }

            return new Vector4( this.X /= length,
                                this.Y /= length,
                                this.Z /= length);
        }

        /// <summary>
        /// calculate the length of vector
        /// </summary>
        /// <returns>length of this vector</returns>
        public double GetLength()
        {
            return (double)Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }
    };

    /// <summary>
    /// Matrix used to transform between ucs coordinate and world coordinate.
    /// </summary>
    public class Matrix4
    {
        #region MatrixType
        /// <summary>
        /// matrix algorithm
        /// </summary>
        public enum MatrixType
        {
            /// <summary>
            /// rotation matrix
            /// </summary>
            Rotation,

            /// <summary>
            /// translation matrix
            /// </summary>
            Translation,

            /// <summary>
            /// scale matrix
            /// </summary>
            Scale,

            /// <summary>
            /// rotation and translation mix matrix
            /// </summary>
            RotationAndTranslation,

            /// <summary>
            /// identity matrix
            /// </summary>
            Normal
        };
        private double[,] m_matrix = new double[4, 4];
        private MatrixType m_type;
        #endregion

        /// <summary>
        /// default constructor
        /// </summary>
        public Matrix4()
        {
            m_type = MatrixType.Normal;
            Identity();
        }

        /// <summary>
        /// constructor,rotation matrix,origin is at (0,0,0)
        /// </summary>
        /// <param name="xAxis">identity of x axis</param>
        /// <param name="yAxis">identity of y axis</param>
        /// <param name="zAxis">identity of z axis</param>
        public Matrix4(Vector4 xAxis, Vector4 yAxis, Vector4 zAxis)
        {
            m_type = MatrixType.Rotation;
            Identity();
            m_matrix[0, 0] = xAxis.X; m_matrix[0, 1] = xAxis.Y; m_matrix[0, 2] = xAxis.Z;
            m_matrix[1, 0] = yAxis.X; m_matrix[1, 1] = yAxis.Y; m_matrix[1, 2] = yAxis.Z;
            m_matrix[2, 0] = zAxis.X; m_matrix[2, 1] = zAxis.Y; m_matrix[2, 2] = zAxis.Z;
        }

        /// <summary>
        /// Constructor,translation matrix.
        /// </summary>
        /// <param name="origin">origin of ucs in world coordinate</param>
        public Matrix4(Vector4 origin)
        {
            m_type = MatrixType.Translation;
            Identity();
            m_matrix[3, 0] = origin.X; m_matrix[3, 1] = origin.Y; m_matrix[3, 2] = origin.Z;
        }

        /// <summary>
        /// rotation and translation matrix constructor
        /// </summary>
        /// <param name="xAxis">x Axis</param>
        /// <param name="yAxis">y Axis</param>
        /// <param name="zAxis">z Axis</param>
        /// <param name="origin">origin</param>
        public Matrix4(Vector4 xAxis, Vector4 yAxis, Vector4 zAxis, Vector4 origin)
        {
            m_type = MatrixType.RotationAndTranslation;
            Identity();
            m_matrix[0, 0] = xAxis.X; m_matrix[0, 1] = xAxis.Y; m_matrix[0, 2] = xAxis.Z;
            m_matrix[1, 0] = yAxis.X; m_matrix[1, 1] = yAxis.Y; m_matrix[1, 2] = yAxis.Z;
            m_matrix[2, 0] = zAxis.X; m_matrix[2, 1] = zAxis.Y; m_matrix[2, 2] = zAxis.Z;
            m_matrix[3, 0] = origin.X; m_matrix[3, 1] = origin.Y; m_matrix[3, 2] = origin.Z;
        }

        /// <summary>
        /// scale matrix constructor
        /// </summary>
        /// <param name="scale">scale factor</param>
        public Matrix4(double scale)
        {
            m_type = MatrixType.Scale;
            Identity();
            m_matrix[0, 0] = m_matrix[1, 1] = m_matrix[2, 2] = scale;
        }

        /// <summary>
        /// indexer of matrix
        /// </summary>
        /// <param name="row">row number</param>
        /// <param name="column">column number</param>
        /// <returns></returns>
        public double this[int row, int column]
        {
            get
            {
                return this.m_matrix[row, column];
            }
            set
            {
                this.m_matrix[row, column] = value;
            }
        }

        /// <summary>
        /// Identity matrix
        /// </summary>
        public void Identity()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.m_matrix[i, j] = 0.0f;
                }
            }
            this.m_matrix[0, 0] = 1.0f;
            this.m_matrix[1, 1] = 1.0f;
            this.m_matrix[2, 2] = 1.0f;
            this.m_matrix[3, 3] = 1.0f;
        }

        /// <summary>
        ///  multiply matrix left and right
        /// </summary>
        /// <param name="left">left matrix</param>
        /// <param name="right">right matrix</param>
        /// <returns>multiply result of two matrixes </returns>
        public static Matrix4 Multiply(Matrix4 left, Matrix4 right)
        {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = left[i, 0] * right[0, j] + left[i, 1] * right[1, j]
                        + left[i, 2] * right[2, j] + left[i, 3] * right[3, j];
                }
            }
            return result;
        }

        /// <summary>
        /// transform point use this matrix
        /// </summary>
        /// <param name="point">point needed to be transformed</param>
        /// <returns>transform result</returns>
        public Vector4 Transform(Vector4 point)
        {
            return new Vector4(point.X * this[0, 0] + point.Y * this[1, 0]
                + point.Z * this[2, 0] + point.W * this[3, 0],
                point.X * this[0, 1] + point.Y * this[1, 1]
                + point.Z * this[2, 1] + point.W * this[3, 1],
                point.X * this[0, 2] + point.Y * this[1, 2]
                + point.Z * this[2, 2] + point.W * this[3, 2]);
        }

        /// <summary>
        /// if m_matrix is a rotation matrix,this method can get the rotation inverse matrix.
        /// </summary>
        /// <returns>inversed rotation matrix</returns>
        public Matrix4 RotationInverse()
        {
            return new Matrix4(new Vector4(this[0, 0], this[1, 0], this[2, 0]),
                new Vector4(this[0, 1], this[1, 1], this[2, 1]),
                new Vector4(this[0, 2], this[1, 2], this[2, 2]));
        }

        /// <summary>
        /// if this m_matrix is a translation matrix,
        /// this method can get the translation inverse matrix.
        /// </summary>
        /// <returns>inversed translation matrix</returns>
        public Matrix4 TranslationInverse()
        {
            return new Matrix4(new Vector4(-this[3, 0], -this[3, 1], -this[3, 2]));
        }

        /// <summary>
        /// get inverse matrix
        /// </summary>
        /// <returns>inversed matrix</returns>
        public Matrix4 Inverse()
        {
            switch (m_type)
            {
                case MatrixType.Rotation:
                    return RotationInverse();

                case MatrixType.Translation:
                    return TranslationInverse();

                case MatrixType.RotationAndTranslation:
                    return Multiply(TranslationInverse(), RotationInverse());

                case MatrixType.Scale:
                    return ScaleInverse();

                case MatrixType.Normal:
                    return new Matrix4();

                default: return null;
            }
        }

        /// <summary>
        /// if m_matrix is a scale matrix,this method can get the scale inverse matrix.
        /// </summary>
        /// <returns> inversed scale matrix</returns>
        public Matrix4 ScaleInverse()
        {
            return new Matrix4(1 / m_matrix[0, 0]);
        }
    };
}
