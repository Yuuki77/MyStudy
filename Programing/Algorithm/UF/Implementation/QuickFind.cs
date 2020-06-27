using System;

public class QuickFind : IUnionFind
{
	// Make set
	private int[] ids;
	private int count = 0;
	public QuickFind(int n)
	{
		ids = new int[n];
		count = n;
		for (var i = 0; i < n; i++)
		{
			ids[i] = i;
		}
	}


	public bool Connected(int p, int q)
	{
		// throw new NotImplementedException();
		return ids[p] == ids[q];
	}

	public int Count()
	{
		// throw new NotImplementedException();
		return count;
	}

	public int Find(int p)
	{
		return ids[p];
	}

	public void Union(int q, int p)
	{
		// throw new NotImplementedException();
		var pParent = Find(p);
		var qParent = Find(q);

		if (pParent == qParent) return;

		for (var i = 0; i < ids.Length; i++)
		{
			if (ids[i] == pParent)
			{
				ids[i] = qParent;
			}
		}

		count--;
	}
}