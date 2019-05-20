using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class TestCombination
{
	[Fact]
	public void test1()
	{
		var count = 3;
		var set = new int[count];
		for(var i = 0; i < count; i++) {
			set[i] = i;
		}
		var r = 2;

		var combintionManager = new Combination(set, r);
		var result = combintionManager.Results;
		// Console.WriteLine("test1" + combintionManager.count);
		// Assert.Equal(result.Count, 120);
	}

	[Fact]
	public void test2()
	{
		// Input : arr[] = [1, 2, 3, 4],  
		//     r = 2
		// Output : [[1, 2], [1, 3], [1, 4], [2, 3], [2, 4], [3, 4]]
		var set = new int[] { 1, 2, 3, 4 };
		var expectedResults = new List<List<int>>(){
			new List<int>(){1,2},new List<int>(){1,3},new List<int>(){1,4},new List<int>(){2,3},
			new List<int>(){2,4},new List<int>(){3,4}
		};

		var r = 2;

		var combintionManager = new Combination(set, r);
		var results = combintionManager.Results;
		Console.WriteLine(combintionManager.count);
		Assert.Equal(results.Count, 6);

		foreach (var expectedResult in expectedResults)
		{

			bool isExisted = false;
			foreach (var result in results)
			{

				if (result.All(expectedResult.Contains))
				{
					isExisted = true;
				}
			}

			Assert.Equal(isExisted, true);
		}
	}
}