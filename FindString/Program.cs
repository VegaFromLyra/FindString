using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };

            string str1 = "ball";
            int result1 = FindString1(input, str1);
            Console.WriteLine("Test case 1: {0} is present at {1}th index of input", str1, result1);

            string str2 = "dad";
            int result2 = FindString2(input, str2);
            Console.WriteLine("Test case 2: {0} is present at {1}th index of input", str2, result2);
        }

        static int FindString1(string[] input, string str)
        {
            if (input == null || str == null)
            {
                return -1;
            }

            bool[] flags = new bool[input.Length];

            int countOfStrings = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    flags[i] = false;
                }
                else
                {
                    flags[i] = true;
                    countOfStrings++;
                }
            }

            string[] subset = new string[countOfStrings];

            for (int i = 0, j = 0; i < input.Length; i++)
            {
                if (!String.IsNullOrEmpty(input[i]))
                {
                    subset[j] = input[i];
                    j++;
                }
            }

            int index = Find(subset, 0, subset.Length - 1, str);

            if (index == -1)
            {
                return -1;
            }

            int count = 0;
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    count++;

                    if (count == (index + 1))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }


        static int Find(string[] input, int start, int end, string str)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            string midValue = input[mid];

            if (str.Equals(midValue))
            {
                return mid;
            }
            else if (str.CompareTo(midValue) < 0)
            {
                return Find(input, start, mid - 1, str);
            }
            else
            {
                return Find(input, mid + 1, end, str);
            }
        }

        // A modified version of binary search
        static int FindString2(string[] input, string str)
        {
            if (input == null || str == null)
            {
                return -1;
            }

            return FindString2(input, 0, input.Length - 1, str);
        }

        static int FindString2(string[] input, int first, int last, string str)
        {
            if (last < first)
            {
                return -1;
            }

            int mid = (first + last) / 2;

            if (input[mid].Length == 0)
            {
                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {
                    // This can happen when input only
                    // has one string which is empty
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (left >= first && input[left].Length > 0)
                    {
                        mid = left;
                        break;
                    }
                    else if (right <= last && input[right].Length > 0)
                    {
                        mid = right;
                        break;
                    }

                    left--;
                    right++;
                }
            }

            if (str.Equals(input[mid]))
            {
                return mid;
            }
            else if (str.CompareTo(input[mid]) < 0)
            {
                return FindString2(input, first, mid - 1, str);
            }
            else
            {
                return FindString2(input, mid + 1, last, str);
            }
        }


    }
}
