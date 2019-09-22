using System;

// public class TestUnion
// {
// 	int[] unions;
// 	int[] size;
// 	int components;
// 	public TestUnion(int n)
// 	{
// 		unions = new int[n];
// 		size = new int[n];
// 		components = n;

// 		for (var i = 0; i < unions.Length; i++)
// 		{
// 			unions[i] = 1;
// 			size[i] = 1;
// 		}
// 	}

// 	public bool Connected(int q, int p) {
// 		var rootq = Root(q);
// 		var rootp = Root(p);

// 		return rootp == rootq;
// 	}

// 	private int Root(int p)
// 	{
// 		while(unions[p] != p) {
// 			p = unions[p];
// 		}

// 		return p;
// 	}

// 	public void Union(int p, int q)
// 	{
// 		var pRoot = Root(p);
// 		var qRoot = Root(p);

// 		if (pRoot == qRoot) return;

// 		if (size[pRoot] <= size[qRoot])
// 		{
// 			unions[pRoot] = qRoot;
// 			size[qRoot] += size[pRoot];
// 		} else {
// 			unions[qRoot] = pRoot;
// 			size[pRoot] += size[qRoot];
// 		}
// 	}
// }