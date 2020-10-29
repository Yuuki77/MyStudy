using System;
using System.Collections.Generic;
using System.IO;

namespace Chapter7
{
	public class CodeWriter
	{
		List<int> argumentSegment = new List<int>(new int[100]);
		List<int> localSegment = new List<int>(new int[100]);
		List<int> staticSegment = new List<int>(new int[100]);
		List<int> thisSegment = new List<int>(new int[100]);
		List<int> thatSegment = new List<int>(new int[100]);
		List<int> pointerSegment = new List<int>(new int[100]);
		List<int> tempSegment = new List<int>(new int[100]);
		// List<int> tempStatick = new List<int>(new int[100]);

		Stack<int> stack = new Stack<int>();

		private string setFileName;
		private List<string> results = new List<string>();
		private int stackPointerAddress = 256;
		private string outputPath;

		private int lclBasicAddress = 300;
		private int agrBasicAddress = 400;

		private int thisBasicAddress = 3000;
		private int thatBasicAddress = 3010;
		private int tempAddress = 5;
		private int pointerAddress = 3;
		private int staticAddress = 16;

		private string fileName;

		private Dictionary<string, string> operations = new Dictionary<string, string>()
		{
			{"sub","D = D - M"},
			{"add","D = D + M"},
		};

		public CodeWriter(string output, string fileName)
		{
			this.outputPath = output;
			this.fileName = fileName;

			WriteResultLocalSp();
			WriteResultArgumentSp();
			WriteResultThisSp();
			WriteResultThatSp();
		}

		public void WriteAthematic(string command, string operation)
		{
			results.Add("//" + Chapter7.Parser.debugcurrentCommand);

			switch (command)
			{
				case "add":
				case "sub":
					ExecuteAddSubOperation(command);
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
				case "":
					ExecuteSubOperation();
					break;
				default:
					throw new Exception("Unexpected " + operation);
			}
		}

		private void ExecuteAddSubOperation(string add_or_sub_key)
		{
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add(operations[add_or_sub_key]);

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");
		}

		public void WriteIf(string operation)
		{
			results.Add("//" + Chapter7.Parser.debugcurrentCommand);

			var y = stack.Pop();
			System.Console.WriteLine("Pop  y is " + y);
			if (y != 0)
			{
				// execute the logic
				results.Add("@" + y);
				results.Add("D = A");
				results.Add("@" + operation);
				results.Add("D;JGT");
			}
		}

		// bug
		public void WriteLabel(string operation)
		{
			results.Add("//" + Chapter7.Parser.debugcurrentCommand);
			results.Add("(" + operation + ")");
		}

		private void ExecuteNegOperation()
		{
			// var y = stack.Pop();
			// PushStack(-1 * y);
			// results.Add("@" + --stackPointerAddress);
			// results.Add("D = M");
			// results.Add("@" + --stackPointerAddress);
			// results.Add("D = -D");

			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = -D");

			WriteResultStackSp();
		}

		private void ExecuteSubOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();
			// PushStack(x - y);

			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D - M");

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");
			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = D");
			WriteResultStackSp();
		}

