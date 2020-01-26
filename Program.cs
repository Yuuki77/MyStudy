using System;
using System.Linq;
using System.Collections.Generic;

namespace lineAralgebra
{
	class Edge
	{
		public int id;
		public int to;
		public Edge(int to, int id)
		{
			this.id = id;
			this.to = to;
		}
	}

	class Program
	{
		public static void Main(String[] args)
		{
			var prime = new Factors();
			long x = 3757208;
			prime.Solve(x);
		}
	}
}

