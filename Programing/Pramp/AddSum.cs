public class AddSum
{
	public int Solve(int n)
	{
		System.Console.WriteLine(n);
		if (n == 0) return 0;

		var ans = Solve(n - 1);
		return n + ans;
	}
}