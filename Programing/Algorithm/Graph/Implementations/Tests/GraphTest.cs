using System;
using System.IO;
using System.Linq;
using Xunit;

public class GraphTest
{
	[Fact]
	public void AdjencyListGraph()
	{
		string contents = File.ReadAllText("/Users/yukiosaki/Desktop/lineAralgebra/Programing/Algorithm/Graph/Implementations/Tests/sampleGraphData.txt");
		var values = contents.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

		var vertex = values[0];
		var G = new AdjacentListGraph(int.Parse(vertex));

		for (var i = 1; i < values.Length; i++)
		{
			var value = values[i].Split().Select(int.Parse).ToArray();
			var w = value[0];
			var v = value[1];
			G.AddEdge(w, v);
		}

		Assert.Equal(G.Adj(7).Count, 1);
		Assert.Equal(G.Adj(0).Count, 4);
		Assert.Equal(G.Adj(9).Count, 3);
	}

	[Fact]
	public void matrixListGraph()
	{
		string contents = File.ReadAllText("/Users/yukiosaki/Desktop/lineAralgebra/Programing/Algorithm/Graph/Implementations/Tests/sampleGraphData.txt");
		var values = contents.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
		var vertex = values[0];
		var G = new AdjencyMatrixGraph(int.Parse(vertex));

		for (var i = 1; i < values.Length; i++)
		{
			var value = values[i].Split().Select(int.Parse).ToArray();
			var w = value[0];
			var v = value[1];
			G.AddEdge(w, v);
		}

		Assert.Equal(G.Adj(7).Count, 1);
		Assert.Equal(G.Adj(0).Count, 4);
		Assert.Equal(G.Adj(9).Count, 3);
	}

	[Fact]
	public void EulerianPathTest()
	{
		string contents = File.ReadAllText("/Users/yukiosaki/Desktop/lineAralgebra/Programing/Algorithm/Graph/Implementations/Tests/eularGraph.txt");
		var values = contents.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

		var vertex = values[0];
		var g = new AdjacentListGraph(int.Parse(vertex));

		for (var i = 1; i < values.Length; i++)
		{
			var value = values[i].Split().Select(int.Parse).ToArray();
			var w = value[0];
			var v = value[1];
			g.AddEdge(w, v);
		}

		var path = new EulerianPath(g, 0);
		Console.WriteLine("path" + path.path.Count);

		foreach (var item in path.path)
		{
			Console.WriteLine("item" + item);
		}
		// Assert.Equal(G.Adj(7).Count, 1);
		// Assert.Equal(G.Adj(0).Count, 4);
		// Assert.Equal(G.Adj(9).Count, 3);
	}
}