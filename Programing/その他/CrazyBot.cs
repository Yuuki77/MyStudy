public class CrazyBot
{
	bool[,] grid = new bool[100, 100];
	int[] vx = new int[] { 1, -1, 0, 0 };
	int[] vy = new int[] { 0, 0, 1, -1 };
	double[] prob = new double[4];

	public double Solve(int n, int east, int west, int sourth, int north)
	{
		prob[0] = east / 100.0f;
		prob[1] = west / 100.0f;
		prob[2] = north / 100.0f;
		prob[3] = east / 100.0f;

		return Dfs(50, 50, n);
	}

	double Dfs(int x, int y, int n)
	{
		if (grid[x, y]) return 0;
		if (n == 0) return 	1;

		grid[x,y] = true;	
		double ret = 0;

		for(var i = 0; i < 4; i++) {
			ret += Dfs(x + vx[i], y + vy[i], n-1) * prob[i];
		}

		grid[x, y] = false;
		return ret;
	}
}