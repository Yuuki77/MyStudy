using System;
using static ConvertSortedArrayToBinarySearchTree;

public class MinDepths
{
	public int MinDepth(TreeNode root)
	{
	    if (root == null) return 0;
            
        if (root.right == null && root.left == null) return 1;
        
        var leftDepth = int.MaxValue;
        if (root.left != null) {
            leftDepth = MinDepth(root.left);
        }
        
        var rightDepth = int.MaxValue;
        
        if (root.right != null) {
            rightDepth = MinDepth(root.right);
        }
        
        return Math.Min(rightDepth, leftDepth) + 1;
	}
}