using System;
using System.Collections.Generic;

public class BitOperation
{
	public void Solve(int n)
	{
		for (var bit = 0; bit < 1 << n; bit++)
		{
			var list = new List<int>();
			string binary = Convert.ToString(bit, 2);
			System.Console.WriteLine("binary" + binary);
			for (var i = 0; i < n; i++)
			{
				string compare = Convert.ToString(1 << i, 2);
				System.Console.WriteLine(compare);

				if ((bit & 1 << i) != 0)
				{
					System.Console.WriteLine("add");
					System.Console.WriteLine("index is" + i);
					list.Add(i);
				}
			}

			System.Console.Write(bit + ": { ");

			foreach (var a in list)
			{
				System.Console.Write(a + " ");
			}
			System.Console.WriteLine("}");
		}
	}
}