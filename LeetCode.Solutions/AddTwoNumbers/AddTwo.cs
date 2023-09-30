namespace LeetCode.Solutions.AddTwoNumbers;

/// <summary>
/// https://leetcode.com/problems/add-two-numbers/
/// </summary>
public class AddTwo
{
    
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var add = 0;
        var res = new List<int>();
        
        while (l1 != null || l2 != null)
        {
            var (r, ad) = AddDigits(l1, l2, add);
            
            res.Add(r);
            add = ad;

            l1 = l1?.next;
            l2 = l2?.next;
        }
        
        if(add > 0)
            res.Add(add);
        
        return BuildNode(res.ToArray());
    }

    public (int, int) AddDigits(ListNode first, ListNode second, int add)
    {
        var firstDigit = first?.val ?? 0;
        var secondDigit = second?.val ?? 0;

        var res = firstDigit + secondDigit + add;
        var mod = res % 10;
        return res < 10 ? new ValueTuple<int, int>(res, 0) : new ValueTuple<int, int>(mod, res/10);
    }

    public static ListNode BuildNode(int[] arr)
    {
        var listArr = arr
            .Select(x => new ListNode(x))
            .ToArray();

        for (var i = 0; i < arr.Length - 1; i++)
        {
            listArr[i].next = listArr[i + 1];
        }

        return listArr.First();
    }
}