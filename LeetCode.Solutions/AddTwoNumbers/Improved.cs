namespace LeetCode.Solutions.AddTwoNumbers;

public class Improved
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
        // Get digits to add
        var firstDigit = first?.val ?? 0;
        var secondDigit = second?.val ?? 0;

        var result = firstDigit + secondDigit + add;
        
        var lastResNode = CreateLastNode(res);
        lastResNode.val = result % 10;
        add = result / 10;
        
    }

    private ListNode CreateLastNode(ListNode node)
    {
        if (node == null)
        {
            node = new ListNode();
            return node;
        }

        if (node.next != null)
            return CreateLastNode(node.next);
        
        var newNode = new ListNode();
        node.next = newNode;
        return newNode;

    }
}