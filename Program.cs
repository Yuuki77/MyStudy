using System;
using System.Linq;
using System.Collections.Generic;

namespace lineAralgebra
{
	class Program
	{
		public static int h;
		public static int w;
		public static void Main(String[] args)
		{
			var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			h = input[0];
			w = input[1];
			var map = new char[h, w];

			var ans = 0;
			for (var height = 0; height < h; height++)
			{
				var row = Console.ReadLine().ToCharArray();
				for (var width = 0; width < w; width++)
				{
					map[height, width] = row[width];
				}
			}

			for (var height = 0; height < h; height++)
			{

				for (var width = 0; width < w; width++)
				{
					if (map[height, width] == '#') continue;
					ans = Math.Max(BFS(height, width, map), ans);
				}
			}
			System.Console.WriteLine(ans);
		}

		public static int BFS(int height, int width, char[,] map)
		{
			var dx = new int[] { -1, 0, 0, 1 };
			var dy = new int[] { 0, 1, -1, 0 };
			var visited = new bool[h, w];
			var path = new int[h, w];
			var queue = new Queue<Tuple<int, int>>();
			queue.Enqueue(new Tuple<int, int>(height, width));
			var ans = 0;
			visited[height, width] = true;

			while (queue.Count != 0)
			{
				var current = queue.Dequeue();
				for (var i = 0; i < 4; i++)
				{
					var nextY = current.Item1 + dy[i];
					var nextX = current.Item2 + dx[i];
					if (nextY >= h || nextX >= w) continue;
					if (nextY < 0 || nextX < 0) continue;

					var next = new Tuple<int, int>(nextY, nextX);
					if (visited[next.Item1, next.Item2] || map[next.Item1, next.Item2] == '#') continue;
					visited[next.Item1, next.Item2] = true;
					path[next.Item1, next.Item2] = path[current.Item1, current.Item2] + 1;
					ans = Math.Max(ans, path[next.Item1, next.Item2]);
					queue.Enqueue(new Tuple<int, int>(next.Item1, next.Item2));
				}
			}

			return ans;
		}
	}
}

