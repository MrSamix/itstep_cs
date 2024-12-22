using System;

namespace _05_Overload_operators
{
    internal class Vector
    {
        private double x;
        private double y;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector operator *(Vector v, double num)
        {
            return new Vector(v.x * num, v.y * num);
        }

        public static double operator *(Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (ReferenceEquals(v1, v2))
                return true;
            if (ReferenceEquals(v1, null) || ReferenceEquals(v2, null))
                return false;
            return v1.x == v2.x && v1.y == v2.y;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            return !(v1 == v2);
        }

        public static explicit operator double(Vector v)
        {
            return v.Length();
        }

        public static implicit operator Vector(double num)
        {
            return new Vector(num, 0);
        }

        public static Vector operator ++(Vector v)
        {
            return new Vector(v.x + 1, v.y + 1);
        }

        public static Vector operator --(Vector v)
        {
            return new Vector(v.x - 1, v.y - 1);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y);
        }

        public static bool operator true(Vector v)
        {
            return v.x != 0 || v.y != 0;
        }

        public static bool operator false(Vector v)
        {
            return v.x == 0 && v.y == 0;
        }

        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return x;
                else if (index == 1)
                    return y;
                else
                    return -1;
            }
            set
            {
                if (index == 0)
                    x = value;
                else if (index == 1)
                    y = value;
                else
                    y = -1;
            }
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
