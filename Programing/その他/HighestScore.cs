using System;

class HighestScore
{
	// static void Main(string[] args)
	// {
	// 	var input = new string[] {
	// 		"NNY",
	// 		"YNY",
	// 		"YYN"
	// 	};

	// 	System.Console.WriteLine(HighestScore(input));
	// }	

	public int Solve(string[] friends)
	{
		int ans = 0;
		int n = friends[0].Length;

		for (var i1 = 0; i1 < n; i1++)
		{
			int ctn = 00;
			for (var i2 = 0; i2 < n; i2++)
			{
				if (i1 == i2) continue;

				if (friends[i1][i2] == 'Y')
				{
					ctn++;
				}
				else
				{
					for (var i3 = 0; i3 < n; i3++)
					{
						if (friends[i2][i3] == 'Y' && friends[i3][i1] == 'Y')
						{
							ctn++;
							break;
						}
					}
				}

				ans = Math.Max(ans, ctn);
			}
		}
		return ans;
	}
}