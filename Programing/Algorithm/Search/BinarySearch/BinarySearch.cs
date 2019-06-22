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

		if (middle == target) return middle;
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