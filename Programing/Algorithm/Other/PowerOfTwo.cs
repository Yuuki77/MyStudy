public class PowerOfTwo
{
	public void Solve(int n)
	{
		var i = 0;
		int v = 1;

		while (i <= n)
		{
			System.Console.WriteLine(v);
			i++;
			v *= 2;
		}
	}

	public void Solve2(int n)
	{
		var ans = 1;
		for (var i = 0; i <= n; i++)
		{
			System.Console.WriteLine(ans);
			ans *= 2;
		}
	}
}