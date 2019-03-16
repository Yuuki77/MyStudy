using System;

public class Matrix
{
	private int[] grid;

	private int row;	// 行

	private int column; // 列

	public int Column
	{
		get
		{
			return column;
		}
	}
	public int Row
	{
		get
		{
			return row;
		}
	}

	public Matrix(int row, int column)
	{
		this.row = row;
		this.column = column;
		this.grid = new int[row * column];
	}

	public Matrix(int row, int column, int[] grid)
	{
		this.row = row;
		this.column = column;
		this.grid = grid;
	}

	// Row 行
	// column　列
	public int this[int row, int column]
	{
		get
		{
			return this.grid[row * Column + column];
		}

		set
		{
			this.grid[row * Column + column] = value;
		}
	}
	
	public static Matrix operator +(Matrix b, Matrix c)
	{
		// 行列の足し算のできる
		var newMatrix = new Matrix(b.column, b.row);

		for (var i = 0; i < b.column; i++)
		{
			for (var j = 0; j < b.row; j++)
			{
				newMatrix[i, j] = b[i, j] + c[i, j];
			}
		}
		return newMatrix;
	}

	public static Matrix operator *(Matrix b, Matrix c)
	{
		var newMatrix = new Matrix(b.row, c.column);

		for (var i = 0; i < b.row; i++)
		{
			for (var j = 0; j < c.column; j++)
			{
				// get sum of this value
				for (var k = 0; k < b.column; k++)
				{
					newMatrix[i, j] += b[i, k] * c[k, j];
				}
			}
		}
		return newMatrix;
	}

	public void Print()
	{
		for (int i = 0; i < row; i++)
		{
			for (int j = 0; j < column; j++)
			{
				Console.Write(this[i, j] + "\t");
			}
			Console.WriteLine();
		}
	}
}