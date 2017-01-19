using System;
using static RomeNumberConverter.App.Enums.ConverterTypes;

namespace RomeNumberConverter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is a rome/number value converter");
            Console.WriteLine("------------");
            Console.WriteLine();
            while (true)
            {

                Console.WriteLine("Enter a number(A roman value or number value)");
                var input = Console.ReadLine().Trim();
                var result = ConverterFactory.Get(input, Converters.RomanDecimal).GetResult();
                Console.WriteLine("The converted result");
                Console.WriteLine($"the Input: {input} is converted to: {result}");
            }
        }
    }
}
