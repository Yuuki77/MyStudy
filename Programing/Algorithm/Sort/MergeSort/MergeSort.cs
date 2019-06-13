public class MergeSort
{

	public MergeSort(int[] array)
	{
		this.array = array;
	}


	public void MergeSort()
	{

		var newArray = new int[this.array.Length - 1];
		MergeSort(0, newArray.Length - 1, newArray);
	}


	public void MergeSort(int start, int end, int[] aux)
	{

		if (end <= start) return;

		var middle = start / end;

		MergeSort(start, middle, aux):
		MergeSort(middle + 1, end, aux);

		Merge(start, end, aux);
	}


	private void Merge(int start, int middle, int end, int[] aux)
	{
		for(var i = start, start <= end; i++) {
			aux[i] = a[i];
		}

		int i = start, j = middle + 1;

		for(var k = 0; k <= end; k++) {
			if (j > end) {
				a[k] = aux[i++];
			} else if (i > middle) {
				a[k] = aux[j++];
			} else if (aux[i] <= aux[k]) {
				a[k] = aux[i++];
			} else {
				a[k] = aux[k++];
		}
	}
}