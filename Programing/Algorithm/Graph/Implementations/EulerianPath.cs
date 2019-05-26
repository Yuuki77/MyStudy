using System;
using System.Collections.Generic;
using System.Linq;

public class EulerianPath
{
	private IGraph graph;
	public List<int> path;
	private bool[,] visited;

	public EulerianPath(IGraph g)
	{
		this.graph = g;
		visited = new bool[g.Vertex, g.Vertex];
		Solve();
	}

	private void Solve()
	{
		var currentVertex = 1;

		bool searching = true;

		while (searching)
		{
			path.Add(currentVertex);
			var adjacent = graph.Adj(currentVertex);
			var filteredAdjacent = adjacent.Where(next => !visited[currentVertex, next]).ToArray();

			if (filteredAdjacent.Length == 0)
			{
				break;
			}

			var uf = new WeightedQuickUnion(graph.Vertex);
			for (int i = 0; i < this.graph.Vertex; i++)
			{
				foreach (var to in graph.Adj(i))
				{
					if (visited[to, i]) continue;
					uf.Union(i, to);
				}
			}

			for (int i = 0; i < filteredAdjacent.Length; i++)
			{
				var nextPos = filteredAdjacent[i];
				if (!uf.Connected(currentVertex, nextPos) && i != filteredAdjacent.Length - 1)
				{
					continue;
				}

				// uf.Union(currentVertex, nextPos);
				visited[currentVertex, nextPos] = true;
				visited[nextPos, currentVertex] = true;

				currentVertex = nextPos;
				break;
			}
		}
	}
}