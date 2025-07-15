namespace leetcode.twoadd2
{
    public class Solution
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode newlist = new ListNode();
            ListNode templist = newlist;
            int addflag = 0;
            int now = 0;
            ListNode l1next = l1;
            ListNode l2next = l2;
            bool usingl1 = true;
            for (int i = 0; ; i++)
            {
                var sum = (l1next?.val ?? 0) + (l2next?.val ?? 0) + addflag;
                addflag = sum / 10;
                now = sum % 10;
                if (l1next != null)
                {
                    l1next.val = now;
                }
                if (l2next != null)
                {
                    l2next.val = now;
                }
                if (l1next?.next is null && l2next?.next != null)
                {
                    usingl1 = false;
                }
                if (l1next?.next == null && l2next?.next == null)
                {
                    if (addflag > 0)
                    {
                        if (usingl1)
                        {
                            l1next.next = new ListNode();
                            l1next.next.val = addflag;
                        }
                        else
                        {
                            l2next.next = new ListNode();
                            l2next.next.val = addflag;
                        }
                        // templist.next = new ListNode();
                        // templist = templist.next;
                        // templist.val = addflag;
                    }
                    break;
                }
                l1next = l1next?.next;
                l2next = l2next?.next;
                // templist.next = new ListNode();
                // templist = templist.next;
            }

            if (usingl1)
                return l1;
            else
                return l2;
            return newlist;
        }
    }
}