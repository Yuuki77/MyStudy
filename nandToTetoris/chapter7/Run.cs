using System.IO;

namespace Chapter7
{
	public class Run
	{
		public Run(string fullpath)
		{
			var parser = new Parser(fullpath);
			string path = Path.GetDirectoryName(fullpath);
			string fileName = Path.GetFileNameWithoutExtension(fullpath);

			var output_path = path + "/" + fileName + ".asm";
			var codeWriter = new CodeWriter(output_path, fileName);

			while (parser.HasMoreCommands())
			{
				parser.Advance();

				var commandType = parser.commandType;
				bool isPushOrPop = IsPushOrPop(commandType);

				// System.Console.WriteLine("Command type" + commandType);
				if (isPushOrPop)
				{
					// System.Console.WriteLine("*** Pop up is called");
					string segment = parser.arg1;
					int index = parser.arg2;
					codeWriter.WritePushPop(parser.commandType, segment, index);
				}
				else if (commandType == Chapter7.CommandType.C_LABEL)
				{
					System.Console.WriteLine("***** Label" + parser.arg1);
					codeWriter.WriteLabel(parser.arg1);
					continue;
				}
				else if (commandType == Chapter7.CommandType.C_IF)
				{
					System.Console.WriteLine("***** if" + parser.arg1);
					codeWriter.WriteIf(parser.arg1);
					continue;
				}
				else
				{
					// System.Console.WriteLine(commandType);
					// System.Console.WriteLine("*** Write Athematic");
					codeWriter.WriteAthematic(parser.firstCommand, parser.arg1);
				}

				// codeWriter.Write();
			}

			codeWriter.WriteResult();

			// codeWriter.WriteResult();
		}

		private bool IsPushOrPop(Chapter7.CommandType commandType)
		{
			var isPush = commandType == Chapter7.CommandType.C_PUSH;
			var isPop = commandType == Chapter7.CommandType.C_POP;

			return isPush || isPop;
		}
	}
}