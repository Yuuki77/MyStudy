public class CountingSort
{

	// key -index counting is an int [0,R)
	public void Sort(char[] array, int R)
	{
		int n = array.Length;

		var count = new int[R + 1];
		char[] temp = new char[n];

		// count the frequency of the each word
		for(var i = 0; i < n;i++) {
			var ch = array[i];
			count[(int)ch + 1]++;
		}

		// transforms cont to indices
		for(var r = 0; r < R; r++) {
			count[r + 1] += count[r]; 	
		}

		// Distribute the records
		for(var i = 0; i < n; i++) {
			temp[count[array[i]]++] = array[i];
		}

		for(var i = 0; i < n;i++) {
			array[i] = temp[i];
		}
	}
}