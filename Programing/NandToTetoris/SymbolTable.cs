using System.Collections.Generic;

public class SymbolTable
{
	Dictionary<string, int> symbols = new Dictionary<string, int>();
	const int SCREEN_ADDRESS = 16384;
	const int KBD_ADDRESS = 24576;

	public SymbolTable()
	{
		symbols.Add("SP", 0);
		symbols.Add("LCL", 1);
		symbols.Add("ARG", 2);
		symbols.Add("THIS", 3);
		symbols.Add("THAT", 4);
		for (int i = 0; i <= 15; i++)
		{
			symbols.Add("R" + i.ToString(), i);
		}

		symbols.Add("SCREEN", SCREEN_ADDRESS);
		symbols.Add("KBD", KBD_ADDRESS);
	}

	public void AddEntry(string symbol, int address)
	{
		symbols.Add(symbol, address);
	}

	public bool Contains(string symbol)
	{
		return symbols.ContainsKey(symbol);
	}

	public string GetAddress(string symbol)
	{
		return symbols[symbol].ToString();
	}
}