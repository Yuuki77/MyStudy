using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter7
{
	public class CodeWriter
	{
		List<int> argument = new List<int>(new int[100]);
		List<int> local = new List<int>(new int[100]);
		List<int> staticStack = new List<int>(new int[100]);
		List<int> constantStack = new List<int>(new int[100]);
		List<int> thisStack = new List<int>(new int[100]);
		List<int> thatStack = new List<int>(new int[100]);
		List<int> pointerStack = new List<int>(new int[100]);
		List<int> tempStack = new List<int>(new int[100]);
		// List<int> tempStatick = new List<int>(new int[100]);

		Stack<int> stack = new Stack<int>();

		private string setFileName;
		private List<string> results = new List<string>();
		private int baseStack = 256;
		private string outputPath;

		private int lclBasicAddress = 300;
		private int agrBasicAddress = 400;

		private int thisBasicAddress = 3000;
		private int thatBasicAddress = 3010;
		private int tempAddress = 5;
		private int pointerAddress = 3;
		private int staticAddress = 16;

		private string fileName;

		private int stackPointerAddress
		{
			get
			{
				return this.baseStack + stack.Count;
			}
		}

		public CodeWriter(string output, string fileName)
		{
			this.outputPath = output;
			this.fileName = fileName;

			WriteResultLocalSp();
			WriteResultArgumentSp();
			WriteResultThisSp();
			WriteResultThatSp();
		}

		public void WriteAthematic(string currentCommand, string operation)
		{
			results.Add("//" + currentCommand);

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
					throw new Exception("Unexpected " + operation);

			}
		}

		private void ExecuteNegOperation()
		{
			var y = stack.Pop();
			PushStack(-1 * y);
		}

		private void ExecuteSubOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();
			// stack.Push(x - y);
			PushStack(x - y);
		}

		private void ExecuteNotOperation()
		{
			var val1 = stack.Pop();
			PushStack(~val1);
		}

		private void ExecuteAndOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			PushStack(x & y);

		}

		private void ExecuteOrOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			PushStack(x | y);
		}

		private void ExecuteLtOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = x < y;
			int ans = eq ? -1 : 0;
			PushStack(ans);
		}

		private void ExecuteGtOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = x > y;
			int ans = eq ? -1 : 0;
			PushStack(ans);
		}

		public void PushStack(int ans)
		{
			WriteAssemblyForStack(stackPointerAddress, ans);
			stack.Push(ans);
		}

		private void ExecuteEqOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			bool eq = y == x;
			int ans = eq ? -1 : 0;

			PushStack(ans);
		}


		private void ExecuteAddOperation()
		{
			var y = stack.Pop();
			var x = stack.Pop();

			int val = y + x;
			PushStack(val);
		}

		public void WritePushPop(string currentCommand, Chapter7.CommandType commandType, string segment, int index)
		{
			results.Add("//" + currentCommand);

			System.Console.WriteLine(segment);
			switch (segment)
			{
				case "constant":
					PushPopConstant(commandType, index);
					return;
				case "local":
					PushPopLocal(commandType, index);
					return;
				case "argument":
					PushPopArgument(commandType, index);
					return;
				case "this":
					PushPopThis(commandType, index);
					return;
				case "that":
					PushPopThat(commandType, index);
					return;
				case "temp":
					PushPopTemp(commandType, index);
					return;
				case "pointer":
					PushPopPointer(commandType, index);
					return;
				case "static":
					PushPopStatic(commandType, index);
					return;
				// convert this to assembly
				// case "local":
				// 	PushPopLocal(commandType, index);
				// 	return;
				default:
					throw new Exception("unexpected " + segment);
			}
		}

		private void PushPopStatic(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(staticStack[index]);
			}
			else
			{
				var totalIndex = staticAddress + index;
				staticStack[index] = stack.Pop();
				var val = staticStack[index];

				if (val < 0)
				{
					results.Add("@" + fileName + "." + (-1 * val));
					results.Add("D = -M");
				}
				else
				{
					results.Add("@" + fileName + "." + (val));
					results.Add("D = M");
				}
			}
		}

		private void PushPopTemp(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(tempStack[index]);
			}
			else
			{
				var totalIndex = tempAddress + index;
				tempStack[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, tempStack[index]);
			}
		}

		private void PushPopPointer(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(pointerStack[index]);
			}
			else
			{
				var totalIndex = pointerAddress + index;
				pointerStack[index] = stack.Pop();
				if (index == 0)
				{
					thisBasicAddress = pointerStack[index];
				}
				else
				{
					thatBasicAddress = pointerStack[index];
				}

				WriteAssemblyForStack(totalIndex, pointerStack[index]);
			}
		}

		private void PushPopThat(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(thatStack[index]);

			}
			else
			{
				var totalIndex = thatBasicAddress + index;
				thatStack[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, thatStack[index]);
			}
		}

		private void PushPopThis(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(thisStack[index]);

			}
			else
			{
				var totalIndex = thisBasicAddress + index;
				thisStack[index] = stack.Pop();
				// thisBasicAddress = thisStack[]
				WriteAssemblyForStack(totalIndex, thisStack[index]);
			}
		}

		private void PushPopArgument(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{

				// WriteAssemblyForStack(stackPointerAddress, argument[index]);
				// stack.Push(argument[index]);
				PushStack(argument[index]);

			}
			else
			{
				var totalIndex = agrBasicAddress + index;
				argument[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, argument[index]);
			}
		}

		private void PushPopLocal(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				// WriteAssemblyForStack(stackPointerAddress, local[index]);
				// stack.Push(local[index]);
				PushStack(local[index]);
			}
			else
			{
				var totalIndex = lclBasicAddress + index;
				var val = stack.Pop();
				local[index] = val;
				WriteAssemblyForStack(totalIndex, local[index]);
			}
		}

		public void Write(string currentCommand)
		{
			// results.Add("//" + currentCommand);
			// results.Add("D = A");
			// results.Add("@R0");
			// results.Add("M = D");

			WriteResultStackSp();
			// WriteResultLocalSp();
			// WriteResultArgumentSp();
			// WriteResultThisSp();
			// WriteResultThatSp();
			// WriteResultSp();


			// var stackCount = stack.Count;

			// for (int i = 0; i < stackCount; i++)
			// {
			// 	WriteAssemblyForStack(baseStack + stack.Count, stack.Pop());
			// }
		}

		public void WriteResult(string currentCommand)
		{
			string path = Path.GetDirectoryName(this.setFileName);
			string fileName = Path.GetFileNameWithoutExtension(this.setFileName);

			WriteArgument();
			WriteLocal();
			WriteThis();
			WriteThat();
			WriteTemp();

			WritePointer();
			// for (int i = 0; i < stackCount; i++)
			// {
			// 	WriteAssemblyForStack(baseStack + stack.Count, stack.Pop());
			// }


			File.WriteAllLines(outputPath, results);
		}

		private void WriteArgument()
		{
			for (int i = 0; i < this.argument.Count; i++)
			{
				WriteAssemblyForStack(agrBasicAddress + i, argument[i]);
			}
		}

		private void WriteThat()
		{
			for (int i = 0; i < this.thatStack.Count; i++)
			{
				WriteAssemblyForStack(thatBasicAddress + i, thatStack[i]);
			}
		}

		private void WriteTemp()
		{
			for (int i = 0; i < this.tempStack.Count; i++)
			{
				WriteAssemblyForStack(tempAddress + i, this.tempStack[i]);
			}
		}

		private void WritePointer()
		{

			for (int i = 0; i < this.pointerStack.Count; i++)
			{
				WriteAssemblyForStack(pointerAddress + i, this.pointerStack[i]);
			}
			// for (int i = 0; i < this.pointerStack.Count; i++)
			// {
			// 	WriteAssemblyForStack(pointer + i, thisStack[i]);
			// }
		}


		private void WriteLocal()
		{
			for (int i = 0; i < this.local.Count; i++)
			{
				WriteAssemblyForStack(lclBasicAddress + i, this.local[i]);
			}
		}

		private void WriteThis()
		{
			for (int i = 0; i < this.thisStack.Count; i++)
			{
				WriteAssemblyForStack(thisBasicAddress + i, this.thisStack[i]);
			}
		}

		private void WriteResultThisSp()
		{
			results.Add("@" + thisBasicAddress);
			results.Add("D = A");
			results.Add("@R3");
			results.Add("M = D");
		}

		private void WriteResultThatSp()
		{
			results.Add("@" + thatBasicAddress);
			results.Add("D = A");
			results.Add("@R4");
			results.Add("M = D");
		}

		private void WriteResultLocalSp()
		{
			results.Add("@" + lclBasicAddress);
			results.Add("D = A");
			results.Add("@R1");
			results.Add("M = D");
		}

		private void WriteResultArgumentSp()
		{
			results.Add("@" + agrBasicAddress);
			results.Add("D = A");
			results.Add("@R2");
			results.Add("M = D");
		}

		private void WriteResultStackSp()
		{
			results.Add("@" + stackPointerAddress);
			results.Add("D = A");
			results.Add("@R0");
			results.Add("M = D");
		}

		private void WriteAssemblyForStack(int index, int val)
		{
			//
			// System.Console.WriteLine("index" + index);
			// System.Console.WriteLine("val" + val);

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
				// convert this to assembly
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
				// WriteAssemblyForStack(stackPointerAddress, index);
				// stack.Push(index);
				PushStack(index);
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