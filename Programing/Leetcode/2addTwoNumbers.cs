public class AddTwoNumber
{
	// Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)

	public ListNode addTwoNumbers(ListNode firstHead, ListNode secondHead)
	{
		ListNode dummyHead = new ListNode(0);
		ListNode p = firstHead; // (2 -> 4 -> 3) 
		ListNode q = secondHead; // (5 -> 6 -> 4)
		ListNode curr = dummyHead;
		int carry = 0;

		while (p != null || q != null)
		{
			int x = (p != null) ? p.val : 0;
			int y = (q != null) ? q.val : 0;
			int sum = carry + x + y;
			carry = sum / 10;
			curr.next = new ListNode(sum % 10);
			curr = curr.next;
			if (p != null) p = p.next;
			if (q != null) q = q.next;
		}
		if (carry > 0)
		{
			curr.next = new ListNode(carry);
		}
		return dummyHead.next;
	}
}
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}