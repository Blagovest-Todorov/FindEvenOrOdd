
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intervalNums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            int startNumber = intervalNums[0];
            int endNumber = intervalNums[1];
            string criteria = Console.ReadLine();

            Func<int, int, List<int>> generateRangeOfNums = (s, e) =>
            {
                 List<int> nums = new List<int>();

                 for (int i = s; i <= e; i++)
                 {
                     nums.Add(i);
                 }

                 return nums;
            };

            List<int> numbers = generateRangeOfNums(startNumber, endNumber);

            Predicate<int> predicate = n => true; // (n % 2 == 0) => true;   // Predicate-> function  that returns bool value -> true or  false        

            if (criteria == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = n => n % 2 == 0;
            }

            //MyWhere(numbers, n => n % 2 == 0);
            ///MyWhere(numbers, predicate);
            Console.WriteLine(string.Join(" ", MyWhere(numbers, predicate)));

            static List<int> MyWhere(List<int> numbers, Predicate<int> predicate) 
            {
                List<int> newNumbers = new List<int>();

                foreach (var currNum in numbers)
                {
                    if (predicate(currNum))
                    {
                        newNumbers.Add(currNum);
                    }
                }

                return newNumbers;                
            }
        }        
    }
}

