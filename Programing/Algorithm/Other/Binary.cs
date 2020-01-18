using System.Collections.Generic;

public class Binary
{

	public void Print(int n)
	{
		int power = 1;

		while (power <= n / 2)
		{
			power *= 2;
		}

		while (power > 0)
		{
			var test = "test";
			if (n < power) System.Console.Write(0);
			else
			{
				System.Console.Write(1);
				n -= power;
			};
			power /= 2;
		}
	}

	public void Print2(int n)
	{
		var stack = new Stack<int>();
		while (n > 0)
		{
			if (n % 2 != 0)
			{
				stack.Push(1);
				// System.Console.Write(1);
			}
			else
			{
				stack.Push(0);
				// System.Console.Write(0);
			}
			n /= 2;
		}

		foreach (var a in stack)
		{
			System.Console.Write(a);
		}
	}
}