using System.Collections.Generic;

public class SalePath
{
	public class Node
	{
		public int cost;
		public List<Node> children = new List<Node>();
		public Node parent;
		public Node(int cost)
		{
			this.cost = cost;
		}
	}

	/*
		static void Main(string[] args)
		{
			var root = new SalePath.Node(3);
			var child = new SalePath.Node(20);
			child.children.Add(new SalePath.Node(15));
			child.children.Add(new SalePath.Node(7));
			root.children.Add(child);
			root.children.Add(new SalePath.Node(9));
			var path = new SalePath();
			var ans = path.GetCheapestCost(root);

			System.Console.WriteLine(ans);
		}
	 */

	public int GetCheapestCost(Node rootNode)
	{
		System.Console.WriteLine("root cost ->" + rootNode.cost);
		if (rootNode.children.Count == 0) return rootNode.cost;

		var minCost = int.MaxValue;
		for (var i = 0; i < rootNode.children.Count; i++)
		{
			var tempCost = GetCheapestCost(rootNode.children[i]);
			System.Console.WriteLine("temp cost -> " + tempCost);
			if (minCost > tempCost)
			{
				minCost = tempCost;
			}
		}

		return minCost + rootNode.cost;
	}
}