using System;
using System.Linq;

namespace lineAralgebra
{


	class Program
	{
		public class TreeNode {
			public int val;
			public TreeNode right;
			public TreeNode left;

			public TreeNode(int n) {
				this.val = n;
			}
		}
		static void Main(string[] args)
		{
			var root = new TreeNode(1);
			root.right = new TreeNode(2);
			root.left = new TreeNode(1);
		}

		
	}
}
//  b = 15