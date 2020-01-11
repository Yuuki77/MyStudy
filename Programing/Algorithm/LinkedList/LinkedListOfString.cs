public class LinkedListOfString
{
	private class Node
	{
		public Node next;
		public string item;

		public Node(string item)
		{
			this.item = item;
		}
	}

	private Node first;

	public bool IsEmpty()
	{
		return first == null;
	}

	public void Push(string item)
	{
		var oldFirst = first;
		first = new Node(item);
		first.next = oldFirst;
	}

	public string Pop()
	{
		var val = first.item;
		first = first.next;
		return val;
	}
}