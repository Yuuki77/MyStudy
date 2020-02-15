public class PrimeFactorial
{
	public void Solve(long n)
	{
		System.Console.WriteLine("test");

		for (var i = 2; i <= n / 2; i++)
		{
			// System.Console.WriteLine(i % n == 0);
			// System.Console.WriteLine(i);
			while (n % i == 0)
			{
				System.Console.WriteLine(i);
				n /= i;
			}
		}
	}
}
