using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class SortAlgorithm<T> where T : IComparable<T>
{
	static public void MergeSort(T[] ar)
	{
		if (ar.Length < 2)
			return;

		T[] leftAr = new T[ar.Length / 2];
		T[] rightAr = new T[ar.Length - leftAr.Length];

		Array.Copy(ar, 0, leftAr, 0, leftAr.Length);
		Array.Copy(ar, leftAr.Length, rightAr, 0, rightAr.Length);

		MergeSort(leftAr);
		MergeSort(rightAr);

		Merge(ar, leftAr, rightAr);
	}

	static private void Merge(T[] ar, T[] leftAr, T[] rightAr)
	{
		int l = 0,
		r = 0,
		i = 0;
		while (l < leftAr.Length && r < rightAr.Length && i < ar.Length)
		{
			if (leftAr[l].CompareTo(rightAr[r]) <= 0)
				ar[i++] = leftAr[l++];
			else
				ar[i++] = rightAr[r++];
		}

		if (l < leftAr.Length)
			Array.Copy(leftAr, l, ar, i, leftAr.Length - l);
		else
			Array.Copy(rightAr, r, ar, i, rightAr.Length - r);
	}


	static public async Task MergeSortAsync(T[] ar, int thNum = 4)
	{
		if (ar.Length < 2)
			return;

		T[] leftAr = new T[ar.Length / 2];
		T[] rightAr = new T[ar.Length - leftAr.Length];

		Array.Copy(ar, 0, leftAr, 0, leftAr.Length);
		Array.Copy(ar, leftAr.Length, rightAr, 0, rightAr.Length);

		if (thNum > 0)
		{
			Task leftSort = MergeSortAsync(leftAr);
			Task rightSort = MergeSortAsync(rightAr);

			await leftSort;
			await rightSort;

			thNum -= 2;
		}
		else
		{
			MergeSort(leftAr);
			MergeSort(rightAr);
		}

		Merge(ar, leftAr, rightAr);
	}
}

public class Program
{
	public void Main()
    {
			Stopwatch stopwatch = new Stopwatch();

				int[] ar = new int[] { 100, 1000, 2000, 3000, 4000, 9, 0 };
				Console.WriteLine("Original first array elements ");
				foreach(int i in ar)
					Console.Write(i+",");
				Console.WriteLine();
				// stopwatch.Start();

				Task sort = SortAlgorithm<int>.MergeSortAsync(ar);
				// stopwatch.Stop();
				// stopwatch.stop();
				Console.WriteLine("Sorted first array ");
				foreach(int i in ar)
					Console.Write(i+",");
					Console.WriteLine();
				sort.Wait();

				// foreach (int i in ar)
				// 	Console.WriteLine(i);
				//
				// Console.WriteLine();

				ar = new int[] { 93232, 12121, 712, 221, 212,12  };
				Console.WriteLine("Original second array elements ");
				foreach(int i in ar)
					Console.Write(i+",");
				Console.WriteLine();
				// stopwatch.start();
				stopwatch.Start();
				sort = SortAlgorithm<int>.MergeSortAsync(ar);
				sort.Wait();
				stopwatch.Stop();
				Console.WriteLine("Sorted second array ");
				foreach(int i in ar)
					Console.Write(i+",");
					Console.WriteLine();
				Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
    }
}
