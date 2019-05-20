using System;
using Xunit;

public class TestMatrix
{
	[Fact]
	public void AddMatrix1()
	{
		var test1 = new int[]
		{
		  1,2,
		  3, 4
		};
		var matrix1 = new Matrix(2, 2, test1);
		var matrix2 = new Matrix(2, 2, test1);

		var result = matrix1 + matrix2;

		var expectedResult = new int[]
		{
		  2,4,
		  6, 8
		};

		var expectedMatrix = new Matrix(2, 2, expectedResult);

		for (var i = 0; i < result.Row; i++)
		{
			for (var j = 0; j < result.Column; j++)
			{
				Assert.Equal(result[i, j], expectedMatrix[i, j]);
			}
		}
	}

	[Fact]
	public void AddMatrix2()
	{
		var test1 = new int[]
		{
		  1,2,
		  3, 4
		};

		var test2 = new int[]
		{ 100,200,
		  300, 400
		};
		var matrix1 = new Matrix(2, 2, test1);
		var matrix2 = new Matrix(2, 2, test2);
		var result = matrix1 + matrix2;

		var expectedResult = new int[]
		{
		  101,202,
		  303, 404
		};

		var expectedMatrix = new Matrix(2, 2, expectedResult);

		for (var i = 0; i < result.Row; i++)
		{
			for (var j = 0; j < result.Column; j++)
			{
				Assert.Equal(result[i, j], expectedMatrix[i, j]);
			}
		}
	}

	[Fact]
	public void MultiplyMatrix1()
	{
		var test1 = new int[]
		{
		  1,2,
		  3, 4
		};

		var test2 = new int[]
		{
		  5,6,
		  7, 8
		};
		var matrix1 = new Matrix(2, 2, test1);
		var matrix2 = new Matrix(2, 2, test2);
		var result = matrix1 * matrix2;

		var expectedResult = new int[]
		{
		  19,22,
		  43, 50
		};

		var expectedMatrix = new Matrix(2, 2, expectedResult);

		// result.Print();
		for (var i = 0; i < result.Row; i++)
		{
			for (var j = 0; j < result.Column; j++)
			{
				Assert.Equal(result[i, j], expectedMatrix[i, j]);
			}
		}
	}

	[Fact]
	public void MultiplyMatrix2()
	{
		var test1 = new int[]
		{
		  2, 6,
		  3, 10
		};

		var test2 = new int[]
		{
		  3, 4,
		  5, 8
		};

		var test3 = new int[]
		{
		  2,
		  3,
		};
		var matrix1 = new Matrix(2, 2, test1);
		var matrix2 = new Matrix(2, 2, test2);
		var matrix3 = new Matrix(2, 1, test3);
		
		var result = matrix1 * matrix2 * matrix3;

		var expectedResult = new int[]
		{
		  240,
		  394
		};

		var expectedMatrix = new Matrix(2, 1, expectedResult);
		for (var i = 0; i < result.Row; i++)
		{
			for (var j = 0; j < result.Column; j++)
			{
				Assert.Equal(result[i, j], expectedMatrix[i, j]);
			}
		}
	}
}