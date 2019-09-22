public class MergeTwoBinaryTrees
{
		// 		Tree 1                     Tree 2                  
		//       1                         2                             
		//      / \                       / \                            
		//    1-> 3   2                     1   3                        
		//    /                           \   \                      
		//   5                             4   7                  


		// static void Main(string[] args)
		// {
		// 	var tree1 = new TreeNode(1);
		// 	tree1.left = new TreeNode(3);
		// 	tree1.right = new TreeNode(2);
		// 	tree1.left.left = new TreeNode(5);

		// 	var tree2 = new TreeNode(2);
		// 	tree2.left = new TreeNode(1);
		// 	tree2.right = new TreeNode(3);
		// 	tree2.left.right = new TreeNode(4);
		// 	tree2.right.right = new TreeNode(7);

		// 	MergeTrees(tree1, tree2);
		// }
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}
	public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
	{
		if (t1 == null) return t2;
		if (t2 == null) return t1;

		var root = new TreeNode(t1.val + t2.val);
		System.Console.WriteLine("root -> " + root.val);
		root.left = MergeTrees(t1.left, t2.left);
		System.Console.WriteLine("left -> " + root.left.val);

		root.right = MergeTrees(t1.right, t2.right);
		System.Console.WriteLine("right	 -> " + root.right.val);

		return root;
	}
}
