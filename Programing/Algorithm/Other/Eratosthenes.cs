using System.Collections;

public class Eratosthenes
{
	public void Solve(int n)
	{
		var isPrime = new BitArray(1000000);
		for (int i = 2; i <= n; i++) isPrime.Set(i, true);

		for (int i = 2; i <= n; ++i)
		{
			if (isPrime.Get(i))
			{ // 素数 i を発見したら
				for (int j = i * 2; j <= n; j += i)
				{
					System.Console.WriteLine(j);
					isPrime.Set(j, false); // i の倍数をふるい落とす
				}
			}
		}

		// 結果出力
		for (int i = 2; i <= n; ++i)
		{
			if (isPrime.Get(i)) System.Console.WriteLine(i); ;
		}

	}
}