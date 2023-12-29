namespace AOC18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var map = new Map();
            map.Dig(lines);
            map.NavigateConnected(new Coord(0,0));


            int tiles = (map.Grid.Length * map.Grid[0].Length) - map.Visited.Count();
            Console.WriteLine(tiles);
        }
    }
}
