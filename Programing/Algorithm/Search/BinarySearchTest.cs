using System.Collections.Generic;
using Xunit;

public class BinarySearchTest
{
	[Fact]
	public void TestBinarySearch()
	{
		var list = new List<int>();
		for (var i = 0; i <= 100; i++)
		{
			list.Add(i);
		}
		var binarySearch = new BinarySearch();
		var ans = binarySearch.Find(list.ToArray(), 50);
		Assert.Equal(ans, 50);

		var ans2 = binarySearch.Find2(list.ToArray(), 50);
		Assert.Equal(ans, 50);
	}
}