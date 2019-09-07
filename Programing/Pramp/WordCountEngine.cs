using System.Collections.Generic;
using System.Linq;

public class WordCountEngine
{
		// https://www.pramp.com/challenge/W5EJq2Jld3t2ny9jyZXG

	// dictionary の valueの入り方
	// 2d array よくわからん　復習
	public static string[,] Solve(string document)
	{
		document = document.ToLower();
		var cleanString = "";
		for (var i = 0; i < document.Length; i++)
		{
			var chara = document[i];
			if (chara >= 'a' && chara <= 'z' || chara == ' ') cleanString += document[i];
		}

		document = cleanString;
		var dictionary = new Dictionary<string, int>();

		string[] sentenses = document.Split(' ');

		for (var i = 0; i < sentenses.Length; i++)
		{
			var word = sentenses[i].ToLower();
			if (string.IsNullOrEmpty(word)) continue;
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

		var countLength = dictionary.Keys.Count;
		//   dict.Keys.ElementAt(5)
		// first coun the frequency of each word
		// offset by 1 to make the calculation easier.
		var count = new int[countLength + 1];
		var temp = new string[countLength];

		for (var i = 0; i < countLength; i++)
		{
			var sentense = dictionary.Keys.ElementAt(i);

			count[dictionary[sentense] + 1]++;
		}

		// transform the arry to konw how many element exists before ith element
		for (var i = 0; i < countLength; i++)
		{
			count[i + 1] += count[i];
		}

		for (var i = dictionary.Keys.Count - 1; i >= 0; i--)
		{
			var sentense = dictionary.Keys.ElementAt(i);
			temp[count[dictionary[sentense]]++] = sentense;
		}

		var ans = new string[temp.Length, 2];

		var index = 0;
		for (var i = temp.Length - 1; i >= 0; i--)
		{
			ans[index, 0] = temp[i];
			ans[index, 1] = dictionary[temp[i]].ToString();
			index++;
		}


		return ans;
	}
}