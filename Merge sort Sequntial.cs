using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Merge_sort
{
    public class Program
    {
        public static void Main(string[] args)
        {
          // Create new stopwatch.
          int range = 10;
        Stopwatch stopwatch = new Stopwatch();

        // Begin timing.

          List<int> unsorted = new List<int>();
          List<int> sorted;
          List<int> unsorted2 = new List<int>();
          List<int> sorted2;

          Random random = new Random();

          Console.WriteLine("Original first array elements:" );
          for(int i = 0; i< range;i++){
              unsorted.Add(random.Next(0,100));
              Console.Write(unsorted[i]+" ");
          }
          Console.WriteLine();
          sorted = MergeSort(unsorted);
          Console.WriteLine("Sorted first array elements: ");
          foreach (int x in sorted)
          {
              Console.Write(x+" ");
          }
          Console.WriteLine();
          Console.WriteLine("Original second array elements:" );
          for(int i = 0; i< range;i++){
              unsorted2.Add(random.Next(0,100));
              Console.Write(unsorted2[i]+" ");
          }
          Console.WriteLine();
          stopwatch.Start();
          sorted2 = MergeSort(unsorted2);
          stopwatch.Stop();
          Console.WriteLine("Sorted second array elements: ");
          foreach (int x in sorted2)
          {
              Console.Write(x+" ");
          }

          Console.Write("\n");
          Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

        }


        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count>0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
