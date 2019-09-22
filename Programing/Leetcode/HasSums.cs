using static ConvertSortedArrayToBinarySearchTree;

public class HasSums
{
	public bool HasPathSum(TreeNode root, int sum)
	{
		if (root == null) return false;

		if (root.left == null && root.right == null)
		{
			var ans = root.val == sum;
			return root.val == sum;
		}
		
		var left = HasPathSum(root.left, sum - root.val);
		if (left) return true;
		var right = HasPathSum(root.right, sum - root.val);
		return left;
	}
}