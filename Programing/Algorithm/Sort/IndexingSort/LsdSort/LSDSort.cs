public class LSDSort
{
	// w is the fixed length of strings
	public void Sort(string[] a, int w)
	{
		int r = 256;
		int n = a.Length;

		var aux = new string[n];

		for (var d = w - 1; d >= 0; d--)
		{
			// do the counting sort
			// make the count array
			// 1. fist calculate frequency of each element
			//2. sum up the previous value to get the start index of the element
			// 3. loop the a by using count. find the index of aux
			// copy back to the original element

			int [] count = new int[r + 1];

			for(var i = 0 ; i < a.Length; i++) {
				count[(int)a[i][d] + 1]++;
			}

			for(var i = 0; i < r; i++) {
				count[i + 1] += count[i];
			}

			for(var i = 0; i < n; i++) {
				aux[count[(int)a[i][d]]++] = a[i];
			}

			for(var i = 0; i < n; i++) {
				a[i] = aux[i];
			}



		}

	}
}