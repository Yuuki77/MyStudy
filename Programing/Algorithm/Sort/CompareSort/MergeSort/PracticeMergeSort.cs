using System;

public class PracticeMergeSort
{

	public void Sort(int[] a)
	{
		var aux = new int[a.Length];
		Sort(a, aux, 0, a.Length - 1);
	}

	private void Sort(int[] a, int[] aux, int lo, int hi)
	{
		if (hi == lo) return;

		var middle = lo + (hi - lo) / 2;
		Sort(a, aux, lo, middle);
		System.Console.WriteLine( middle + 1);
		Sort(a, aux, middle + 1, hi);
		// if (a[middle] <= a[middle + 1]) return;
		Merge(a, aux, lo, middle, hi);
		//  
	}

	private void Merge(int[] a, int[] aux, int lo, int middle, int hi)
	{
		for (var i = lo; i <= hi; i++)
		{
			System.Console.WriteLine(i);
			aux[i] = a[i];
		}

		var j = lo;
		var k = middle + 1;
		for (var i = lo; i <= hi; i++)
		{
			if (j > middle) a[i] = aux[k++];
			else if (k > hi) a[i] = aux[j++];
			else if (aux[j] < aux[k]) a[i] = aux[j++];
			else
			{
				a[i] = aux[k++];
			}
		}
	}
}