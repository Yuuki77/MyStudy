using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lineAralgebra
{
	public class Dfs {

		static int[] x = { -1, 0, 1, 0, -1, 1, 1, -1, };
		static int[] y = { 0, 1, 0, -1, -1, 1, -1, 1 };
		static int h = 0;
		static int w = 0;
		// static void Main(string[] args)
		// {
		// 	while (true)
		// 	{
		// 		var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
		// 		w = input[0];
		// 		h = input[1];
		// 		if (h == 0 && w == 0)
		// 		{
		// 			break;
		// 		}
		// 		var map = new int[h, w];
		// 		var visited = new bool[h, w];
		// 		var ans = 0;

		// 		for (int i = 0; i < h; i++)
		// 		{
		// 			input = Console.ReadLine().Split().Select(int.Parse).ToArray();
		// 			for (int j = 0; j < input.Length; j++)
		// 			{
		// 				map[i, j] = input[j];
		// 			}
		// 		}

		// 		for (int i = 0; i < h; i++)
		// 		{
		// 			for (int j = 0; j < w; j++)
		// 			{
		// 				if (visited[i, j] || map[i, j] == 0) continue;
		// 				Dfs(map, visited, i, j);
		// 				ans++;
		// 			}
		// 		}
		// 		Console.WriteLine(ans);
		// 	}
		// }

		static void Solve(int[,] map, bool[,] visited, int currentY, int currentX)
		{
			visited[currentY, currentX] = true;
			for (int i = 0; i < x.Length; i++)
			{
				var nextY = y[i] + currentY;
				var nextX = x[i] + currentX;
				if (nextX < 0 || nextX >= w || nextY < 0 || nextY >= h || visited[nextY, nextX] || map[nextY, nextX] == 0) continue;
				Solve(map, visited, nextY, nextX);
			}
		}
	}
}