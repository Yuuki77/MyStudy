public class RedBlackTree
{
	private Node root;

	public Node RotateLeft(Node h)
	{
		var x = h.right;
		h.right = x.left;
		x.left = h;
		x.isRead = h.isRead;
		h.isRead = true;
		x.n = h.n;
		//h.n = 1 + size
		return x;
	}

	public Node RotateRight(Node h)
	{
		Node x = h.left;
		h.left = x.right;
		x.right = h;
		x.isRead = h.isRead;
		h.isRead = true;

		return x;
	}

	public void Put(int key)
	{
		root = Put(root, key);
	}

	private Node Put(Node h, int key)
	{
		if (h == null)
		{
			return new Node(key, 1, true);
		}

		if (key < h.key)
		{
			h.left = Put(h.left, key);
		}
		else if (key > h.key)
		{
			h.right = Put(h.right, key);
		}
		else
		{
			h.key = key;
		}

		if (IsRead(h.right) && !IsRead(h.left)) h = RotateLeft(h);
	}

	private void FlipColors(Node h)
	{
		h.isRead = true;
		h.left.isRead = false;
		h.right.isRead = false;
	}

	private bool IsRead(Node x)
	{
		return x != null && x.isRead;
	}

	public class Node
	{
		public bool isRead;
		public int n;
		public Node right;
		public Node left;

		public int key;

		public Node(int key, int n, bool isRead)
		{
			this.isRead = isRead;
			this.key = key;
			this.n = n;
		}
	}
}