using System;
using System.Collections.Generic;
using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App
{

    public class RomanType : IConverter
    {
        private Dictionary<char, int> RomanMap;
        public RomanType()
        {
            RomanMap = new Dictionary<char, int>()
             {        {'I', 1},
                      {'V', 5},
                      {'X', 10},
                      {'L', 50},
                      {'C', 100},
                      {'D', 500},
                      {'M', 1000}
            };
        }

        public string Convert(string input) => ConvertFromRoman(input.ToUpper());

        private string ConvertFromRoman(string input)
        {
            
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                    if (i + 1 < input.Length && RomanMap[input[i]] < RomanMap[input[i + 1]])
                    {
                        number -= RomanMap[input[i]];
                    }
                    else
                    {
                        number += RomanMap[input[i]];
                    }
            }
            return number.ToString();
        }

       
    }
}
