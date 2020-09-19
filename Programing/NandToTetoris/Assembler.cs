
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public class Assembler
{
	public void Process()
	{
		var input = Console.ReadLine();
		var parser = new Parser(input);

		string path = Path.GetDirectoryName(input);
		string fileName = Path.GetFileNameWithoutExtension(input);
		var results = new List<string>();

		while (parser.HasMoreCommands())
		{
			parser.Advance();
			if (parser.commandType == Parser.CommandType.ACommand)
			{
				var symbol = parser.Symbol();
				results.Add(symbol);
				return;
			}

			// C command
			var comp = parser.Comp();
			var dest = parser.Dest();
			var jump = parser.Jump();

			Debug.Assert(comp.Length == 7);
			Debug.Assert(dest.Length == 3, "dest length" + dest.Length + "dest" + dest);
			Debug.Assert(jump.Length == 3);

			var output = "111" + comp + dest + jump;
			results.Add(output);
		}

		File.WriteAllLines(path + "/" + fileName + ".hack", results);
	}
}