// using System.Collections.Generic;
// public class BinaryTreeLevelOrderTraversal
// {

// 	public List<List<int>> Solve(ConvertSortedArrayToBinarySearchTree.TreeNode node)
// 	{

// 		var result = new List<List<int>>();

// 		Queue<ConvertSortedArrayToBinarySearchTree.TreeNode> queue = new Queue<ConvertSortedArrayToBinarySearchTree.TreeNode>();

// 		queue.Enqueue(node);

// 		while (queue.Count != 0)
// 		{
// 			var size = queue.Count;

// 			var currentLevel = new List<int>();
// 			for(var i = 0; i < size; i++) {
// 				var current = queue.Dequeue();
// 				currentLevel.Add(current.val);

// 				if (current.left != null) {
// 					queue.Enqueue(current.left);
// 				}

// 				if (current.right != null) {
// 					queue.Enqueue(current.right);
// 				}
// 			}

// 			result.Add(currentLevel);
// 		}

// 		return result;
// 	}
// }