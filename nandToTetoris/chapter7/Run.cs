using System.IO;

namespace Chapter7
{
	public class Run
	{
		public Run(string fullpath)
		{
			var parser = new Parser(fullpath);
			string path = Path.GetDirectoryName(fullpath);
			// string path = Path.GetDirectoryName(fi);
			string fileName = Path.GetFileNameWithoutExtension(fullpath);

			var output_path = path + "/" + fileName + ".asm";
			var codeWriter = new CodeWriter(output_path);

			while (parser.HasMoreCommands())
			{
				parser.Advance();

				var commandType = parser.commandType;
				var isPush = commandType == Chapter7.CommandType.C_PUSH;
				var isPop = commandType == Chapter7.CommandType.C_POP;

				System.Console.WriteLine("Command type" + commandType);
				if (isPush || isPop)
				{
					System.Console.WriteLine("*** Pop up is called");
					string segment = parser.arg1;
					int index = parser.arg2;
					codeWriter.WritePushPop(commandType, segment, index);
				}
				else
				{
					System.Console.WriteLine(commandType);
					System.Console.WriteLine("*** Write Athematic");
					codeWriter.WriteAthematic(parser.arg1);
				}
			}

			codeWriter.WriteResult();
		}
	}
}