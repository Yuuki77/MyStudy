using System;

public class InsertionSort
{
	public void Sort(int[] array)
	{
		for (var i = 0; i < array.Length; i++)
		{
			for (var j = i; j > 0; j--)
			{
				if (array[j - 1] > array[j])
				{
					Exchange(j, j - 1, array);
				}
				else
				{
					break;
				}
			}
		}
	}

	private void Exchange(int i, int j, int[] array)
	{
		var temp = array[i];
		array[i] = array[j];
		array[j] = temp;
	}
}