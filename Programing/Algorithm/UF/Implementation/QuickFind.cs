using System;

public class QuickFind : IUnionFind
{
	public int[] id;
	public int count;

	public QuickFind(int n)
	{
		id = new int[n];
		for (var i = 0; i < n; i++)
		{
			id[i] = i;
		}
	}

	public bool Connected(int p, int q)
	{
		return id[p] == id[q];
	}

	public int Count()
	{
		return count;
	}

	public int Find(int p)
	{
		return id[p];
	}

	public void Union(int q, int p)
	{

		var pId = Find(p);
		var qId = Find(q);

		if (pId == qId) return;

		// O(N)
		// if id[i] is in the same set as qId and then update to pId
		for (var i = 0; i < id.Length; i++)
		{
			if (qId == id[i])
			{
				id[i] = pId;
			}
		}

		count--;
	}
}