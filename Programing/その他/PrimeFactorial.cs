using System;
using System.Collections.Generic;
public class PrimeFactorial
{
	// 素因数分解
	public List<Tuple<long, long>> Solve(long n)
	{
		System.Console.WriteLine("test");
		var list = new List<Tuple<long, long>>();
		for (var i = 2; i <= n / 2; i++)
		{
			// System.Console.WriteLine(i % n == 0);
			// System.Console.WriteLine(i);
			long ex = 0;
			while (n % i == 0)
			{
				// System.Console.WriteLine(i);
				ex++;
				n /= i;
			}

			list.Add(new Tuple<long, long>(i, ex));

		}

		if (n != 1)
		{
			list.Add(new Tuple<long, long>(n, 1));
		}
		// ans.Sort();

		return list;
	}

	// 約数列挙
	public List<long> Solve2(long n)
	{
		var ans = new List<long>();
		for (var i = 2; i * i <= n; i++)
		{
			if (n % i == 0)
			{
				ans.Add(i);
				if (n / i != i)
					ans.Add(n / i);

			}

		}

		ans.Sort();

		return ans;
	}

}
