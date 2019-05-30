using System;

public class MyList
{

	public int[] array;
	private int current;

	public MyList() 
	{
		array = new int[1];
	}

	public void Add(int value) {
		if (array.Length -1 == current) {
			resize();
		}

		array[current++] = value;
	}

	private void resize()
	{
		var newArray = new int[array.Length * 2];
		for(var i = 0; i < array.Length; i++) {
			newArray[i] = array[i];
		}

		array = newArray;
	}
}