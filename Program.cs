using System;
using System.Collections.Generic;
using System.Linq;

namespace lineAralgebra
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var N = input[0];
			var M = input[1];

			var A = new int[N];
			var B = new int[N];

			for (int i = 0; i < M; i++)
			{
				input = Console.ReadLine().Split().Select(int.Parse).ToArray();
				A[i] = input[0] - 1;
				B[i] = input[1] - 1;
			}

			var ans = 0;

			for (var i = 0; i < M; i++)
			{
				var uf = new UnionFind(N);
				for (var j = 0; j < M; j++)
				{
                	if (i == j) continue;
					{
						uf.Unite(A[j], B[j]);

						if (uf.count == 1) break; 	
					}
				}
				if (uf.count != 1) ans++;
			}

			Console.WriteLine(ans);
		}

	}

	 class UnionFind {
        int[] dat;
        public UnionFind() { }
        public UnionFind(int N) { Init(N); }
		public int count = 0;
        public void Init(int n) { dat = new int[n + 1]; for (int i = 0; i <= n; ++i) dat[i] = -1; count = n;}
        public void Unite(int x, int y) {
            x = Root(x); y = Root(y); if (x == y) return;
            if (dat[y] < dat[x]) swap(ref x, ref y); dat[x] += dat[y]; dat[y] = x;
			count--;
        }
        public bool Find(int x, int y) { return Root(x) == Root(y); }
        public int Root(int x) { return dat[x] < 0 ? x : dat[x] = Root(dat[x]); }
        public int Size(int x) { return -dat[Root(x)]; }
        void swap(ref int a, ref int b) { int tmp = b; b = a; a = tmp; }
	 }

	public class uf
	{
		private int[] ids;
		private int[] size;
		private int count;

		public uf(int n)
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

		// public int Find(int p)
		// {

		// 	while (ids[p] != p)
		// 	{
		// 		ids[p] = ids[ids[p]];
		// 		p = ids[p];
		// 	}

		// 	return p;
		// }

		public int Find(int p) {
			if (ids[p] == p) return p;
			else {
				return ids[p] = Find(ids[p]);
			}
		}

		public void Union(int q, int p)
		{
			int rootQ = Find(q);
			int rootP = Find(p);

			if (rootP == rootQ) return;

			if (size[rootP] < size[rootQ])
			{
				ids[rootP] = rootQ;
				size[rootQ] += size[rootP];
			}
			else
			{
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
}