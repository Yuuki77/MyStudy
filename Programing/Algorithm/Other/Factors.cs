public class Factors
{
	public void Solve(long x)
	{
		for (long factor = 2; factor <= x / factor; factor++)
		{
			while (x % factor == 0)
			{
				x /= factor;
				System.Console.WriteLine(factor + " ");
			}
		}
		if (x > 1) System.Console.WriteLine(x);
	}
}