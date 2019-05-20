using System.Collections.Generic;

public class LinkedListCycle
{
    // https://leetcode.com/problems/linked-list-cycle/solution/
    
	/**
	 * Definition for singly-linked list.
	 * public class ListNode {
	 *     public int val;
	 *     public ListNode next;
	 *     public ListNode(int x) {
	 *         val = x;
	 *         next = null;
	 *     }
	 * }
	 */
	public bool HasCycle1(ListNode head)
	{
		var list = new List<ListNode>();
		while (head != null)
		{
			if (list.Contains(head))
			{
				return true;
			}
			list.Add(head);
			head = head.next;

		}

		return false;
	}

	public bool hasCycle2(ListNode head)
	{
		if (head == null || head.next == null)
		{
			return false;
		}
		ListNode slow = head;
		ListNode fast = head.next;
		while (slow != fast)
		{
			if (fast == null || fast.next == null)
			{
				return false;
			}
			slow = slow.next;
			fast = fast.next.next;
		}
		return true;
	}
}