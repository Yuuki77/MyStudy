namespace Chapter7
{
	public class Run
	{
		public Run(string fileName)
		{
			var parser = new Parser(fileName);
			var output_path = "";
			var codeWriter = new CodeWriter(output_path);

			while (parser.HasMoreCommands())
			{
				var commandType = parser.commandType;
				var isPush = commandType == Chapter7.CommandType.C_PUSH;
				var isPop = commandType == Chapter7.CommandType.C_POP;

				if (isPush || isPop)
				{
					string segment = "";
					int index = 0;
					codeWriter.WritePushPop(commandType, segment, index);
				}
				else
				{
					codeWriter.WriteAthematic(commandType);
				}
			}
		}
	}
}