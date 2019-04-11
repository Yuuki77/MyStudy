using System;
using System.Collections.Generic;

public class TwoSum
{

	public int[] Solve(int[] nums, int target)
	{
		// 2, 7, 11, 15
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[j] == target - nums[i])
				{
					return new int[] { i, j };
				}
			}
		}
		throw new Exception("No two sum solution");
	}

	public int[] Solve2(int[] nums, int target)
	{
		// 2, 7, 11, 15
		 Dictionary <int, int> map = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++)
		{
			map.Add(nums[i], i);
		}

		for (int i = 0; i < nums.Length; i++)
		{
			int complement = target - nums[i];
			if (map.ContainsKey(complement) && map[complement] != i)
			{
				return new int[] { i, map[complement] };
			}
		}
		throw new Exception("No two sum solution");
	}

	public int[] twoSum(int[] nums, int target) {
				// 2, 7, 11, 15

		 Dictionary <int, int> map = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++) {
			int complement = target - nums[i];
			if (map.ContainsKey(complement)) {
				return new int[] { map[complement], i };
			}
			map[nums[i]] = i;
		}
		throw new Exception("No two sum solution");
	}
}