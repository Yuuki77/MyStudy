

using System;
using System.Collections.Generic;

public class MinQP
{
	private int n;
	private List<IComparable> list;

	public MinQP(List<IComparable> a)
	{
		this.list = a;
		n = list.Count;

		for (var k = list.Count / 2; k >= 1; k--)
		{
			GoDown(k);
		}
	}

	public void GoDown(int k)
	{
		int nextIndex = 2 * k;
		while (nextIndex <= n)
		{
			if (nextIndex < n && Less(list[nextIndex], list[nextIndex + 1]))
			{
				nextIndex++;
			}

			Swap(k, nextIndex);
			k = nextIndex;
		}
	}

	public void Insert(IComparable a)
	{
		// list[1 ~ heapsize]
		list[++n] = a;
		GoUp(n);
	}

	public void GoUp(int k)
	{
		while (k > 1 && Less(k / 2, k))
		{
			Swap(k, k / 2);
			k = k / 2;
		}
	}



	private void Swap(int a, int b)
	{
		var temp = list[a];
		list[a] = list[b];
		list[b] = temp;
	}

	private bool Less(IComparable a, IComparable b)
	{
		return a.CompareTo(b) <= -1;
	}

	public IComparable DelMin()
	{
		var smallest = list[1];
		Swap(1, n);

		list[n--] = null;

		GoDown(1);
		return smallest;
	}
}