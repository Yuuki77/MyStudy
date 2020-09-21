using System;

// Forest representation represent each set as tree and compare the only root
// in order to check if these are same set
public class QuickUnion : IUnionFind
{
	private int[] ids;
	private int count;

	public QuickUnion(int n)
	{
		ids = new int[n];
		for (int i = 0; i < ids.Length; i++)
		{
			ids[i] = i;
		}
		count = n;
	}

	public bool Connected(int p, int q)
	{
		// throw new NotImplementedException();
		return Find(p) == Find(q);
	}
	public int Count()
	{
		// throw new NotImplementedException();
		return count;
	}

	// revealDeclarationAside
	public int Find(int p)
	{
		while (p != ids[p])
		{
			ids[p] = ids[ids[p]];
			p = ids[p];
		}

		return p;
	}

	public void Union(int q, int p)
	{
		var pParent = Find(p);
		var qParent = Find(q);

		if (pParent == qParent) return;

		ids[pParent] = qParent;

		count--;
	}
}