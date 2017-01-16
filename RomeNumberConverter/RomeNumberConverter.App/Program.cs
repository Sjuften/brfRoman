using System;

namespace RomeNumberConverter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a rome number converter");
            Console.WriteLine("------------");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter a number(A roman value or number value)");
                var number = Console.ReadLine().Trim();
                var typeForConvertion = TypeForConvertionFactory.GetType(number, new Parser());
                var result = typeForConvertion.Convert(number);
                Console.WriteLine("The converted result");
                Console.WriteLine($"the Input: {number} is converted to: {result}");
            }
        }
    }
}
