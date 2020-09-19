using System.Collections.Generic;

namespace Chapter7
{
	public class CodeWriter
	{
		private string setFileName;
		private Stack<int> contant;

		public CodeWriter(string fileName)
		{

		}

		public void SetFileName(string fileName) => this.setFileName = fileName;

		public void WriteAthematic(Chapter7.CommandType commandType)
		{
			// this.setFileName = fileName;
			// convert this to assembly
		}

		public void WritePushPop(Chapter7.CommandType commandType, string segment, int index)
		{
			// this.setFileName = fileName;
			// convert this to assembly
		}

		public bool HasMoreCommands()
		{
			return false;
		}

	}
}