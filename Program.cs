using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var input = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

		System.Console.WriteLine(Math.Floor(input[0] * input[1]));
	}
}