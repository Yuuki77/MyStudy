using System.Collections.Generic;

public class AdjencyMatrixGraph : IGraph
{
	private int vertex;
	private int[,] adj;
	public int Vertex => vertex;
	public AdjencyMatrixGraph(int v)
	{
		this.vertex = v;
		adj = new int[v, v];
	}


	public void AddEdge(int v, int w)
	{
		adj[w, v] = 1;
		adj[v, w] = 1;
		// throw new System.NotImplementedException();
	}

	public List<int> Adj(int v)
	{
		var list = new List<int>();
		for(var i = 0; i< vertex; i++) {

			if (adj[v, i] != 0) {
				list.Add(i);
			}
		}
		
		return list;
	}
}