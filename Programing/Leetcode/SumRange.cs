public class SumRange
{
	public int Solve(int a, int b)
	{
		// ベースケース
		if (a == b)
		{
			return a;
		}
		// 再帰ステップ
		return Solve(a, b - 1) + b;
	}
}