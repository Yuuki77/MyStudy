using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var N = long.Parse(Console.ReadLine());

		var ans = 1 << 29;
		for (long i = 1; i < N / 2; i++)
		{
			if (N % i == 0)
			{
				long b = N / i;
				var f = Math.Max(Solve(i), Solve(b));
				ans = Math.Min(ans, f);
			}
		}

		System.Console.WriteLine(ans);
	}

	static int Solve(int n)
	{
		int sum = 0;

		while (n > 0)
		{
			sum++;
			n /= 10;
		}

		return sum;
	}
}