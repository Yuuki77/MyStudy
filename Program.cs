using System;
using System.Linq;

namespace lineAralgebra
{


	class Program
	{
		static void Main(string[] args)
		{
			var input = new int[11];
			for(var i = 0; i <= 10; i++) {
				input[i] = i;
			}

			var bst = new RedBlackTreeDemo();

			foreach(var i in input) {
				bst.Put(i, i);
			}
		}		
	}
}
//  b = 15