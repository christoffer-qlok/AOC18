using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC18
{
    internal class Map
    {
        public int[][] Grid { get; set; }
        public Coord CurrentPos { get; set; }
        public HashSet<Coord> Dug { get; set; } = new HashSet<Coord>();
        public HashSet<Coord> Visited { get; set; } = new HashSet<Coord>();

        public Map() 
        {
            const int size = 1000;
            Grid = new int[size][];
            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = new int[size];
            }

            CurrentPos = new Coord(Grid.Length/2, Grid[0].Length/2);
            DigCurrent();
        }

        public void Dig(string[] lines)
        {
            foreach (string line in lines)
            {
                var parts = line.Split(' ');
                var dir = Coord.ParseDirection(parts[0]);
                var len = int.Parse(parts[1]);

                for (int i = 0; i < len; i++)
                {
                    CurrentPos += dir;
                    DigCurrent();
                }
            }
        }

        private void DigCurrent()
        {
            Grid[CurrentPos.Y][CurrentPos.X] = 1;
            Dug.Add(CurrentPos);
        }

        public void NavigateConnected(Coord start)
        {
            var stack = new Stack<Coord>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (Visited.Contains(current)) continue;
                Visited.Add(current);
                foreach (var neighbour in GetNeighbours(current))
                {
                    if(!Visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                    }
                }
            }
        }

        private Coord[] GetNeighbours(Coord pos)
        {
            int maxY = Grid.Length - 1;
            int maxX = Grid[0].Length - 1;

            var directions = new Coord[] { new Coord(1, 0), new Coord(-1, 0), new Coord(0, 1), new Coord(0, -1) };
            var res = new List<Coord>();
            foreach (var direction in directions)
            {
                var newCoord = pos.Move(direction);

                if (newCoord.X < 0 || newCoord.X > maxX || newCoord.Y < 0 || newCoord.Y > maxY)
                {
                    continue; 
                }

                if(!Dug.Contains(newCoord))
                {
                    res.Add(newCoord);
                }
            }
            return res.ToArray();
        }

        public void PrintMap()
        {
            for (int y = 0; y < Grid.Length; y++)
            {
                for (int x = 0; x < Grid[0].Length; x++)
                {
                    var pos = new Coord(y, x);
                    if (Grid[pos.Y][pos.X] == 1 || (Visited.Count() > 0 && !Visited.Contains(pos)))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
