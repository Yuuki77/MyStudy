using System;
using System.Linq;

public class ABC141
{
	// https://atcoder.jp/contests/abc141/tasks/abc141_d
// 	高橋くんは N個の品物を 1個ずつ順番に買う予定です。
// i 番目に買う品物の値段は  Ai円です。
// 高橋くんは M枚の割引券を持っています。

// 品物を買う際に割引券を好きな枚数使うことができます。
// X 円の品物を買う際に 
// Y 枚の割引券を使った場合、その品物を 
// XY円(小数点以下切り捨て)で買うことができます。
// 最小で何円あれば全ての品物を買うことができるでしょうか

	public void SolveD()
	{
		var input = Console.ReadLine().Split(' ');
		var n = long.Parse(input[0]);
		var m = long.Parse(input[1]);

		input = Console.ReadLine().Split(' ');

		var a = new int[n];

		var pq = new MaxHeap(n);
		for (var i = 0; i < n; i++)
		{
			a[i] = int.Parse(input[i]);
			pq.insert(a[i]);
		}

		for (var i = 0; i < m; i++)
		{
			var max = pq.DelMax();
			max /= 2;
			pq.insert(max);
		}

		System.Console.WriteLine(pq.pq.Sum());
	}
}