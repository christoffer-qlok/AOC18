using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Map
    {
        public Coord CurrentPos { get; set; }
        public Coord Inside { get; set; }
        public List<Coord> Corners { get; set; }
        public HashSet<Coord> Visited { get; set; } = new HashSet<Coord>();

        public Map()
        {
            CurrentPos = new Coord(0, 0);
        }

        public void Dig(string[] lines)
        {
            Corners = new List<Coord>(lines.Length + 1)
            {
                CurrentPos
            };
            foreach (string line in lines)
            {
                var parts = line.Split(' ');
                var dir = Coord.ParseDirection(parts[2]);
                var len = ParseLength(parts[2]);
                CurrentPos += len * dir;
                Corners.Add(CurrentPos);
            }
        }

        public void DigOld(string[] lines)
        {
            Corners = new List<Coord>(lines.Length + 1);
            foreach (string line in lines)
            {
                var parts = line.Split(' ');
                var dir = Coord.ParseDirectionOld(parts[0]);
                var len = int.Parse(parts[1]);

                for (int i = 1; i <= len; i++)
                {
                    Visited.Add(CurrentPos + (i * dir));
                }

                CurrentPos += len * dir;
                Corners.Add(CurrentPos);
            }
        }

        public static long ParseLength(string code)
        {
            code = code.Trim('(', ')').TrimStart('#');
            code = code.Substring(0, code.Length - 1);
            return long.Parse(code, System.Globalization.NumberStyles.HexNumber);
        }

        public long GaussianArea()
        {
            long area = 0;
            for (int i = 0; i < Corners.Count(); i++)
            {
                var next = (i + 1) % Corners.Count();
                area += Corners[i] * Corners[next];
            }
            return area/2;
        }

        public long PathLength()
        {
            long path = 0;
            for (int i = 0; i < Corners.Count(); i++)
            {
                var next = (i + 1) % Corners.Count();
                var dist = Corners[i].Dist(Corners[next]);
                path += dist;
            }
            return path;
        }

        public long CompensatedArea()
        {
            var res = PathLength() / 2 + GaussianArea() + 1;
            return res;
        }
    }
}
