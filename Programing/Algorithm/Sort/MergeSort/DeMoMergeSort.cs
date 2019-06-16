using System;

public class DeMoMergeSort
{
	public int[] array;

	public void Sort(int[] array)
	{
		this.array = array;
		var tempArray = new int[array.Length];

		MergeSort(0, array.Length - 1, array, tempArray);
	}

	private void MergeSort(int start, int end, int[] originalArray, int[] tempArray)
	{
		if (end <= start)
		{
			return;
		}

		int middle = start + (end - start) / 2;
		MergeSort(start, middle, originalArray, tempArray);
		MergeSort(middle + 1, end, originalArray, tempArray);

		Merge(start, end, middle, originalArray, tempArray);
	}

	private void Merge(int start, int end, int middle, int[] originalArray, int[] tempArray)
	{
		for (var i = start; i <= end; i++)
		{
			tempArray[i] = array[i];
		}

		var j = start;
		var k = middle + 1;

		for (var i = start; i <= end; i++)
		{
			if (j > middle)
			{
				originalArray[i] = tempArray[k++];
			}
			else if (k > end)
			{
				originalArray[i] = tempArray[j++];
			}
			else if (tempArray[j] <= tempArray[k])
			{
				originalArray[i] = tempArray[j++];
			}
			else
			{
				originalArray[i] = tempArray[k++];
			}
		}
	}
}
