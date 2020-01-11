using Xunit;

public class StringTest
{
	[Fact]
	public void Test1()
	{
		var test = new SpreadSheetEncoding();
		var ans = test.MaxSum(new int[] { 100, 11, 12 });
		Assert.Equal(100, ans);
	}

	[Fact]
	public void Test2()
	{
		var test = new SpreadSheetEncoding();
		var ans = test.StringToInt("-312");
		Assert.Equal(-312, ans);

		ans = test.StringToInt("3121");
		Assert.Equal(3121, ans);
	}
}