		private void ExecuteNotOperation()
		{
			// var val1 = stack.Pop();
			// PushStack(~val1);
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + stackPointerAddress++);
			results.Add("D = -D");

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");
		}

		private void ExecuteAndOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();

			// PushStack(x & y);
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D & M");

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");
		}

		private void ExecuteOrOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();

			// PushStack(x | y);
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D | M");

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");

			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = D");
			WriteResultStackSp();
		}

		private void ExecuteLtOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();

			// bool eq = x < y;
			// int ans = eq ? -1 : 0;
			// PushStack(ans);

			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D - M");

			// ifを書きたい
			results.Add("@" + results.Count + 4);
			results.Add("D;JLT");

			// 0のとき
			results.Add("@" + stackPointerAddress);
			results.Add("M = 0");

			results.Add("@" + stackPointerAddress);
			results.Add("M = -1");

			stackPointerAddress++;
			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = D");
			WriteResultStackSp();

			// PushStack(ans);
		}

		private void ExecuteGtOperation()
		{
			// M
			// var y = stack.Pop();
			// D
			// var x = stack.Pop();

			// 4 > 5
			// bool eq = x > y;
			// int ans = eq ? -1 : 0;
			// PushStack(ans);
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D - M");

			// ifを書きたい
			results.Add("@" + results.Count + 4);
			results.Add("D;JGT");

			// 0のとき
			results.Add("@" + stackPointerAddress);
			results.Add("M = 0");

			results.Add("@" + stackPointerAddress);
			results.Add("M = -1");

			stackPointerAddress++;
			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = D");
			WriteResultStackSp();
		}

		private void PushStack(int ans)
		{
			WriteAssemblyForStack(stackPointerAddress, ans);
			stack.Push(ans);
		}

		private void ExecuteEqOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();

			// bool eq = y == x;
			// int ans = eq ? -1 : 0;

			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D - M");

			// // ifを書きたい
			// results.Add("@" + results.Count + 4);
			// results.Add("D;JEQ");

			// // 0のとき
			// results.Add("@" + stackPointerAddress);
			// results.Add("M = -1");

			// results.Add("@" + stackPointerAddress);
			// results.Add("M = 0");

			// stackPointerAddress++;
			// results.Add("@" + stackPointerAddress++);
			// results.Add("M = D");
			WriteResultStackSp();

			// PushStack(ans);
		}


		private void ExecuteAddOperation()
		{
			// var y = stack.Pop();
			// var x = stack.Pop();

			// int val = y + x;
			results.Add("@" + --stackPointerAddress);
			results.Add("D = M");
			results.Add("@" + --stackPointerAddress);
			results.Add("D = D + M");

			results.Add("@" + stackPointerAddress++);
			results.Add("M = D");

			WriteResultStackSp();
		}

		public void WritePushPop(Chapter7.CommandType commandType, string segment, int index)
		{
			results.Add("//" + Chapter7.Parser.debugcurrentCommand);

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
				default:
					throw new Exception("unexpected " + segment);
			}
		}

		private void PushPopStatic(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(staticSegment[index]);
			}
			else
			{
				var totalIndex = staticAddress + index;
				staticSegment[index] = stack.Pop();
				var val = staticSegment[index];

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
				PushStack(tempSegment[index]);
			}
			else
			{
				var totalIndex = tempAddress + index;
				tempSegment[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, tempSegment[index]);
			}
		}

		private void PushPopPointer(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(pointerSegment[index]);
			}
			else
			{
				var totalIndex = pointerAddress + index;
				pointerSegment[index] = stack.Pop();
				if (index == 0)
				{
					thisBasicAddress = pointerSegment[index];
				}
				else
				{
					thatBasicAddress = pointerSegment[index];
				}

				WriteAssemblyForStack(totalIndex, pointerSegment[index]);
			}
		}

		private void PushPopThat(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(thatSegment[index]);

			}
			else
			{
				var totalIndex = thatBasicAddress + index;
				thatSegment[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, thatSegment[index]);
			}
		}

		private void PushPopThis(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				PushStack(thisSegment[index]);

			}
			else
			{
				var totalIndex = thisBasicAddress + index;
				thisSegment[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, thisSegment[index]);
			}
		}

		private void PushPopArgument(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				System.Console.WriteLine("push argument" + argumentSegment[index]);
				PushStack(argumentSegment[index]);

			}
			else
			{
				var totalIndex = agrBasicAddress + index;
				argumentSegment[index] = stack.Pop();
				WriteAssemblyForStack(totalIndex, argumentSegment[index]);
			}
		}


		private void PushPopLocal(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				// System.Console.WriteLine("Push local" + localSegment[index]);
				PushStack(localSegment[index]);
			}
			else
			{
				// System.Console.WriteLine("Pop local");
				var totalIndex = lclBasicAddress + index;
				localSegment[index] = stack.Pop();
				// System.Console.WriteLine(localSegment[index]);
				WriteAssemblyForStack(totalIndex, localSegment[index]);
			}
		}

		// public void Write()
		// {
		// 	WriteResultStackSp();
		// }

		public void WriteResult()
		{
			string path = Path.GetDirectoryName(this.setFileName);
			string fileName = Path.GetFileNameWithoutExtension(this.setFileName);
			File.WriteAllLines(outputPath, results);
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

			// System.Console.WriteLine("index" + index);
			// System.Console.WriteLine("val" + val);

			// D = A
			// M = D
			// if (val < 0)
			// {
			// 	results.Add("@" + (-1 * val));
			// 	results.Add("D = -A");
			// 	results.Add("@" + index);
			// 	results.Add("M = D");
			// }
			// else
			// {
			// 	results.Add("@" + val);
			// 	results.Add("D = A");
			// 	results.Add("@" + index);
			// 	results.Add("M = D");
			// }
		}

		private void PushPopConstant(CommandType commandType, int index)
		{
			if (commandType == CommandType.C_PUSH)
			{
				results.Add("@" + index);
				results.Add("D = A");
				results.Add("@" + this.stackPointerAddress++);
				results.Add("M = D");
				// PushStack(index);
			}
			else
			{
				throw new Exception("Un expected pop stack option");
			}
		}
	}
}