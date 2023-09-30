namespace LeetCode.Solutions.AddTwoNumbers;

public class NoRecursion
{
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // Result list
        // Start with default node which will be skipped in order not to pass nulls
        ListNode res = new();
        // Keeps track of decimal overflow
        var add = 0;
        
        while (l1 != null || l2 != null)
        {
            AddNodes(l1, l2, res, ref add);
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (add > 0)
            CreateLastNode(res).val = add;
        
        return res.next;
    }

    private void AddNodes(ListNode first, ListNode second, ListNode res, ref int add)
    {
        var result = first?.val ?? 0 + second?.val ?? 0 + add;
        
        var lastResNode = CreateLastNode(res);
        lastResNode.val = result % 10;
        add = result / 10;
        
    }

    private ListNode CreateLastNode(ListNode node)
    {
        while (true)
        {
            if (node == null)
            {
                node = new ListNode();
                return node;
            }

            if (node.next != null)
            {
                node = node.next;
                continue;
            }

            var newNode = new ListNode();
            node.next = newNode;
            return newNode;

            break;
        }
    }
}