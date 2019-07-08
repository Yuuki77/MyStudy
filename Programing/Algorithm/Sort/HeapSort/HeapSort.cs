public class HeapSort
{
	public void Sort(int[] array)
	{
		for (var i = array.Length - 1 / 2; i > 0; i--)
			Sink(array, i);

		// One by one extract an element from heap 
		for (int i = array.Length - 1; i > 0; i--)
		{
			// Move current root to end 
			int temp = array[0];
			array[0] = array[i];
			array[i] = temp;

			// call max heapify on the reduced heap 
			Heapify(array, i, 0);
		}
	}

	private void Sink(int[] array, int currentIndex)
	{
		var lastIndex = array.Length - 1;
		while (2 * currentIndex <= lastIndex)
		{
			int nextIndex = 2 * currentIndex;
			if (nextIndex < lastIndex && array[nextIndex] < array[nextIndex + 1]) nextIndex++;
			if (array[currentIndex] >= array[nextIndex]) break;
			Exchange(array, currentIndex, nextIndex);
			currentIndex = nextIndex;
		}
	}

	private void Exchange(int[] array, int a, int b)
	{
		var temp = array[a];
		array[a] = array[b];
		array[b] = temp;
	}

	void Heapify(int[] arr, int lastIndex, int i)
	{
		int largest = i; // Initialize largest as root 
		int l = 2 * i; // left 
		int r = 2 * i + 1; // right = 2*i + 2 

		// If left child is larger than root 
		if (l <= lastIndex && arr[l] > arr[largest])
			largest = l;

		// If right child is larger than largest so far 
		if (r <= lastIndex && arr[r] > arr[largest])
			largest = r;

		// If largest is not root 
		if (largest != i)
		{
			int swap = arr[i];
			arr[i] = arr[largest];
			arr[largest] = swap;

			// Recursively heapify the affected sub-tree 
			Heapify(arr, lastIndex, largest);
		}
	}
}