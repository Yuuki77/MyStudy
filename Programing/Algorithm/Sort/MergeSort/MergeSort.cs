using System;

public class MergeSort
{
	public int [] array;

	public MergeSort()
	{
		// Sort();
	}

	public void Sort(int[] array)
	{
		this.array = array;
		var newArray = new int[this.array.Length];
		Sort(0, newArray.Length - 1, array, newArray);
	}

	public void Sort(int start, int end, int[] originalArray, int[] aux)
	{

		if (end <= start) return;

		var middle = start + (end - start) /2 ;

		Sort(start, middle,originalArray, aux);
		Sort(middle + 1, end, originalArray,aux);
	
		Merge(start, middle, end, originalArray, aux);
	}

	private void Merge(int start, int middle, int end, int [] originalArray,int[] aux)
	{
		for(var h = start; h <= end; h++) {
			aux[h] = originalArray[h];
		}

		int i = start, j = middle + 1;

		for(var k = start; k <= end; k++) {
			if (j > end) {
				originalArray[k] = aux[i++];
			} else if (i > middle) {
				originalArray[k] = aux[j++];
			} else if (aux[i] < aux[j]) {
				originalArray[k] = aux[i++];
			} else {	
				originalArray[k] = aux[j++];
			}
		}
	}
}