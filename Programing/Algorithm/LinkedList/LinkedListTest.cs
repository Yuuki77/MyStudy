using Xunit;

public class LinkedListTest
{
	[Fact]
	public void Test1()
	{
		var test = new LinkedListOfString();

		for(var i = 0; i<= 100; i++) {
			test.Push(i.ToString());
		}

		for(var i = 100; i >= 0; i--) {
			var val = test.Pop();
			Assert.Equal(i.ToString(), val);
		} 
	}
	[Fact]
	public void Test2()
	{
		var test = new LinkedListResizingArray();

		for(var i = 0; i<= 100; i++) {
			test.Push(i.ToString());
		}

		for(var i = 100; i >= 0; i--) {
			var val = test.Pop();
			Assert.Equal(i.ToString(), val);
		} 
	}
}