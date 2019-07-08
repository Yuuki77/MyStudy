using System;

public class BinarySearch
{

	public int Find(int[] array, int target)
	{

		return Find(array, target, 0, array.Length);
	}

	private int Find(int[] array, int target, int lo, int hi)
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

	public int Find2(int[] array, int target)
	{

		return Find2(array, target, 0, array.Length - 1);
	}

	private int Find2(int[] array, int target, int lo, int hi)
	{
		if (hi < lo) return lo;

		int middle = lo + (hi - lo) / 2;

		if (array[middle] == target) return middle;

		if (array[middle] > target)
		{
			return Find2(array, target, lo, middle - 1);
		}
		else
		{
			return Find2(array, target, middle + 1, hi);
		}
	}
}