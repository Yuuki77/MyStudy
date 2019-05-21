using System;

public class QuickFind : IUnionFind
{
	private int[] ids;
	private int count;
	public QuickFind(int N)
	{
		ids = new int[N];
		for (int i = 0; i < N; i++)
		{
			ids[i] = i;
		}
		count = N;
	}
	public bool Connected(int p, int q)
	{
		return ids[p] == ids[q];
	}

	public int Count()
	{
		return count;
	}

	public int Find(int p)
	{
		return ids[p];
	}

	public void Union(int q, int p)
	{
		int pRoot = Find(p);
		int qRoot = Find(q);

		if (pRoot == qRoot) {
			return;
		} 

		for (int i = 0; i < ids.Length; i++)
		{
			if (ids[i] == pRoot) {
				ids[i] = qRoot;
			}
		}
		count--;
	}
}