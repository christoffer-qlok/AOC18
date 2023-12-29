namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var map = new Map();

            map.Dig(lines);
            Console.WriteLine($"Map done with num corners: {map.Corners.Count()}");

            Console.WriteLine($"Area: {map.CompensatedArea()}");
        }
    }
}
