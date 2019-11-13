public class RedBlackTreeDemo
{
	private static bool RED = true;
	private static bool BLACK = false;
	private class TreeNode
	{
		public TreeNode left;
		public TreeNode right;
		public bool color;
		public int key;
		public int value;
	
		public TreeNode(int key, int value)
		{
			this.key = key;
			this.value = value;
			this.color = RED;
		}
	}

	private TreeNode RotateLeft(TreeNode e)
	{
		var s = e.right;
		e.right = s.left;
		s.left = e;
		s.color = e.color;
		e.color = RED;

		return s;
	}

	private TreeNode RotateRight(TreeNode e)
	{
		var s = e.left;
		e.left = s.right;
		s.right = e;
		s.color = e.color;
		e.color = RED;
		return s;
	}

	private void FlipColors(TreeNode h)
	{
		h.color = RED;
		h.left.color = BLACK;
		h.right.color = BLACK;
	}

	private TreeNode root;
	public void Put(int key, int value)
	{
		root = Put(root, key, value);
		root.color = RED;
	}

	private TreeNode Put(TreeNode node, int key, int value)
	{
		if (node == null) return new TreeNode(key, value);

		System.Console.WriteLine("current" + node);
		if (key < node.key)
		{
			node.left = Put(node.left, key, value);
		}
		else if (key > node.key)
		{
			node.right = Put(node.right, key, value);
		}
		else
		{
			node.value = value;
		}

		// 頂点２
		if (IsRed(node.right) && !IsRed(node.left)) {
			node = RotateLeft(node);
		} else if (IsRed(node.left) && IsRed(node.left.left)) {
			node = RotateRight(node);
		} 
		if (IsRed(node.left) && IsRed(node.right)) {
			FlipColors(node);
		}

		return node;
	}

	private bool IsRed(TreeNode node)
	{
		if (node == null) return false;
		return node.color == RED;
	}
}