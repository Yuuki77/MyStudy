public class PrintReverseString
{
	public void Print(string a, int index) {
		if (index < 0) return;
		
		System.Console.WriteLine(a[index]);
		Print(a, index--);
	}
}