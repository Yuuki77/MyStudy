using System.Collections.Generic;

public class AdjacentListGraph : IGraph
{
	private List<int> [] adj;
	private int v;
	public int Vertex => v;

	public AdjacentListGraph(int v) {
		this.v = v;
		this.adj = new List<int>[v];

		for(var i = 0; i < adj.Length; i++) {
			adj[i] = new List<int>();
		}
	}

	public void AddEdge(int v, int w)
	{
		adj[v].Add(w);
		adj[w].Add(v);
	}

	public List<int> Adj(int v)
	{
		return adj[v];
	}
}