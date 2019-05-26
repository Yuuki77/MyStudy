using System;
using System.Collections.Generic;
using System.Linq;

namespace lineAralgebra
{
	class SequenceTherom
	{
		static void Solve(string[] args)
		{
			var inputs = new List<int> { 1, 1, 1, 2, 2, 3, 4, 5, 5 };

			bool ok = Solve(inputs).Sum() == 0;

			if (ok)
			{
				Console.WriteLine("Yes");
			}
			else
			{
				Console.WriteLine("No");
			}
		}

		private static List<int> Solve(List<int> inputs)
		{

			if (inputs.Sum() == 0 || inputs.Sum() % 2 != 0)
			{
				return inputs;
			}

			for (int i = 0; i < inputs.Count; i++)
			{
				if (i >= (inputs.Count - 1 - inputs[inputs.Count - 1]))
				{
					inputs[i]--;
				}
			}

			inputs.Sort();
			inputs.RemoveAt(inputs.Count - 1);

			foreach (var item in inputs)
			{
				Console.Write(item);
			}
			Console.WriteLine("");
			var deepCopyList = new List<int>(inputs);

			return Solve(inputs);
		}
	}
}