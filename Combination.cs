using System;
using System.Collections.Generic;
using System.Linq;

public class Combination
{
	public List<List<int>> Results
	{
		get
		{
			return results;
		}
	}

	private List<List<int>> results = new List<List<int>>();
	private int[] inputs;
	private int r;

	public Combination(int[] input, int r)
	{
		this.inputs = input;
		this.r = r;

		Solve(0, new List<int>());
	}

	public List<int> Solve(int index, List<int> current)
	{
		if (index == r)
		{
			if (current.Count != r) throw new Exception("Unexpected current count" + current.Count);

			// 重複のチェック　重複があれば、result に追加しない(このチェックをいれないと、順列になる)
			if (!IsDuplicated(current))
			{
				results.Add(current);
			}

			return current;
		}

		for (var i = 0; i < inputs.Length; i++)
		{
			var copy = new List<int>(current);
			if (!copy.Contains(inputs[i]))
			{
				copy.Add(inputs[i]);
				Solve(index + 1, copy);
			}
		}

		return current;
	}

	private bool IsDuplicated(List<int> value)
	{
		foreach (var result in results)
		{
			if (result.All(value.Contains))
			{
				return true;
			}
		}
		return false;
	}
}
