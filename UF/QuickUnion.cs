using System;

public class QuickUnion : IUnionFind
{
	private int[] ids;
	private int count;

	public QuickUnion(int n) {
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

	public int Find(int p)
	{
		while(ids[p] != p) {
			p = ids[p];
		}

		Console.WriteLine("p" + p);

		return p;
	}

	public void Union(int q, int p)
	{
		var qRoot = Find(q);
		var pRoot = Find(p);

		if(qRoot == pRoot) return;

		ids[qRoot] = pRoot;
	}
}