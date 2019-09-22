using System;
public class DeletionDistance
{

	public int Solve(string str1, string str2)
	{
		// you can delete a character
		// and you need to transform one string to the other
		// the only operation you can do is delete a character
		// first what is the base case
		// if the a string is empty what should you return+
		// you want to compare the substring of both elements

		// 1. do nothing 
		// you want to change heat to hit
		// you want to check if the last element is same or not
		// if the last element is same value you dont have to do delete
		// 1. [0,3] -> [0,2]
		//    heat hit
		// this means that 1 the answer is same as 
		// 2. [0,2] -> [0,1]
		//     hea       hi

		// 2 delete the one of a character
		// 2. [0,2] -> [0,1]
		//     hea       hi

		// Case 2: The last character in str1 is different from the last character in str2.
		// 	In that case, at least one of the characters must be deleted,
		// 	thus we get the following equation: 
		// 	d(str1,str2) = 1 + min( d(str1.substring(0, n-1), str2), d(str1, str2.substring(0, m-1)) ) 
		// 	where n is the length of str1, m is the length of str2, and d(x,y) 
		// 	is the deletion distance between x and y.

		var memo = new int[str1.Length + 1, str2.Length + 1];
		for (var i = 0; i <= str1.Length; i++)
		{
			for (var j = 0; j <= str2.Length; j++)
			{
				if (i == 0) memo[i, j] = j;
				else if (j == 0) memo[i, j] = 1;
				else if (str1[i - 1] == str2[j - 1])
				{
					memo[i, j] = memo[i - 1, j - 1];
				}
				else
				{
					memo[i, j] = Math.Min(memo[i - 1, j], memo[i, j - 1]);
				}
			}
		}

		return memo[str1.Length, str2.Length];
	}
}