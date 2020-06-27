using System;
using System.Collections.Generic;
using System.Linq;

public class EulerianPath
{
	private IGraph graph;
	public List<int> path;
	private bool[,] visited;

	public EulerianPath(IGraph g, int startVertex)
	{
		this.graph = g;
		visited = new bool[g.Vertex, g.Vertex];
		path = new List<int>();
		Solve(startVertex);
	}

	private void Solve(int startVertex)
	{
		var currentVertex = startVertex;

		while (true)
		{
			path.Add(currentVertex);
			var adjacent = graph.Adj(currentVertex);

			var filteredAdjacent = adjacent.Where(next => !visited[currentVertex, next]).ToArray();

			if (filteredAdjacent.Length == 0)
			{
				break;
			}
			for (int i = 0; i < filteredAdjacent.Length; i++)
			{
				var nextPos = filteredAdjacent[i];
				bool[,] tempVisited = (bool[,])visited.Clone();
				System.Console.WriteLine(test);
				tempVisited[nextPos, currentVertex] = true;
				tempVisited[currentVertex, nextPos] = true;
				var uf = new WeightedQuickUnion(graph.Vertex);

				for (int j = 0; j < this.graph.Vertex; j++)
				{
					foreach (var to in graph.Adj(j))
					{
						if (tempVisited[to, j] || tempVisited[j, to]) continue;
						uf.Union(j, to);
					}
				}

				if (!uf.Connected(currentVertex, nextPos) && i != filteredAdjacent.Length - 1)
				{
					continue;
				}

				visited[currentVertex, nextPos] = true;
				visited[nextPos, currentVertex] = true;

				currentVertex = nextPos;
				break;
			}
		}
	}
}