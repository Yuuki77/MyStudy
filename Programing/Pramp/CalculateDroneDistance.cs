using System;

public class CalculateDroneDistance
{
	public  int Solve(int[,] route) 
    {
      var currentAmount = 0; // 0
      var droneEnergy = 0;// 5
      // your code goes here
      Console.WriteLine(route.Length);
      for(var i = 0; i < route.GetLength(0) -1; i++) {
        var current = route[i, 2]; // 15
        var next = route[i + 1 , 2]; // 8
        
        if (current > next) {
          currentAmount += current - next;
        } else {
           if (next - current > currentAmount) {
             droneEnergy += next - current - currentAmount;
             currentAmount = 0;
           } else {
             currentAmount -= next - current;
           }
        }
      }
      
      return droneEnergy;
    }
}