class Ruisekiwa
{
	public void Solve(int n, int start, int end)
	{
		var a = new int[n];
		for (var i = 0; i < n; i++)
		{
			a[i] = i;
		}

		var s = new int[n];
		for (var i = 1; i < n; i++)
		{
			s[i] = s[i - 1] + a[i];
			var aval = a[i];
			var sval = s[i - 1];
			var sum = s[i];
		}

		System.Console.WriteLine(s[end] - s[start - 1]);
	}
}