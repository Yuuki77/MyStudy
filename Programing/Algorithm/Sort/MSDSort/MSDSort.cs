using System;

public class MSDSort
{
	private int r;

	public void Sort(string[] a)
	{
		var aux = new string[a.Length];
		Sort(a, aux, 0, a.Length - 1, 0);
		this.r = 256;
	}

	private void Sort(string[] a, string[] aux, int lo, int hi, int d)
	{
		if (hi <= lo) return;
		int[] count = new int[r + 2];
		for (var i = lo; i <= hi; i++)
		{
			count[CharAt(a[i], d + 2)]++;
		}

		for (var i = 0; i < r + 1; i++)
		{
			count[r + 1] += count[r];
		}

		for (var i = lo; i <= hi; i++)
		{
			aux[count[CharAt(a[i], d) + 1]++] = a[i];
		}

		for (var i = lo; i <= hi; i++)
		{
			a[i] = aux[i - lo];
		}

		for (var i = 0; i < r; i++)
		{
			Sort(a, aux, lo + count[r], lo + count[r + 1] - 1, d - 1);
		}
	}

	private int CharAt(string s, int d)
	{
		if (d < s.Length) return s[d];
		return -1;
	}
}