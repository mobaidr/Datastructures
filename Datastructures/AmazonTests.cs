using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class AmazonTests
    {

        public static void AllSubArrays(int sum, int digits)
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] sresult = new int[digits];

          
            foreach (var collection in GenerateCollectionFor(0, array, sresult, sum, digits) )
            {
                Console.WriteLine(string.Join(" ", collection));
            }

            Console.WriteLine("...DONE...");

            IEnumerable<IEnumerable<int>> GenerateCollectionFor(int startingIndex, int[] sArray, int[] resultArray, int remainingSum, int remainingDigits)
            {
                int resultIndex = digits - remainingDigits;
                int lastIndex = sArray.Length - remainingDigits;

                if (remainingDigits == 1)
                {
                    for (int i = startingIndex; i < lastIndex; i++)
                    {
                        if (remainingSum == sArray[i])
                        {
                            resultArray[resultIndex] = remainingSum;
                            yield return resultArray;
                        }
                    }
                }
                else
                {
                    for (int i = startingIndex; i < lastIndex; i++)
                    {
                        sresult[resultIndex] = sArray[i];

                        foreach (var collection in GenerateCollectionFor(i + 1, sArray, resultArray, remainingSum - sArray[i], remainingDigits - 1))
                            yield return collection;
                    }
                }
            }
        }


        public static void MaximumSubArray_v2()
        {
            //KADANE Algorithm
            //var array = new int[] { -1, -2, 3, -4, -5, 6 };
            var array = new int[] { 2, -6, -2, -33, -4, 1 };

            var result = MaximumSubArraySum(array);

            Console.WriteLine($"Max Continuous sum is {result.sum} [{result.start_index},{result.end_index}]");

            (int sum, int start_index, int end_index) MaximumSubArraySum(int[] a)
            {
                int max_so_far = a[0];
                int max_ending_here = 0;
                int start_index, end_index, s;
                start_index = end_index = s = 0;


                for (int i = 0; i < a.Length; i++)
                {
                    max_ending_here += a[i];

                    if (max_ending_here > max_so_far)
                    {
                        max_so_far = max_ending_here;
                        start_index = s;
                        end_index = i;
                    }

                    if (max_ending_here < 0)
                    {
                        s = i + 1;
                        max_ending_here = 0;
                    }
                }

                return (max_so_far, start_index, end_index);
            }
        }


        public static void MaximumSubArray()
        {
            var array = new int[] { -1, -2, 3, 4, -5, 6 };

            var result = MaxSubrraySum(array);

            Console.WriteLine($"Max Continuous sum is {result}");

            int MaxSubrraySum(int[] arr)
            {
                int size = arr.Length;
                int max_so_far, curr_max;
                max_so_far = curr_max = arr[0];

                for (int i = 1; i < size; i++)
                {
                    curr_max = Math.Max(arr[i], curr_max + arr[i]);
                    max_so_far = Math.Max(max_so_far, curr_max);
                }

                return max_so_far;
            }
        }

        public static void StringCompression()
        {
            string inputStr = "aaaaaaaaaBBBCCCCC";
            var inputArray = inputStr.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int index = -1;
            int count;

            while (index < inputArray.Length)
            {
                count = 1;
                var checkChar = inputArray[++index];

                while (++index < inputArray.Length && checkChar == inputArray[index])
                    count++;

                sb.Append($"{checkChar}{count}");

                if (index < inputArray.Length)
                    index--;
                else
                    break;
            }

            Console.WriteLine(sb);
        }
    }
}
