using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal struct Coord
    {
        public long X;
        public long Y;

        public Coord(long y, long x)
        {
            X = x;
            Y = y;
        }

        public Coord Move(Coord direction)
        {
            return new Coord(Y + direction.Y, X + direction.X);
        }

        public override string ToString()
        {
            return $"({Y},{X})";
        }

        public long Dist(Coord c)
        {
            return Math.Abs(X - c.X) + Math.Abs(Y - c.Y);
        }

        public static Coord ParseDirection(string code)
        {
            char dir = code[code.Length - 2];
            switch (dir)
            {
                case '2':
                    return new Coord(0, -1);
                case '0':
                    return new Coord(0, 1);
                case '3':
                    return new Coord(-1, 0);
                case '1':
                    return new Coord(1, 0);
                default:
                    throw new ArgumentException($"Bad direction {code}", nameof(code));
            }
        }

        public static Coord ParseDirectionOld(string dir)
        {
            switch (dir)
            {
                case "L":
                    return new Coord(0, -1);
                case "R":
                    return new Coord(0, 1);
                case "U":
                    return new Coord(-1, 0);
                case "D":
                    return new Coord(1, 0);
                default:
                    throw new ArgumentException($"Bad direction {dir}", nameof(dir));
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Coord coord &&
                   X == coord.X &&
                   Y == coord.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static Coord operator +(Coord c1, Coord c2)
        {
            return new Coord(c1.Y + c2.Y, c1.X + c2.X);
        }

        public static Coord operator *(long i, Coord c)
        {
            return new Coord(c.Y * i, c.X * i);
        }

        public static Coord operator *(Coord c, long i)
        {
            return new Coord(c.Y * i, c.X * i);
        }

        public static long operator *(Coord c1, Coord c2)
        {
            return (c1.X * c2.Y) - (c1.Y * c2.X);
        }

        public static bool operator ==(Coord c1, Coord c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Coord c1, Coord c2)
        {
            return !c1.Equals(c2);
        }
    }
}
