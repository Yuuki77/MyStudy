using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

public class Parser
{
	private Code code;
	public string fileName;
	private List<string> lines;
	private SymbolTable symbolTable;
	private int currentLine;
	private int n;
	public string symbol;

	private string dest;

	public string comp;

	public string jump;

	public CommandType commandType;

	public Parser(string fileName)
	{
		this.code = new Code();
		this.fileName = fileName;
		this.lines = new List<string>();
		this.symbolTable = new SymbolTable();

		foreach (var line in System.IO.File.ReadAllLines(fileName))
		{
			Regex.Replace(line, @"\s+", "");
			var trimmedLine = line.Trim();
			int index = line.IndexOf("/");
			if (String.IsNullOrEmpty(trimmedLine) || trimmedLine[0] == '/') continue;
			trimmedLine = index != -1 ? trimmedLine.Split('/')[0] : trimmedLine;

			if (line[0] == '(')
			{
				var key = line.Substring(1, line.Length - 2);
				symbolTable.AddEntry(key, lines.Count);
				System.Console.WriteLine("continue is called" + key);
				continue;
			}

			lines.Add(trimmedLine);
		}

		this.currentLine = 0;
		this.n = 16;

		foreach (var line in lines)
		{
			var currentSymbol = line.Substring(1, line.Length - 1);
			System.Console.WriteLine(currentSymbol);
			if (line[0] == '@' && !symbolTable.Contains(currentSymbol) && !int.TryParse(currentSymbol, out _))
			{
				symbolTable.AddEntry(currentSymbol, n++);
			}
		}
	}

	public bool HasMoreCommands()
	{
		return currentLine < lines.Count;
	}

	public void Advance()
	{
		if (!HasMoreCommands())
		{
			throw new Exception("No more commands Man");
		}

		var line = lines[currentLine++];
		var firstLetter = line[0];

		if (firstLetter == '@')
		{
			commandType = CommandType.ACommand;
			SetACoomand(line);
		}
		else
		{
			commandType = CommandType.CCommand;
			SetCCommand(line);
		}
	}

	private void SetACoomand(string line)
	{
		var command = line.Substring(1);
		commandType = CommandType.ACommand;
		symbol = command;
	}

	public void SetCCommand(string line)
	{
		commandType = CommandType.CCommand;
		if (line.Contains("="))
		{
			var components = line.Split('=');
			System.Console.WriteLine("Component length" + components.Length);
			dest = components[0];
			comp = components[1];
			jump = "";
		}
		else
		{
			System.Console.WriteLine("line" + line);
			var components = line.Split(';');
			comp = components[0];
			jump = components[1];

			System.Console.WriteLine(comp);
			System.Console.WriteLine(jump);
			dest = "";
		}
	}

	public string Symbol()
	{
		if (commandType != CommandType.ACommand)
		{
			throw new Exception("No symbol" + commandType);
		}

		System.Console.WriteLine("symbol" + symbol);
		if (symbolTable.Contains(symbol))
		{
			symbol = symbolTable.GetAddress(symbol);
		}

		int val = int.Parse(symbol);
		string binary = Convert.ToString(val, 2);
		binary = binary.PadLeft(16, '0');
		Debug.Assert(binary.Length == 16, "actual length is " + symbol.Length + "val " + symbol);
		return binary;
	}

	public string Comp()
	{
		if (commandType != CommandType.CCommand)
		{
			throw new Exception("No comp" + commandType);
		}

		return code.Comp(comp);
	}

	public string Jump()
	{
		if (commandType != CommandType.CCommand)
		{
			throw new Exception("No Jump" + commandType);
		}

		return code.Jump(jump);
	}

	public string Dest()
	{
		if (commandType != CommandType.CCommand)
		{
			throw new Exception("No Dest" + commandType);
		}

		return code.Dest(dest);
	}

	public enum CommandType
	{
		ACommand,
		CCommand,
	}
}