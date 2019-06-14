using System;

public class UnderOrderMaxPQ
{
	private int[] pq;
	private int N;

	public UnderOrderMaxPQ(int capacity)
	{
		pq = new int[capacity];
	}

	public bool IsEmpty()
	{
		return N == 0;
	}

	public void Insert(int x)
	{
		pq[++N] = x;
	}

	public int DeleteMax()
	{
		int max = 0;
		for (var i = 1; i < N; i++)
		{
			if (pq[max] < pq[i])
			{
				max = i;
			}
		}

		Exchange(max, N - 1);

		return pq[--N];
	}

	private void Exchange(int max, int p)
	{
		var temp = pq[max];
		pq[max] = pq[p];
		pq[p] = temp;
	}
}