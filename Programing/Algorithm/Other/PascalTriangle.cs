using System.Collections;
using System.Collections.Generic;

public class PascalTriangle
{
	public IList<IList<int>> Generate(int numRows)
	{
		IList<IList<int>> list = new List<IList<int>>();
		if (numRows == 0) return list;
		IList<int> first = new List<int>();
		first.Add(1);

		list.Add(first);

		if (numRows == 1)
		{
			return list;
		}

		for (var i = 1; i < numRows; i++)
		{
			var prevRow = list[i - 1];
			IList<int> row = new List<int>();
			row.Add(1);
			for (var j = 1; j < i; j++)
			{
				row.Add(prevRow[j - 1] + prevRow[j]);
			}

			row.Add(1);
			list.Add(row);
		}

		return list;
	}
}