using System;
using System.Linq;

namespace lineAralgebra
{


	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split().Select(long.Parse).ToArray()[0];
			
			var currentX = input;
			long currentY = 1;
			long start = input % 2 == 0 ? 2 : 3;
			for(long i = start; i <= input /2; i+=2) {
				var a = input /i;
				// if (a * i > input) 
				// {

				// }
				if (input % i == 0) {
					System.Console.WriteLine("currentX" + i);
					System.Console.WriteLine("currentY" + a);
						currentX = i;
						currentY = a;
						break;
					}
			}

			// System.Console.WriteLine(currentX);
			// System.Console.WriteLine(currentY);
			var ans = currentX -1 + currentY -1;
			// System.Console.WriteLine("ans is ");
			System.Console.WriteLine(ans);
		}

		
	}
}
//  b = 15