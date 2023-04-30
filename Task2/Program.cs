using System;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nailsQuantity = int.Parse(Console.ReadLine());

            var nails = new Nail[nailsQuantity];
            for (var i = 0; i < nailsQuantity; i++)
            {
                var coordinates = Console.ReadLine()
                    .Split(" ")
                    .Select(x => int.Parse(x))
                    .ToArray();
                nails[i] = new Nail(coordinates[0], coordinates[1]); 
            }

            var orderedNails = nails.OrderByDescending(n => n.Y);

            var allX = orderedNails.Select(n => n.X).Distinct().OrderBy(x => x);
            var allY = orderedNails.Select(n => n.Y).Distinct().OrderBy(y => y);

            var maxSquare = 0UL;
            foreach(var level in allY)
            {
                var allNailsOfLevel = orderedNails.Where(n => n.Y == level).OrderByDescending(n => n.X);
                var leftNail = allNailsOfLevel.Last();

                foreach(var rightNail in allNailsOfLevel)
                {
                    if (leftNail == rightNail)
                        continue;

                    var topRightNail = orderedNails.FirstOrDefault(n => n.Y > rightNail.Y && n.X == rightNail.X);
                    var topLeftNail = orderedNails.FirstOrDefault(n => n.Y > leftNail.Y && n.X == leftNail.X);

                    if (topRightNail != null && topLeftNail != null)
                    {
                        //Console.WriteLine($"{(ulong)(rightNail.X - leftNail.X)}; {(ulong)(topRightNail.Y - rightNail.Y)}");
                        var nextSquare = (ulong)(rightNail.X - leftNail.X) * (ulong)(topRightNail.Y - rightNail.Y);
                        if (nextSquare > maxSquare)
                            maxSquare = nextSquare;
                    }
                }
            }

            Console.WriteLine(maxSquare);
        }
    }

    public class Nail
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Nail (int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"X = {X}; Y = {Y}";
    }
}
