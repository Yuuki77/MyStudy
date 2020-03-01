public class GCD
{
	public void Solve(int a, int b)
	{
		if (a < b)
		{
			var temp = a;
			a = b;
			b = temp;
		}

		var r = a % b;

		while (r != 0)
		{

			r = a % b;
			a = b;
			b = r;
		}

		System.Console.WriteLine(a);
	}
}