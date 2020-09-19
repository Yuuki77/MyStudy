using System.Collections.Generic;

public class Code
{
	Dictionary<string, string> compA0 = new Dictionary<string, string>();
	Dictionary<string, string> compA1 = new Dictionary<string, string>();
	Dictionary<string, string> dest = new Dictionary<string, string>();
	Dictionary<string, string> jump = new Dictionary<string, string>();


	public Code()
	{
		compA0.Add("0", "101010");
		compA0.Add("1", "111111");
		compA0.Add("-1", "111010");
		compA0.Add("D", "001100");
		compA0.Add("A", "110000");
		compA0.Add("!D", "001101");
		compA0.Add("!A", "110001");
		compA0.Add("-D", "001111");
		compA0.Add("-A", "110011");
		compA0.Add("D+1", "011111");
		compA0.Add("A+1", "110111");
		compA0.Add("D-1", "001110");
		compA0.Add("A-1", "110010");
		compA0.Add("D+A", "000010");
		compA0.Add("D-A", "010010");
		compA0.Add("A-D", "000111");
		compA0.Add("D&A", "000000");
		compA0.Add("D|A", "010101");

		compA1.Add("M", "110000");
		compA1.Add("!M", "110001");
		compA1.Add("M+1", "110111");
		compA1.Add("M-1", "110010");
		compA1.Add("D+M", "000010");
		compA1.Add("D-M", "010011");
		compA1.Add("M-D", "000111");
		compA1.Add("D&M", "000000");
		compA1.Add("D|M", "010101");

		//
		dest.Add("", "000");
		dest.Add("M", "001");
		dest.Add("D", "010");
		dest.Add("MD", "011");
		dest.Add("A", "100");
		dest.Add("AM", "101");
		dest.Add("AD", "110");
		dest.Add("AMD", "111");

		jump.Add("", "000");
		jump.Add("JGT", "001");
		jump.Add("JEQ", "010");
		jump.Add("JGE", "011");
		jump.Add("JLT", "100");
		jump.Add("JNE", "101");
		jump.Add("JLE", "110");
		jump.Add("JMP", "111");
	}

	public string Dest(string key)
	{
		System.Console.WriteLine("Dest key" + key + "dest value" + dest[key]);
		return dest[key].ToString();
	}

	public string Comp(string key)
	{
		key = key.Trim();
		System.Console.WriteLine("Compare key is " + key);
		System.Console.WriteLine("Compare length" + key.Length);

		if (compA0.ContainsKey(key))
		{
			return "0" + compA0[key];
		}

		return "1" + compA1[key];

	}

	public string Jump(string jumpKey)
	{
		System.Console.WriteLine(jumpKey);
		jumpKey = jumpKey.Trim();

		return jump[jumpKey].ToString();
	}
}