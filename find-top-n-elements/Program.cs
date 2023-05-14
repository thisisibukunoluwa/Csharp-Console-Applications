﻿
using System.Text.RegularExpressions;

public class Algo
{
    public static void Main()
    {

        getNMaxelements();
        // BubbleSort
        // Time complexity O(n^2) + O(n)
    }

     
        public static bool TryParseInt (string input, out int result)
        {
        result = default(int);
            try
            {
                return int.TryParse(input, out result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
    }

        public static bool TryParseIntArray(string input,out int[] result)
        {
             result = null;

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input is empty or Null");
                return false;
            }

            var elements = input.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries);

            if (!elements.Any())
            {
                Console.WriteLine("Input does not contain any elements");
                return false;
            }

            var parsedElements = new List<int>();

            foreach (var element in elements)
            {
                if (TryParseInt(element.Trim(), out var parsedElement))
                {
                    parsedElements.Add(parsedElement);
                }
                else
                {
                    Console.WriteLine($"Element '{element}' is not a valid integer");
                    return false;
                }
            }
            result = parsedElements.ToArray();

            return true;
        }

     public static bool TryGetValidN(int[] arr, string input, out int result)
       {
 
        result = 0;

        if (!TryParseInt(input,out result))
        {
            Console.WriteLine("Input is not a valid integer");
            return false;
        }
        if (result < 1 )
        {
            Console.WriteLine("Input must be greater than zero");
            return false;
        }
        if (result > arr.Length)
        {
            Console.WriteLine($"Input can not be greater than the length of the array ({arr.Length})");
            return false;
        }
        return true;
    }

    internal static int[] GetArray()
        {

        while (true) 
        {
            Console.WriteLine("Enter the numbers you want to input in a comma separated string");

            var input = Console.ReadLine();

           if (TryParseIntArray(input,out var arr))
            {
                return arr;
            }
            Console.WriteLine("Please try again:");
        }

    }

    internal static int GetN(int[] arr)
        {
           while (true)
            {
                 Console.WriteLine("Enter a number of max elements you want to find");

                 var input = Console.ReadLine();

                if (TryGetValidN(arr, input,out var n))
                {
                    return n;
                }
                 Console.WriteLine("Please try again");
            }
        }


        public static void getNMaxelements()
        {
        try
        {
            int i, j, n, temp;

            int[] result;

            int[] arr;

            arr = Algo.GetArray();

            n = Algo.GetN(arr);

            List<int> fromarr = arr.ToList();

            List<int> nMaxElementsList = new List<int>(n);

            for (i = 0; i < n; i++)
            {
                int maxIndex = i;
                for (j = i + 1; j < fromarr.Count; j++)
                {
                    if (fromarr[j] > fromarr[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                nMaxElementsList.Add(fromarr[maxIndex]);

                fromarr[maxIndex] = fromarr[i];

            }
            result = nMaxElementsList.ToArray();

            Console.WriteLine($"The '{n}' maxElements from the array are");

            for (int k = 0; k < result.Length; k++)
            {
                Console.WriteLine(result[k]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
      }
}

// two exceptions to handle
//getn wouldnt get the value of the array until it has reached get max elements

// the error handling should happen where we are assigning 