using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var friendsQuantity = int.Parse(Console.ReadLine());

            var friends = new NumbersOfFriend[friendsQuantity];

            var firstNumbers = Console.ReadLine()
                    .Split(" ")
                    .Select(x => short.Parse(x))
                    .ToList();

            var multiplyNumbers = firstNumbers;

            for (var i = 1; i < friendsQuantity; i++)
            {
                var newNumbers = Console.ReadLine()
                    .Split(" ")
                    .Select(x => short.Parse(x));

                friends[i] = new NumbersOfFriend { Numbers = newNumbers.Distinct().ToList() };

                if (i < 1)
                    continue;

                multiplyNumbers = GetMultiplyNumbers(multiplyNumbers, friends[i].Numbers);
            }


            multiplyNumbers = multiplyNumbers.Distinct().ToList();


            Console.WriteLine(multiplyNumbers.Count);
        }

        private static List<short> GetMultiplyNumbers(List<short> a, List<short> b)
        {
            var multiplyNumbers = new List<short>();
            foreach (var numberFirstFriend in a)
                foreach (var numberSecondFriend in b)
                    multiplyNumbers.Add(numberFirstFriend + numberSecondFriend);

            return multiplyNumbers;
        }
    }

    public class NumbersOfFriend
    {
        public List<short> Numbers { get; set; }
    }
}
