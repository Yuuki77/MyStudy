using System.Collections.Generic;

public interface IGraph {
	void AddEdge(int v, int w);
	List<int> Adj (int v);
    int Vertex { get; }
}