public class BubbleSort
{
	public void Sort(int[] array)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var isSorted = true;
			for (var j = 0; j < array.Length - i - 1; j++)
			{
				if (array[j + 1] < array[j])
				{
					var temp = array[j];
					array[j] = array[j + 1];
					array[j + 1] = temp;
					isSorted = false;
				}

			}

			if (isSorted) break;
		}
	}
}
