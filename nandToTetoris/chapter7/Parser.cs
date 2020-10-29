using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chapter7
{
	public class Parser
	{
		public static string debugcurrentCommand;
		public CommandType commandType;
		public string arg1;
		public int arg2;

		public string firstCommand;
		private List<string> lines;
		private int currentLine;

		public Parser(string fileName)
		{
			this.lines = new List<string>();

			foreach (var line in System.IO.File.ReadLines(fileName))
			{
				Regex.Replace(line, @"\s+", "");
				var trimmedLine = line.Trim();
				int index = line.IndexOf("/");
				if (String.IsNullOrEmpty(trimmedLine) || trimmedLine[0] == '/') continue;
				trimmedLine = index != -1 ? trimmedLine.Split('/')[0] : trimmedLine;

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
			System.Console.WriteLine("current line " + line);
			debugcurrentCommand = line;

			var commands = line.Split(' ');
			this.firstCommand = commands[0];

			this.commandType = GetCommandType(commands[0]);

			if (this.commandType == CommandType.C_PUSH || this.commandType == CommandType.C_POP)
			{
				this.arg1 = commands[1];
				this.arg2 = int.Parse(commands[2]);
			}
			else if (this.commandType == CommandType.C_IF || this.commandType == CommandType.C_LABEL)
			{
				this.arg1 = commands[1];
				System.Console.WriteLine("current command" + commandType);
				System.Console.WriteLine("args" + arg1);
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
				case "pop":
					return CommandType.C_POP;
				case "label":
					return CommandType.C_LABEL;
				case "if-goto":
					return CommandType.C_IF;
				default:
					return CommandType.C_ARITHMETIC;
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