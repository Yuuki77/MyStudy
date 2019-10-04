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

		// [0,   2, 10],
		//           [3,   5,  0],
		//           [9,  20,  6],
		//           [10, 12, 15],
		//           [10, 10,  8]
		static void Main(string[] args)
		{
			int[,] array2D = new int[,] { { 0, 2, 10 }, { 3, 5, 0 }, { 9, 20, 6 }, { 10, 12, 15 } };
			var a = new CalculateDroneDistance();
			a.Solve(array2D);

		}
	}
}


	// while(lo <= hi) {
	//     var middle = lo + (hi - lo) /2;

//     if (arr[middle] == middle) return middle;
//     if (arr[middle] - middle > 0) {
//       hi = middle -1;
//     } else{
//       lo = middle +1;
//     }
//   }
//   return -1;