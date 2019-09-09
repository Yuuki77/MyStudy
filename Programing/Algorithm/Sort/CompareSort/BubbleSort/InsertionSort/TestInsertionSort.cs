public class TestInsertionSort
{
	public void Sort(int[] array)
	{

		for (var i = 0; i < array.Length; i++)
		{
			for (var j = i; j > 0; j--)
			{
				if (array[j] < array[j - 1])
				{
					var temp = array[j];
					array[j] = array[j - 1];
					array[j - 1] = temp;
				}
				else
				{
					break;
				}
			}
		}
	}
}