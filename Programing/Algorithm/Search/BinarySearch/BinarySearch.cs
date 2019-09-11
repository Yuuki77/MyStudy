using System;

public class BinarySearch
{

	public int Find(int[] array, int target)
	{

		return Find(array, target, 0, array.Length);
	}

	private int Find(int[] array, int target, int lo, int hi)
	{
		if (hi <= lo) return -1;

		var middle = lo + (hi - lo) / 2;

		if (array[middle] == target) return middle;
		else if (array[middle] > target)
		{
			return Find(array, target, lo, middle);
		}
		else
		{
			return Find(array, target, middle + 1, hi);
		}
	}

	public int Find2(int[] array, int target)
	{

		return Find2(array, target, 0, array.Length - 1);
	}

	private int Find2(int[] array, int target, int lo, int hi)
	{
		if (hi < lo) return lo;

		int middle = lo + (hi - lo) / 2;

		if (array[middle] == target) return middle;

		if (array[middle] > target)
		{
			return Find2(array, target, lo, middle - 1);
		}
		else
		{
			return Find2(array, target, middle + 1, hi);
		}
	}

		// テストコード　fo test
	     // 配列が偶数ならきれいに分けることができなくて、
        // 答えが一番端の答えだった時に 要素すうが半分のほうが[1,2 3]でtargetが1の場合
        //  middle = 2/2 = 1;
        // そして一番最後にもう一度分割して答えを探していくのでlo = 0 hi = 0ってパターンがあるんだ
        // これをしなくていいパターンについて再度考えてみたいね

		// static void Main(string[] args)
		// {
		// 	Console.WriteLine("Hello World!");
        //     var input = new int[]{1,3,5,6,7,8};

        //     var ans1 = BinarySearch1(input, 0, input.Length -1, 8);
        //     Console.WriteLine("serach 1 result" + ans1);
            
        //     var ans2 = BinarySearch2(input, 0, input.Length -1, 8);
        //     Console.WriteLine("serach 2 result" + ans2);
            
		// }


		// e
		public static int BinarySearch1(int[] a, int lo, int hi, int target)
		{
			while (lo <= hi)
			{
				var middle = lo + (hi - lo) / 2;
                System.Console.WriteLine("lo -> " + lo + " hi -> " + hi + " middle -> " + middle);
				if (a[middle] == target) return middle;
				else if (target < a[middle])
				{
					hi = middle - 1;
				}
				else
				{
					lo = middle + 1;

				}
			}

			return -1;
		}

		public static int BinarySearch2(int[] a, int lo, int hi, int target)
		{
			while (lo < hi)
			{
				var middle = lo + (hi - lo) / 2;
                System.Console.WriteLine("lo -> " + lo + " hi -> " + hi + " middle -> " + middle);
				if (a[middle] == target) return middle;
				else if (target < a[middle])
				{
					hi = middle - 1;
				}
				else
				{
					lo = middle + 1;

				}
			}

            return -1;
		}
}