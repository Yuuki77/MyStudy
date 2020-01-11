using System;
using System.Linq;
public class SpreadSheetEncoding
{

	// test reduce (Aggregate)

	public int MaxSum(int[] arr)
	{
		var max = arr.Aggregate(int.MinValue, (x, y) => Math.Max(x, y));
		Console.WriteLine(max);

		// length is capital letter
		System.Console.WriteLine(arr.Length);
		return max;
	}

	// check string

	public void SubStringTest()
	{

		// define string 
		String str = "GeeksForGeeks";

		Console.WriteLine("String    : " + str);

		// retrieve the substring from index 5 
		Console.WriteLine("Sub String1: " + str.Substring(5));

		// retrieve the substring from index 8 
		Console.WriteLine("Sub String2: " + str.Substring(8));
	}

	public int StringToInt(string input)
	{

		// 
		return (input[0] == '-' ? -1 : 1)
		* input.Substring(input[0] == '-' ? 1 : 0).ToCharArray()
		.Aggregate(0, (sum, value) => {
			var ans = (sum * 10) +value - '0';
			return ans;
		});
	}
}