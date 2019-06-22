using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lineAralgebra
{
	class Program
	{
		static void Main(string[] args)
		{
			// var array = new int[] { 1, 5, 22, 111 };
			var array = new int[] { 1, 5, 111, 22 };
			var sort = new MergeSort();
			sort.Sort(array);
			// var target = 111;
			// var ans = Find(array, target, 0, array.Length);
		}

		private static int Find(int[] array, int target, int lo, int hi)
		{
			if (hi <= lo) return -1;

			var middle = lo + (hi - lo) / 2;

			if (array[middle] == target) return middle;
			else if (array[middle] > target)
			{
				return Find(array, target, lo, middle);
			}
			else
			{
				return Find(array, target, middle + 1, hi);
			}
		}
	}
}