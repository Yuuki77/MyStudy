using System;
using Xunit;

public class SortTest
{
	[Fact]
	public void SelectSort()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new SelectionSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void InsertionSort()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new InsertionSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Console.WriteLine("array[i]" + array[i]);
			Console.WriteLine("array[i + 1]" + array[i + 1]);
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}
}