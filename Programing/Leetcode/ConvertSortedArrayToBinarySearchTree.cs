public class ConvertSortedArrayToBinarySearchTree
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}
	public TreeNode SortedArrayToBST(int[] nums)
	{
		return Solve(nums, 0, nums.Length - 1);
	}

	private TreeNode Solve(int[] nums, int start, int end)
	{
		if (end < start) {
			return null;
		} 
		var middle = start + ((end - start) / 2);

		var val = nums[middle];
		var tree = new TreeNode(val);

		tree.left = Solve(nums, start, middle - 1);
		tree.right = Solve(nums, middle + 1, end);
		return tree;
	}
}