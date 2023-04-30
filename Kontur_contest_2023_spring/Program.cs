using System;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysQuantity = int.Parse(Console.ReadLine());
            // Действительно, можно написать проще - Select(int.Parse())
            var brightnesses = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToArray();

            var picturesData = new PicturesData(brightnesses, daysQuantity);
            picturesData.FindMostContrasting();

            Console.WriteLine($"{picturesData.MaxBrightnessDay + 1} {picturesData.MinBrightnessDay + 1}"); 
        }

    }

    public class PicturesData
    {
        public int[] Brightnesses { get; set; }
        public int Quantity { get; set; }

        public int MaxBrightness { get; set; }
        public int MinBrightness { get; set; }

        public int MaxBrightnessDay { get; set; }
        public int MinBrightnessDay { get; set; }


        public bool IsProccessed { get; set; }

        public PicturesData(int[] brightness, int quantity)
        {
            Brightnesses = brightness;
            Quantity = quantity;
            MaxBrightness = int.MinValue;
            MinBrightness = int.MaxValue;
            IsProccessed = false;
        }

        public void FindMostContrasting()
        {
            for (var i = 0; i < Quantity; i++)
            {
                if (Brightnesses[i] >= MaxBrightness)
                {
                    MaxBrightness = Brightnesses[i];
                    MaxBrightnessDay = i;
                }
                if (Brightnesses[i] < MinBrightness)
                {
                    MinBrightness = Brightnesses[i];
                    MinBrightnessDay = i;
                }
            }
            IsProccessed = true;
        }

    }
}
