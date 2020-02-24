using System;

public class CouponCollectorSimulator
{
	private int n;

	public CouponCollectorSimulator(int n)
	{
		this.n = n;

	}
	public void Solve()
	{
		var distinct = 0;
		var count = 0;
		var collected = new bool[n];

		while (distinct < n - 1)
		{
			Random rnd = new Random();
			var next = rnd.Next(0, n - 1);

			count++;

			if (!collected[next])
			{
				distinct++;
				collected[next] = true;
			}
		}
		System.Console.WriteLine(count);
	}
}