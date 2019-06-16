public class AckermanFunction {
	
	public int Ack(int m, int n) {
		// 2^65,533
		//uncountable ではないという話
		// super exponetiory for loop ではできないという話
		var ans = 0;

		if (m == 0) ans = n + 1;
		else if (n == 0) ans = Ack(n -1, 1);
		else ans = Ack(m -1, Ack(m , n-1));

		return ans;
	} 
}