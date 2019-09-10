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
			// Console.WriteLine("array[i]" + array[i]);
			// Console.WriteLine("array[i + 1]" + array[i + 1]);
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void MergeSort()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new MergeSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void DemoMergeSort()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new DeMoMergeSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void BubbleSortTest()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new BubbleSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void InsertionSortTest()
	{
		var array = new int[] {
			4,1,0,11,3,12,33,1,10
		};

		var sort = new TestInsertionSort();
		sort.Sort(array);

		for (int i = 0; i < array.Length - 1; i++)
		{
			Assert.Equal(array[i] <= array[i + 1], true);
		}
	}

	[Fact]
	public void CountingSortTest()
	{
		var array = "example".ToCharArray();
		var expected = "aeelmpx";
		int R = 256;

		var sort = new CountingSort();
		sort.Sort(array, R);
		Assert.Equal(expected, new string(array));
	}

	[Fact]
	public void LSDSort()
	{
		var array = new string[] {
			"bed","bug", "dad", "yes", "zoo",
			"abc","tom"
		};
		var expected = new string[] {
			"abc", "bed","bug", "dad","tom", "yes", "zoo"
		};
		int w = 3;

		var sort = new LSDSort();
		sort.Sort(array, w);

		for (int i = 0; i < array.Length; i++)
		{
			Assert.Equal(expected[i], array[i]);
		}
	}


	// 	bed bug dad yes zoo
	// now for tip ilk dim 
	// tag jot sob nob sky
	// hut men egg few jay
	// owl joy rap gig wee
	// was wad fee tap tar
	// dug jam all bad yet
}