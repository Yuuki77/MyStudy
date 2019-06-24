using System;

public class WeightedQuickUnion : IUnionFind
{
	private int[] ids;
	private int[] size;
	private int count;

	public WeightedQuickUnion(int n)
	{
		this.ids = new int[n];
		this.size = new int[n];

		count = n;
		for (int i = 0; i < ids.Length; i++)
		{
			ids[i] = i;
			size[i] = 1;
		}
	}

	public bool Connected(int p, int q)
	{
		int pRoot = Find(p);
		int qRoot = Find(q);

		return pRoot == qRoot;
	}

	public int Count()
	{
		return count;
	}

	public int Find(int p)
	{

		while (ids[p] != p)
		{
			ids[p] = ids[ids[p]];
			p = ids[p];
		}

		return p;
	}

	public void Union(int q, int p)
	{
		int rootQ = Find(q);
		int rootP = Find(p);

		if (rootP == rootQ) return;
		
		if (size[rootP] < size[rootQ]) {
			ids[rootP] = rootQ;
			size[rootQ] += size[rootP];
		} else {
			ids[rootQ] = rootP;
			size[rootP] += size[rootQ];
		}
		count--;
	}

	// public int Try(int q, int p) {
	// 	int rootQ = Find(q);
	// 	int rootP = Find(p);

	// 	if (rootP == rootQ) return -1;

	// 	var tempSize = new int[size.Length];
	// 	var tempIds = new int[ids.Length];

	// 	Array.Copy(size, tempSize, size.Length);
	// 	Array.Copy(ids, tempIds, ids.Length);

	// 	retur	
	// }

}