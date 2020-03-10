using System;

public class Quadric
{
	public void Solve(double b, double c)
	{
		var square = Math.Sqrt((b * b) - 4 * c);
		var ans1 = (-b + square) / 2.0f;
		var ans2 = (-b - square) / 2.0f;
		System.Console.WriteLine(ans1);
		System.Console.WriteLine(ans2);
	}
}