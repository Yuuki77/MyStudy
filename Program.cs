using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lineAralgebra
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");
			FileStream fs = new FileStream("Test.txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(fs);
			Console.SetOut(sw);
			// Console.WriteLine("Hello file");
			// sw.Close();
			Ack(4, 1);
		}

		static long count = 0;

		public static int Ack(int m, int n)
		{
			// 2^65,533
			//uncountable ではないという話
			// super exponetiory for loop ではできないという話
			var ans = 0;
			if (m == 0)
			{
				Console.WriteLine("1");
				ans = n + 1;
			}
			else if (n == 0)
			{
				Console.WriteLine("2");
				ans = Ack(m - 1, 1);
			}
			else
			{
				Console.WriteLine("3");
				ans = Ack(m - 1, Ack(m, n - 1));
			}

			++count;
			Console.WriteLine("Ack(" + m + "," + n + ") = " + ans);
			Console.WriteLine("Count: " + count);
			return ans;
		}
	}
}