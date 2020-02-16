using System;

public class MergeSort
{

	public MergeSort()
	{
		// Sort();
	}

	public void Sort(int[] array)
	{
		var aux = new int[array.Length];
		Sort(0, array.Length - 1, array, aux);
	}

	public void Sort(int start, int end, int[] originalArray, int[] aux)
	{
		if (end <= start) return;
		var middle = start + (end - start) / 2;
		Sort(start, middle, originalArray, aux);
		Sort(middle + 1, end, originalArray, aux);
		Merge(start, middle, end, originalArray, aux);
	}

	private void Merge(int start, int middle, int end, int[] originalArray, int[] aux)
	{
		for (var i = start; i <= end; i++)
		{
			aux[i] = originalArray[i];
		}

		var j = start;
		var k = middle + 1;

		for (var i = start; i <= end; i++)
		{
			if (j > middle)
			{
				originalArray[i] = aux[k++];
			}
			else if (k > end)
			{
				originalArray[i] = aux[j++];
			}
			else if (aux[j] < aux[k])
			{
				originalArray[i] = aux[j++];
			}
			else
			{
				originalArray[i] = aux[k++];
			}
		}
	}
}