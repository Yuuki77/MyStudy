using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chapter7
{
	public class Parser
	{
		public CommandType commandType;
		public string arg1;
		public int arg2;
		private List<string> lines;
		private int currentLine;

		public Parser(string fileName)
		{
			this.lines = new List<string>();
			// Console.WriteLine(System.IO.File.ReadAllLines(fileName));

			// var lines = System.IO.File.ReadAllLines(fileName);

			foreach (var line in System.IO.File.ReadLines(fileName))
			{
				Regex.Replace(line, @"\s+", "");
				var trimmedLine = line.Trim();
				int index = line.IndexOf("/");
				if (String.IsNullOrEmpty(trimmedLine) || trimmedLine[0] == '/') continue;
				trimmedLine = index != -1 ? trimmedLine.Split('/')[0] : trimmedLine;

				// if (line[0] == '(')
				// {
				// 	var key = line.Substring(1, line.Length - 2);
				// 	symbolTable.AddEntry(key, lines.Count);
				// 	System.Console.WriteLine("continue is called" + key);
				// 	continue;
				// }

				lines.Add(trimmedLine);
			}


		}

		public void Advance()
		{
			if (!HasMoreCommands())
			{
				throw new Exception("No more commands Man");
			}

			var line = lines[currentLine++];
			System.Console.WriteLine("current line" + line);
			var commands = line.Split(' ');

			this.commandType = GetCommandType(commands[0]);

			if (this.commandType == CommandType.C_PUSH)
			{
				this.arg1 = commands[1];
				this.arg2 = int.Parse(commands[2]);
			}
			else
			{
				this.arg1 = commands[0];
			}
		}

		public bool HasMoreCommands()
		{
			return currentLine < lines.Count;
		}

		private CommandType GetCommandType(string type)
		{
			switch (type)
			{
				case "push":
					return CommandType.C_PUSH;
				// case "add":
				// 	return CommandType.Add;

				default:
					return CommandType.C_ARITHMETIC;
					// throw new Exception("Unexpected command type" + type);

			}

		}

	}

	public enum CommandType
	{
		C_ARITHMETIC,
		C_PUSH,
		C_POP,
		C_LABEL,
		C_GOTO,
		C_IF,
		C_FUNCTION,
		C_RETURN,
		C_CALL

	}

}