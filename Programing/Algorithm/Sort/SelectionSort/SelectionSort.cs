using System;
using System.Collections.Generic;
using System.Linq;

public class SelectionSort
{
	public void Sort(int[] array)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var minIndex = i;
			for (var j = i + 1; j < array.Length; j++)
			{
				if (array[j] < array[minIndex])
				{
					minIndex = j;
				}
			}

			Swap(minIndex, i, array);
		}
	}

	private void Swap(int minIndex, int i, int[] array)
	{
		var temp = array[minIndex];
		array[minIndex] = array[i];
		array[i] = temp;
	}
}

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var map = new Dictionary<string, IList<string>>();
        
        foreach (var str in strs) {
            var charStr = str.ToCharArray();
            Array.Sort(charStr);
            if(!map.ContainsKey(charStr.ToString())) {
                map[charStr.ToString()] = new List<string>();
            }
            map[charStr.ToString()].Add(str);
        }
		 IList<IList<string>> a = map.Values.ToList();
         return a;
    }
}