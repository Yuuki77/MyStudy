using static ConvertSortedArrayToBinarySearchTree;

namespace lineAralgebra
{


	class Program
	{
		// 		5
		//    / \
		//   3  6
		//  /\ /  \
		//  2 1 12   5
		static void Main(string[] args)
		{
			var root = new TreeNode(5);
			root.right = new TreeNode(6);
			root.right.right = new TreeNode(5);
			root.right.left = new TreeNode(12);

			root.left = new TreeNode(3);
			root.left.left = new TreeNode(2);
			root.left.right = new TreeNode(1);

			// var path = new SalePath();
			var sum = new HasSums();
			System.Console.WriteLine("answer is" + sum.HasPathSum(root, 10));
		}
	}
}