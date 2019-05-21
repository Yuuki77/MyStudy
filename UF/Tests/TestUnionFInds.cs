using System;
using System.Collections.Generic;
using Xunit;

public class TestUnionFinds
{
	[Fact]
	public void TestQuickFind()
	{
		var input = new List<int[]>()
		{
			new int[] {1,3},
			new int[] {1,4},
			new int[] {8,9}
		};

		var N = 10;


		var uf = new QuickFind(N);

		foreach (var item in input)
		{
			uf.Union(item[0], item[1]);
		}

		Assert.Equal(uf.Connected(3, 4), true);
		Assert.Equal(uf.Connected(9, 0), false);
	}

	[Fact]
	public void TestQuickUnion()
	{
		var input = new List<int[]>()
		{
			new int[] {1,3},
			new int[] {1,4},
			new int[] {8,9}
		};

		var N = 10;


		var uf = new QuickUnion(N);

		foreach (var item in input)
		{
			uf.Union(item[0], item[1]);
		}

		Assert.Equal(uf.Connected(3, 4), true);
		Assert.Equal(uf.Connected(9, 0), false);
	}


	[Fact]
	public void TestWeightedQuickUnion()
	{
		var input = new List<int[]>()
		{
			new int[] {1,3},
			new int[] {1,4},
			new int[] {8,9}
		};

		var N = 10;


		var uf = new WeightedQuickUnion(N);

		foreach (var item in input)
		{
			uf.Union(item[0], item[1]);
		}

		Assert.Equal(uf.Connected(3, 4), true);
		Assert.Equal(uf.Connected(9, 0), false);
	}

}