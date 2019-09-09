using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lineAralgebra
{
	class Program
	{
  public static string[,] WordCountEngine(string document)
		{
			// your code goes here
			//var array = document.Split(' ');
     document = document.ToLower();
			var cleanString = "";
			for (var i = 0; i < document.Length; i++)
			{
				var chara = document[i];
				if (chara >= 'a' && chara <= 'z' ||  chara == ' ') cleanString += document[i];
			}

			document = cleanString;
			var dictionary = new Dictionary<string, int>();

			string[] sentenses = document.Split(' ');

			foreach (var item in sentenses)
			{
				System.Console.WriteLine(item);	
			}

			for (var i = 0; i < sentenses.Length; i++)
			{
				var word = sentenses[i].ToLower();
				if (dictionary.ContainsKey(word))
				{
					dictionary[word]++;
				}
				else
				{
					dictionary[word] = 1;
				}
			}

			// to the counting sort

			// first coun the frequency of each word
			// offset by 1 to make the calculation easier.
			var count = new int[sentenses.Length + 1];
			var temp = new string[sentenses.Length];

			for (var i = 1; i < sentenses.Length; i++)
			{
				var sentense = sentenses[i];
				count[dictionary[sentense] + 1]++;
			}

			// transform the arry to konw how many element exists before ith element
			for (var i = 0; i < sentenses.Length; i++)
			{
				count[i + 1] += count[i];
			}

			for (var i = sentenses.Length -1 ;i >= 0; i--)
			{
				var sentense = sentenses[i];
				temp[count[dictionary[sentense]]++] = sentense;
			}

			var ans = new string[temp.Length, 2];
     
			var index = 0;
			for (var i = temp.Length - 1; i >= 0; i--)
			{
				if (string.IsNullOrEmpty(temp[i])) continue;
				ans[index, 0] = temp[i];
				ans[index, 1] = dictionary[temp[i]].ToString();
				index++;
			}


			return ans;
		}

		/*
		List<string>[] coutingList = new List<string>[dictionary.Count];
		// var coutingList = new List<string>
		// https://stackoverflow.com/questions/7464724/an-array-of-list-in-c-sharp

		foreach(var key in dictionary.Keys) {
		  var val = dictionary[key];
		  coutingList[val].Add(key);
		}


		var ans = new string[dictionary.Count,dictionary.Count];
		var index = 0;
		for(var i = coutingList.Length -1; i >= 0; i--) {
		  for(var j = 0; j < coutingList[i].Count; j++) {
			if (coutingList[i] == null) continue;
			var word = coutingList[i][j];
			ans[index, 0] = word;
			ans[index, 1] = i.ToString();
			index++;
		  }
		}

		// int ans = new string[]
		return ans;

		*/

		static void Main(string[] args)
		{
			var input = "Practice makes perfect, you'll get perfecT by practice. just practice! just just just!!";

			WordCountEngine(input);
			// 	var n = int.Parse(Console.ReadLine());

			// 	var list = new List<int>();

			// 	for (int i = 0; i < n; i++)
			// 	{
			// 		list.Add(int.Parse(Console.ReadLine()));
			// 	}

			// 	var tempArray = new List<int>(list);

			// 	tempArray.Sort();
			// 	var max = tempArray.Last();
			// 	// Console.WriteLine("");

			// 	for (var i = 0; i < n; i++)
			// 	{
			// 		if (list[i] != max) 
			// 		{
			// 			Console.WriteLine(max);
			// 		} else 
			// 		{
			// 			Console.WriteLine(tempArray[tempArray.Count -2]);
			// 		}
			// 	}
			// }
		}
	}
}

// 3
// 1
// 4
// 3