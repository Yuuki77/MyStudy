using System;
using System.Collections.Generic;
using System.Linq;

namespace lineAralgebra
{
	class Program
	{
		static void Main(string[] args)
		{
			
			Console.WriteLine("");
			var ans = CalFactorial(4);
			Console.WriteLine("ans" + ans);

		}	

		public static int CalFactorial(int n)
		{
			if (n <= 1) return 1;
			
			// Console.WriteLine("n" + n);
			var a = CalFactorial(n -1);
			var b = CalFactorial(n -1);
			// Console.WriteLine("a " + a);
			// Console.WriteLine("b " + b);
			return a + b;
		}
	}
}