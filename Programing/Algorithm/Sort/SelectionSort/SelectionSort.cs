using System;

public class SelectionSort
{
	public void Sort(int[] array)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var minIndex = i;
			for (var j = i + 1; j < array.Length; j++)
			{
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}

			Swap(minIndex, i, array);
		}
	}

	private void Swap(int minIndex, int i, int[] array)
	{
		var temp = array[minIndex];
		array[minIndex] = array[i];
		array[i] = temp;
	}
}