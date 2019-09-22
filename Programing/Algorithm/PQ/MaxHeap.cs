
	public class MaxHeap
	{
		public long[] pq;
		int n = 0;
		public MaxHeap(long n)
		{
			pq = new long[n + 1];
		}

		private void Sink(int k)
		{
			while (2 * k <= n)
			{
				int j = 2 * k;
				if (j < n && pq[j] <= pq[j + 1]) j++;
				if (pq[k] >= pq[j]) break;
				Exch(k, j);
				k = j;
			}
		}

		public void insert(long x)
		{
			// add x, and percolate it up to maintain heap invariant
			pq[++n] = x;
			Swim(n);
		}

		private void Swim(long k)
		{
			while (k > 1 && pq[k / 2] < pq[k])
			{
				Exch(k, k / 2);
				k = k / 2;
			}
		}

		public void Exch(long i, long j)
		{
			long swap = pq[i];
			pq[i] = pq[j];
			pq[j] = swap;
		}

		public long DelMax()
		{
			long max = pq[1];
			Exch(1, n--);
			Sink(1);
			pq[n + 1] = 0;

			return max;
		}
	}