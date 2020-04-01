using System;

// Forest representation represent each set as tree and compare the only root
// in order to check if these are same set
public class QuickUnion : IUnionFind
{
	private int[] ids;
	private int count;

	public QuickUnion(int n)
	{
		this.ids = new int[n];
		count = n;
		for (int i = 0; i < ids.Length; i++)
		{
			ids[i] = i;
		}
	}

	public bool Connected(int p, int q)
	{
		return Find(p) == Find(q);
	}

	public int Count()
	{
		return count;
	}

	// O(N)　we will consider how to improver the performance of find algorithm
	public int Find(int p)
	{
		while (ids[p] != p)
		{
			p = ids[p];
		}

		return p;
	}

	public void Union(int q, int p)
	{
		var qRoot = Find(q);
		var pRoot = Find(p);

		if (qRoot == pRoot) return;

		ids[qRoot] = pRoot;
	}
}