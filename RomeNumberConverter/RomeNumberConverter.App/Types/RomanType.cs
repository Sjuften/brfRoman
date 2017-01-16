using System;
using System.Collections;
using System.Collections.Generic;
using RomeNumberConverter.App.Interfaces;

namespace RomeNumberConverter.App
{

    public class RomanType : IConverter
    {
        private enum RomanDigit
        {
            I = 1,
            V = 5,
            X = 10,
            L = 50,
            C = 100,
            D = 500,
            M = 1000
        }
        public string Convert(string input) => ConvertToRoman(input.ToUpper());
        private string ConvertToRoman(string roman)
        {
            //There is very little information that suggests that the system originally had a notation for zero.
            //However, the letter N has been used to represent zero in a text from around 725AD. This will be used in the algorithm.
            // Rule 7
            roman = roman.ToUpper().Trim();
            if (roman == "N") return 0.ToString();

            // Rule 4
            //The numerals that represent numbers beginning with a '5' (V, L and D) may only appear once in each Roman numeral.
            //This rule permits XVI but not VIV.
            if (roman.Split('V').Length > 2 ||
                roman.Split('L').Length > 2 ||
                roman.Split('D').Length > 2)
                //The numerals that represent numbers beginning with a '5'(V, L and D) may only appear once in each Roman numeral.
                //This rule permits XVI but not VIV.
                return "input is not valid - according to rule 4";
            //throw new ArgumentException("Rule 4");

            // Rule 1
            //A single letter may be repeated up to three times consecutively with each occurrence of the value being additive.
            //This means that I is one, II means two and III is three. However, IIII is incorrect for four.
            int count = 1;
            char last = 'Z';
            foreach (char numeral in roman)
            {
                // Valid character?
                if ("IVXLCDM".IndexOf(numeral) == -1)
                    throw new ArgumentException("Invalid numeral");

                // Duplicate?
                if (numeral == last)
                {
                    count++;
                    if (count == 4)
                        //A single letter may be repeated up to three times consecutively with each occurrence of the value being additive.
                        //This means that I is one, II means two and III is three. However, IIII is incorrect for four.
                        return "input is not valid - according to rule 1";
                    //throw new ArgumentException("Rule 1");
                }
                else
                {
                    count = 1;
                    last = numeral;
                }
            }

            // Create an ArrayList containing the values
            int ptr = 0;
            ArrayList values = new ArrayList();
            int maxDigit = 1000;
            while (ptr < roman.Length)
            {
                // Base value of digit
                char numeral = roman[ptr];
                int digit = (int)Enum.Parse(typeof(RomanDigit), numeral.ToString());

                // Rule 3
                if (digit > maxDigit)
                    //A small-value numeral may be placed to the left of a larger value.
                    //Where this occurs, for example IX, the smaller numeral is subtracted from the larger.
                    //This means that IX is nine and IV is four. 
                    //The subtracted digit must be at least one tenth of the value of the larger numeral and must be either I, X or C.
                    //Accordingly, ninety-nine is not IC but rather XCIX. The XC part represents ninety and the IX adds the nine.
                    //In addition, once a value has been subtracted from another, no further numeral or pair may match or exceed the subtracted value.
                    //This disallows values such as MCMD or CMC.
                    return "Input is not valid - According to rule 3";
                //throw new ArgumentException("Rule 3");

                // Next digit
                int nextDigit = 0;
                if (ptr < roman.Length - 1)
                {
                    char nextNumeral = roman[ptr + 1];
                    nextDigit = (int)Enum.Parse(typeof(RomanDigit), nextNumeral.ToString());

                    if (nextDigit > digit)
                    {
                        if ("IXC".IndexOf(numeral) == -1 ||
                            nextDigit > (digit * 10) ||
                            roman.Split(numeral).Length > 3)
                            //A small-value numeral may be placed to the left of a larger value.
                            //Where this occurs, for example IX, the smaller numeral is subtracted from the larger.
                            //This means that IX is nine and IV is four. 
                            //The subtracted digit must be at least one tenth of the value of the larger numeral and must be either I, X or C.
                            //Accordingly, ninety-nine is not IC but rather XCIX. The XC part represents ninety and the IX adds the nine.
                            //In addition, once a value has been subtracted from another, no further numeral or pair may match or exceed the subtracted value.
                            //This disallows values such as MCMD or CMC.
                            return "Input is not valid - According to rule 3";
                        //throw new ArgumentException("Rule 3");

                        maxDigit = digit - 1;
                        digit = nextDigit - digit;
                        ptr++;
                    }
                }

                values.Add(digit);

                // Next digit
                ptr++;
            }

            // Rule 5
            for (int i = 0; i < values.Count - 1; i++)
                if ((int)values[i] < (int)values[i + 1])
                    //The fourth rule compares the size of value of each the numeral as read from left to right.
                    //The value must never increase from one letter to the next.
                    //Where there is a subtractive numeral, this rule applies to the combined value of the two numerals involved in the subtraction
                    //when compared to the previous letter. This means that XIX is acceptable but XIM and IIV are not.
                    return "input is not valid - according to rule 5";
            //throw new ArgumentException("Rule 5");

            // Rule 2
            int total = 0;
            foreach (int digit in values)
                total += digit;

            return total.ToString();
        }


    }
}
