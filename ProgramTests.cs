
// using System;
// using System.IO;
// using lineAralgebra;
// using Xunit;

// public class ProgramTests
// {
// 	[Fact]
// 	public void MainTest()
// 	{

// 		// TestInOut("Input1.txt", "Output1.txt");
// 	}

// 	// [Fact]
// 	// public void MainTest2()
// 	// {
// 	//     TestInOut("Input2.txt", "Output2.txt");
// 	// }



// 	public void TestInOut(string inputFileName, string outputFileName)
// 	{

// 		// inputFileName = "." + inputFileName;

// 		//             inputFileName = "../../../" + inputFileName;

// 		var output = new StringWriter();
// 		Console.SetOut(output);

// 		var input = new StreamReader(new FileStream(inputFileName, FileMode.Open));        
//         Console.SetIn(input);

//         // Console.ReadLine();
//         // var a = Console.ReadLine();
//         // Console.WriteLine(a);

// 		// Program.Main(new string[0]);
// 		Assert.Equal(File.ReadAllText(outputFileName), output.ToString());


// 		// var output = new StringWriter();
// 		// Console.SetOut(output);

// 		// var input = new StringReader("Somebody");
// 		// Console.SetIn(input);

// 		// Program.Main(new string[] { });
// 	}
// }