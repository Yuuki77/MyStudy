public class LinkedListResizingArray
{
	private string[] items = new string[1];

	private int n = 0;

	public bool IsEmpty()
	{
		return n == 0;
	}

	private void Resize(int capacity)
	{
		string[] temp = new string[capacity];

		for (var i = 0; i < n; i++)
		{
			System.Console.WriteLine(i);
			temp[i] = items[i];
		}

		items = temp;
	}

	public void Push(string x)
	{
		if (n == items.Length)
		{
			Resize(n * 2);
		}
		items[n++] = x;
	}

	public string Pop()
	{
		var item = items[--n];
		items[n] = "";
		if (n > 0 && n == items.Length / 4)
		{
			Resize(items.Length / 2);
		}

		return item;
	}
}