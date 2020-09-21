using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter7
{
	public class CodeWriter
	{
		List<int> argument = new List<int>();
		List<int> local = new List<int>();
		List<int> staticStack = new List<int>();
		List<int> constantStack = new List<int>();
		List<int> thisStack = new List<int>();
		List<int> thatStack = new List<int>();
		List<int> pointerStack = new List<int>();
		List<int> tempStack = new List<int>();
		Stack<int> stack = new Stack<int>();
		Stack<int> stackList = new Stack<int>();

		private string setFileName;
		private List<string> results = new List<string>();
		private int baseStack = 255;
		private string outputPath;

		public CodeWriter(string output)
		{
			this.outputPath = output;
		}

		// public void SetFileName(string fileName) => this.setFileName = fileName;

		public void WriteAthematic(string operation)
		{
			Console.WriteLine("Write Athemitc is called" + operation);
			switch (operation)
			{
				case "add":
					ExecuteAddOperation();
					break;
				case "eq":
					ExecuteEqOperation();
					break;
				case "gt":
					ExecuteGtOperation();
					break;
				case "lt":
					ExecuteLtOperation();
					break;
				case "and":
					ExecuteAndOperation();
					break;
				case "or":
					ExecuteOrOperation();
					break;
				case "neg":
					ExecuteNegOperation();
					break;
				case "not":
					ExecuteNotOperation();
					break;
				case "sub":
					ExecuteSubOperation();
					break;
				// case "constant":
				// 	break;


				default:
					throw new Exception("Operation is called" + operation);

			}
		}

		private void ExecuteNegOperation()
		{

			var y = stack.Pop();
			stack.Push(-1 * y);
		}

		private void ExecuteSubOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			stack.Push(x - y);
		}

		private void ExecuteNotOperation()
		{
			var val1 = stack.Pop();
			stack.Push(~val1);
		}

		private void ExecuteAndOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			stack.Push(x & y);
		}

		private void ExecuteOrOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			stack.Push(x | y);
		}

		private void ExecuteLtOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = x < y;
			int ans = eq ? -1 : 0;
			stack.Push(ans);

		}

		private void ExecuteGtOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = x > y;
			int ans = eq ? -1 : 0;
			stack.Push(ans);
		}

		private void ExecuteEqOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = y == x;
			int ans = eq ? -1 : 0;
			stack.Push(ans);
		}


		private void ExecuteAddOperation()
		{
			System.Console.WriteLine("Execute add operation is called");
			var y = stack.Pop();
			var x = stack.Pop();

			stack.Push(y + x);

			// write hack assembly for that
		}

		public void WritePushPop(Chapter7.CommandType commandType, string segment, int index)
		{
			System.Console.WriteLine("write poop up is called");

			switch (segment)
			{
				case "constant":
					PushPopConstant(commandType, index);
					return;

				default:
					throw new Exception("segment" + segment);

			}
			// this.setFileName = fileName;
			// convert this to assembly
		}

		public void WriteResult()
		{
			string path = Path.GetDirectoryName(this.setFileName);
			string fileName = Path.GetFileNameWithoutExtension(this.setFileName);

			// set ram0 = 256
			var next = baseStack + stack.Count + 1;
			System.Console.WriteLine("Next statck last is " + next);
			results.Add("@" + next);
			results.Add("D = A");
			results.Add("@R0");
			results.Add("M = D");
			results.Add("@" + next);
			results.Add("D = A");
			results.Add("@R0");
			results.Add("M = D");



			for (int i = 0; i < stack.Count; i++)
			{
				WriteAssemblyForStack(baseStack + stack.Count, stack.Pop());
			}

			// foreach (var val in stack)
			// {
			// 	WriteAssemblyForStack(ival);
			// }



			System.Console.WriteLine("path" + outputPath);
			System.Console.WriteLine("results" + results.Count);
			File.WriteAllLines(outputPath, results);

			// File.WriteAllLines(outputPath, results);
		}

		private void WriteAssemblyForStack(int index, int val)
		{
			//
			System.Console.WriteLine("index" + index);
			System.Console.WriteLine("val" + val);
			// D = A
			// M = D

			// var next = index + 1;
			// results.Add("@" + next);
			// results.Add("D = A");
			// results.Add("@R0");
			// results.Add("M = D");

			// D = A
			// M = D
			if (val < 0)
			{
				results.Add("@" + (-1 * val));
				results.Add("D = -A");

				results.Add("@" + index);
				results.Add("M = D");
			}
			else
			{

				results.Add("@" + val);
				results.Add("D = A");

				results.Add("@" + index);
				results.Add("M = D");
			}

			// results.Add("@tmp");
			// results.Add("M = " + );

			// results.Add("@tmp");
			// results.Add("@tmp");

			// // D = M
			// results.Add("@R0");
			// results.Add("@R0");
			// results.Add("M = " + index);
		}

		private void PushPopConstant(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				stack.Push(index);
			}
			else
			{
				throw new Exception("Un expected pop stack option");
			}
		}

		public bool HasMoreCommands()
		{
			return false;
		}
	}
}