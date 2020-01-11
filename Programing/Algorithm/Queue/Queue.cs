using System;

public class Queue<Item>
{
	private Node first;
	private Node last;
	public int size;

	private class Node
	{
		public Item item;
		public Node next;

		public Node(Item item)
		{
			this.item = item;
		}
	}

	Item[] items;

	public Queue()
	{
		items = new Item[1];
	}

	public void Enqueue(Item item)
	{
		var oldLast = last;
		last = new Node(item);
		if (IsEmpty())
		{
			first = last;
		}
		else
		{
			oldLast.next = last;
		}

		size++;
	}

	private bool IsEmpty()
	{
		return size == 0;
	}

	public Item Dequeue()
	{
		Item item = first.item;
		first = first.next;
		this.size--;
		if (IsEmpty()) last = null;

		return item;
	}
}