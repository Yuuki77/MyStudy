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
		public static Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
		public static int[] ans;

		public static void Main(String[] args)
		{
			var n = int.Parse(Console.ReadLine());
			ans = new int[n - 1];
			for (var i = 0; i < n - 1; i++)
			{
				// System.Console.WriteLine("i is" + i);
				var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

				if (!graph.ContainsKey(input[0]))
				{
					graph[input[0]] = new List<Edge>();
				}

				if (!graph.ContainsKey(input[1]))
				{
					graph[input[1]] = new List<Edge>();
				}

				graph[input[0]].Add(new Edge(input[1], i));
				graph[input[1]].Add(new Edge(input[0], i));
			}

			Dfs(1);

			var max = 0;
			foreach (var i in ans)
			{
				max = Math.Max(max, i);
			}
			System.Console.WriteLine(max);

			for (var i = 0; i < ans.Length; i++)
			{
				System.Console.WriteLine(ans[i]);
			}
		}

		public static void Dfs(int current, int parent = -1, int color = -1)
		{
			var k = 1;
			foreach (var nodes in graph[current])
			{
				var to = nodes.to;
				var id = nodes.id;
				if (to == parent) continue;
				if (k == color) k++;
				ans[id] = k;
				k++;
				Dfs(to, current, ans[id]);
			}
		}
	}
}

