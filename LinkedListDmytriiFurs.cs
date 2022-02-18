using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode_Solutions
{
        class LinkedListDmytriiFurs // Dmytrii Furs, Conestoga College, LinkedList solutions (leetcode.com)
        {
            static void Main(string[] args)
            {
                LinkedListDmytriiFurs instance = new LinkedListDmytriiFurs();

            ListNode ln1 = new ListNode(1, null);
            ListNode ln2 = new ListNode(3, ln1);
            ListNode ln3 = new ListNode(-3, ln2);
            ListNode ln4 = new ListNode(2, ln3);
            ListNode ln5 = new ListNode(1, ln4);
            instance.RemoveZeroSumSublists(ln5);

        }
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

            // 1290. Convert Binary Number in a Linked List to Integer (Easy)
            public int GetDecimalValue(ListNode head)
            {
                string res = "";
                while (head != null)
                {
                    res += head.val.ToString();
                    head = head.next;
                }
                if (res == "")
                    return 0;
                else
                {
                    return Convert.ToInt32(res, 2);
                }
            }

            // 2130. Maximum Twin Sum of a Linked List (Medium)
            public int PairSum(ListNode head)
            {
                ListNode slow = head, fast = head, prev, temp;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                prev = slow;
                slow = slow.next;
                prev.next = null;
                while (slow != null)
                {
                    temp = slow.next;
                    slow.next = prev;
                    prev = slow;
                    slow = temp;
                }
                int max = int.MinValue;
                slow = prev;
                while (slow != null)
                {
                    if ((slow.val + head.val) > max)
                        max = slow.val + head.val;
                    slow = slow.next;
                    head = head.next;
                }
                return max;
            }

            // 1669. Merge In Between Linked Lists (Medium)
            public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
            {
                int index = 0, amount = b - a + 1;
                ListNode res = list1;
                while (list1 != null)
                {
                    if (index == (a - 1))
                    {
                        ListNode temp = list1;
                        index = 0;
                        while (index != amount)
                        {
                            index++;
                            temp = temp.next;
                        }
                        ListNode nextNode = temp.next;
                        while (list2 != null)
                        {
                            list1.next = list2;
                            list2 = list2.next;
                            list1 = list1.next;
                        }
                        list1.next = nextNode;
                        break;
                    }
                    else
                    {
                        ++index;
                        list1 = list1.next;
                    }
                }
                return res;
            }

            // 1472. Design Browser History (Medium)
            /* LinkedList in this task has string data type
            public class BrowserHistory
            {

                ListNode head;
                int count = 0;
                int current = 0;
                public BrowserHistory(string homepage)
                {
                    head = new ListNode(homepage, null);
                    count = 0;
                    current = 0;
                    count++;
                    current++;
                }

                public void Visit(string url)
                {
                    ListNode temp = head;
                    int index = 1;
                    while (temp.next != null && index < current)
                    {
                        index++;
                        temp = temp.next;
                    }
                    temp.next = new ListNode(url, null);
                    current++;
                    count = current;
                }

                public string Back(int steps)
                {

                    int index = 1;
                    ListNode temp = head;
                    while (index < current - steps && temp.next != null)
                    {
                        temp = temp.next;
                        index++;
                    }
                    current = index;
                    return temp.val;

                }

                public string Forward(int steps)
                {

                    int index = 1;
                    ListNode temp = head;
                    while (index < current + steps && temp.next != null)
                    {
                        temp = temp.next;
                        index++;
                    }
                    current = index;
                    return temp.val;

                }
            }
            */

            // Middle of the Linked List (Easy) This task was done before learning 2 pointers technique
            public ListNode MiddleNode(ListNode head)
            {
                if (head == null)
                {
                    return null;
                }
                if (head.next == null)
                    return head;

                ListNode start = head, result = head;
                int currentMid = 1, count = 1;
                while (start != null)
                {
                    if (count % 2 == 0 && currentMid < (count / 2) + 1)
                    {
                        currentMid++;
                        result = result.next;
                    }
                    else if (currentMid < (count / 2))
                    {
                        currentMid++;
                        result = result.next;
                    }
                    start = start.next;
                    count++;
                }

                return result;
            }

            // 237. Delete Node in a Linked List (Easy)
            public void DeleteNode(ListNode node)
            {
                if (node.next == null)
                    node = null;
                else
                {
                    node.val = node.next.val;
                    node.next = node.next.next;
                }
            }

            // 206. Reverse Linked List (Easy)
            public ListNode ReverseList(ListNode head)
            {
                if (head == null)
                    return null;

                ListNode prev = null, next = null;
                while (head != null)
                {
                    next = head.next;
                    head.next = prev;
                    prev = head;
                    head = next;
                }
                head = prev;
                return head;
            }

            // 1721. Swapping Nodes in a Linked List (Medium) (This task was solved before I dived into learning algos related to LinkedList)
            public ListNode SwapNodes(ListNode head, int k)
            {
                k--;
                ListNode firstPointer = head, secondPointer = head, thirdPointer = head;
                for (int i = 1; i <= k; i++)
                {
                    firstPointer = firstPointer.next;
                    thirdPointer = firstPointer;
                }
                if (firstPointer == null)
                    secondPointer = head.next;
                while (firstPointer.next != null)
                {
                    firstPointer = firstPointer.next;
                    secondPointer = secondPointer.next;
                }


                int tempVal = thirdPointer.val;

                thirdPointer.val = secondPointer.val;
                secondPointer.val = tempVal;

                return head;
            }

            // 705. Design HashSet (Easy) (Done with LinkedList)
            public class MyHashSet
            {

                ListNode head = null;

                public MyHashSet()
                {
                    head = new ListNode(-1);
                }

                public void Add(int key)
                {

                    ListNode n = new ListNode(key);

                    ListNode dummyNode = head;
                    while (dummyNode.next != null)
                    {
                        if (dummyNode.next.val == key)
                        {
                            return;
                        }
                        dummyNode = dummyNode.next;
                    }
                    dummyNode.next = n;

                }

                public void Remove(int key)
                {
                    if (head.next == null)
                        return;


                    ListNode dummyNode = head;
                    while (dummyNode.next != null)
                    {
                        if (dummyNode.next.val == key)
                        {
                            ListNode d = dummyNode.next;
                            dummyNode.next = dummyNode.next.next;
                            d = null;
                            break;
                        }
                        dummyNode = dummyNode.next;
                    }

                }

                public bool Contains(int key)
                {

                    ListNode dummyTail = head.next;
                    while (dummyTail != null)
                    {
                        if (dummyTail.val == key)
                        {
                            return true;
                        }
                        dummyTail = dummyTail.next;
                    }

                    return false;
                }
            }

            // 706. Design HashMap (Easy)
            /*
            public class MyHashMap
            {

                ListNode head = null;

                public MyHashMap()
                {
                    head = new ListNode(-1, -1);
                }

                public void Put(int key, int val)
                {

                     public class ListNode
                    {
                        public int val;
                        public int key;
                        public ListNode next;
                        public ListNode(int val = 0, int key = 0)
                        {
                            this.val = val;
                            this.key = key;
                            this.next = null;
                        }
                    }       

                    ListNode putNode = new ListNode(val, key);
                    ListNode dummyHead = head;
                    while (dummyHead.next != null)
                    {
                        if (dummyHead.next.key == key)
                        {
                            dummyHead.next.val = val;
                            return;
                        }
                        dummyHead = dummyHead.next;
                    }
                    dummyHead.next = putNode;
                }

                public int Get(int key)
                {
                    ListNode dummyHead = head;
                    while (dummyHead.next != null)
                    {
                        if (dummyHead.next.key == key)
                        {
                            return dummyHead.next.val;
                        }
                        dummyHead = dummyHead.next;
                    }
                    return -1;
                }

                public void Remove(int key)
                {
                    ListNode dummyHead = head;
                    while (dummyHead.next != null)
                    {
                        if (dummyHead.next.key == key)
                        {
                            dummyHead.next = dummyHead.next.next;
                            break;
                        }
                        dummyHead = dummyHead.next;
                    }
                }
            }*/

            // 1019. Next Greater Node In Linked List (Medium)
            public int[] NextLargerNodes(ListNode head)
            {
                List<int> res = new List<int>();
                ListNode temp = head;
                int length = 0;
                while (head != null)
                {
                    temp = head;
                    length = res.Count();
                    while (temp != null)
                    {
                        if (temp.val > head.val)
                        {
                            res.Add(temp.val);
                            break;
                        }

                        temp = temp.next;
                    }
                    if (length == res.Count())
                        res.Add(0);
                    head = head.next;
                }

                return res.ToArray();
            }

            // 21. Merge Two Sorted Lists (Easy)
            public ListNode MergeTwoLists(ListNode list1, ListNode list2)
            {
                ListNode dummyNode = new ListNode(-1, null);
                ListNode head = dummyNode;
                while (list1 != null && list2 != null)
                {
                    if (list1.val < list2.val)
                    {
                        dummyNode.next = list1;
                        list1 = list1.next;
                    }
                    else
                    {
                        dummyNode.next = list2;
                        list2 = list2.next;
                    }

                    dummyNode = dummyNode.next;
                }
                if (list1 != null)
                    dummyNode.next = list1;
                else
                    dummyNode.next = list2;
                return head.next;
            }

            // 328. Odd Even Linked List (Medium)
            public ListNode OddEvenList(ListNode head)
            {
                if (head == null)
                {
                    return null;
                }
                ListNode odd = head, even = head.next, evenHead = head.next;
                while (even != null && even.next != null)
                {
                    odd.next = even.next;
                    odd = odd.next;
                    even.next = odd.next;
                    even = even.next;
                }
                odd.next = evenHead;
                return head;
            }

            // 382. Linked List Random Node (Medium)
            /*
            public class Solution
            {
                private ListNode head;
                public Solution(ListNode head)
                {
                    this.head = head;
                }

                public int GetRandom()
                {
                    int scope = 1, chosenValue = 0;
                    Random rnd = new Random();
                    ListNode curr = this.head;
                    while (curr != null)
                    {
                        if (rnd.NextDouble() < 1.0 / scope)
                            chosenValue = curr.val;
                        curr = curr.next;
                        scope++;
                    }

                    return chosenValue;
                }
            }
            */

            // 1019. Next Greater Node In Linked List (Medium)
            public int[] NextLargerNodes2(ListNode head)
            {
                List<int> res = new List<int>();
                ListNode temp = head;
                int length = 0;
                while (head != null)
                {
                    temp = head;
                    length = res.Count();
                    while (temp != null)
                    {
                        if (temp.val > head.val)
                        {
                            res.Add(temp.val);
                            break;
                        }

                        temp = temp.next;
                    }
                    if (length == res.Count())
                        res.Add(0);
                    head = head.next;
                }

                return res.ToArray();
            }

            // 19. Remove Nth Node From End of List (Medium)
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                if (head == null)
                    return null;
                ListNode firstPointer = head, secondPointer = head;
                for (int i = 1; i <= n; i++)
                {
                    firstPointer = firstPointer.next;
                }
                if (firstPointer == null)
                    return head.next;
                while (firstPointer.next != null)
                {
                    firstPointer = firstPointer.next;
                    secondPointer = secondPointer.next;
                }
                secondPointer.next = secondPointer.next.next;
                return head;
            }

            // 143. Reorder List (Medium)
            public void ReorderList(ListNode head)
            {
                ListNode slow = head, fast = head;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                ListNode n = Reverse(slow.next);
                slow.next = null;
                ListNode m = head;
                while (m != null && n != null)
                {
                    ListNode tempM = m.next;
                    ListNode tempN = n.next;

                    m.next = n;
                    n.next = tempM;
                    m = tempM;
                    n = tempN;
                }

            }
            public ListNode Reverse(ListNode start)
            {
                if (start == null || start.next == null) return start;
                ListNode m = start, n = start.next;
                start.next = null;
                while (m != null & n != null)
                {
                    ListNode temp = n.next;
                    n.next = m;
                    m = n;
                    n = temp;
                }
                return m;
            }

            // 445. Add Two Numbers II (Medium)
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                Stack<int> s1 = new Stack<int>();
                Stack<int> s2 = new Stack<int>();
                while (l1 != null)
                {
                    s1.Push(l1.val);
                    l1 = l1.next;
                }
                while (l2 != null)
                {
                    s2.Push(l2.val);
                    l2 = l2.next;
                }
                int sum = 0;
                ListNode cur = new ListNode(0, null);
                while (s1.Count() != 0 || s2.Count() != 0)
                {
                    if (s1.Count() != 0)
                        sum += s1.Pop();
                    if (s2.Count() != 0)
                        sum += s2.Pop();
                    cur.val = sum % 10;
                    ListNode head = new ListNode(sum / 10, cur);
                    cur = head;
                    sum = sum / 10;
                }

                return cur.val == 0 ? cur.next : cur;
            }

            //  24. Swap Nodes in Pairs (Medium)
            public ListNode SwapPairs(ListNode head)
            {
                ListNode dummyHead = new ListNode(-1, head);
                ListNode current = dummyHead, first, second;
                while (current.next != null && current.next.next != null)
                {
                    first = current.next;
                    second = current.next.next;

                    first.next = second.next;
                    current.next = second;
                    second.next = first;
                    current = current.next.next;

                }
                return dummyHead.next;
            }

            // 142. Linked List Cycle II (Medium)
            public ListNode DetectCycle(ListNode head)
            {
                HashSet<ListNode> values = new HashSet<ListNode>();
                while (head != null)
                {
                    if (values.Contains(head))
                        return head;
                    else
                        values.Add(head);
                    head = head.next;
                }
                return null;
            }
            // 2095. Delete the Middle Node of a Linked List (Medium)
            public ListNode DeleteMiddle(ListNode head)
            {
                if (head == null)
                    return null;
                if (head.next == null)
                    return null;
                ListNode slow = head, fast = head;
                while (fast != null && fast.next != null)
                {

                    fast = fast.next.next;
                    if (fast == null || fast.next == null)
                        break;
                    slow = slow.next;
                }
                slow.next = slow.next.next;
                return head;
            }
            // 83. Remove Duplicates from Sorted List (Easy)
            public ListNode DeleteDuplicates(ListNode head)
            {

                if (head == null)
                    return null;
                ListNode dummyNode = head;
                while (dummyNode.next != null)
                {
                    while (dummyNode.val == dummyNode.next.val)
                    {
                        if (dummyNode.next.next == null)
                        {
                            dummyNode.next = null; break;
                        }
                        else
                        {
                            dummyNode.next = dummyNode.next.next;
                        }
                    }
                    if (dummyNode.next != null)
                        dummyNode = dummyNode.next;
                }
                return head;
            }

            // 148. Sort List (Medium)
            public ListNode SortList(ListNode head)
            {
                if (head == null || head.next == null)
                    return head;
                ListNode temp = head, slow = head, fast = head;
                while (fast != null && fast.next != null)
                {
                    temp = slow;
                    slow = slow.next;
                    fast = fast.next.next;
                }
                temp.next = null;
                ListNode left_side = SortList(head);
                ListNode right_side = SortList(slow);

                return Merge(left_side, right_side);
            }

            public ListNode Merge(ListNode left, ListNode right)
            {
                ListNode sorted_temp = new ListNode(0);
                ListNode current_node = sorted_temp;
                while (left != null & right != null)
                {
                    if (left.val < right.val)
                    {
                        current_node.next = left;
                        left = left.next;
                    }
                    else
                    {
                        current_node.next = right;
                        right = right.next;
                    }
                    current_node = current_node.next;
                }
                if (left != null)
                {
                    current_node.next = left;
                    left = left.next;
                }
                if (right != null)
                {
                    current_node.next = right;
                    right = right.next;
                }
                return sorted_temp.next;
            }

            // 160. Intersection of Two Linked Lists (Easy)
            public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
            {
                if (headA == null || headB == null)
                    return null;
                ListNode p = headA;
                ListNode q = headB;
                while (p != q)
                {
                    p = (p != null) ? p.next : headB;
                    q = (q != null) ? q.next : headA;
                }

                return p;
            }

            // 234. Palindrome Linked List (Easy)
            public bool IsPalindrome(ListNode head)
            {
                ListNode slow = head, fast = head, prev, temp;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                prev = slow;
                slow = slow.next;
                prev.next = null;
                while (slow != null)
                {
                    temp = slow.next;
                    slow.next = prev;
                    prev = slow;
                    slow = temp;

                }
                fast = head;
                slow = prev;
                while (slow != null)
                {
                    if (fast.val != slow.val)
                    {
                        return false;
                    }
                    slow = slow.next;
                    fast = fast.next;
                }
                return true;
            }

            // 141. Linked List Cycle (Easy)
            public bool HasCycle(ListNode head)
            {
                HashSet<ListNode> values = new HashSet<ListNode>();
                while (head != null)
                {
                    if (values.Contains(head))
                        return true;
                    else
                        values.Add(head);
                    head = head.next;
                }
                return false;
            }

            // 203. Remove Linked List Elements (Easy)
            public ListNode RemoveElements(ListNode head, int val)
            {
                if (head == null)
                    return null;
                ListNode dummyNode = new ListNode(-1, head);
                ListNode result = dummyNode;
                while (dummyNode.next != null)
                {
                    if (dummyNode.next.val == val)
                    {
                        dummyNode.next = dummyNode.next.next;
                    }
                    else
                    {
                        dummyNode = dummyNode.next;
                    }
                }
                return result.next;
            }

            // 82. Remove Duplicates from Sorted List II
            public ListNode DeleteDuplicates2(ListNode head)
            {
                ListNode sentinelNode = new ListNode(-1, head);
                if (sentinelNode == null)
                    return null;
                ListNode pred = sentinelNode;
                while (head != null)
                {
                    if (head.next != null && head.val == head.next.val)
                    {
                        while (head.next != null && head.val == head.next.val)
                        {
                            head = head.next;
                        }

                        pred.next = head.next;
                    }
                    else
                    {
                        pred = pred.next;
                    }
                    head = head.next;
                }
                return sentinelNode.next;
            }

            // 2. Add Two Numbers (Medium)
            public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
            {
                ListNode dummyNode = new ListNode(-1, null);
                ListNode head = dummyNode;
                int tempint = 0;
                while (l1 != null && l2 != null)
                {
                    if (l1.val + l2.val + tempint >= 10)
                    {
                        dummyNode.next = new ListNode(l1.val + l2.val - 10 + tempint, null);
                        tempint = 1;
                    }
                    else
                    {
                        dummyNode.next = new ListNode(l1.val + l2.val + tempint, null);
                        tempint = 0;
                    }

                    l1 = l1.next;
                    l2 = l2.next;
                    dummyNode = dummyNode.next;
                }
                while (l1 != null)
                {
                    if (l1.val + tempint == 10)
                    {
                        dummyNode.next = new ListNode(0, null);
                        tempint = 1;
                    }
                    else
                    {
                        dummyNode.next = new ListNode(l1.val + tempint, null);
                        tempint = 0;
                    }
                    l1 = l1.next;
                    dummyNode = dummyNode.next;
                }
                while (l2 != null)
                {
                    if (l2.val + tempint == 10)
                    {
                        dummyNode.next = new ListNode(0, null);
                        tempint = 1;
                    }
                    else
                    {
                        dummyNode.next = new ListNode(l2.val + tempint, null);
                        tempint = 0;
                    }
                    l2 = l2.next;
                    dummyNode = dummyNode.next;
                }
                if (tempint == 1)
                    dummyNode.next = new ListNode(1, null);
                return head.next;
            }
        // 2058. Find the Minimum and Maximum Number of Nodes Between Critical Points (Medium)
        public int[] NodesBetweenCriticalPoints(ListNode head)
            {
                int minDist = int.MaxValue, maxDist = int.MinValue, currentDist = 1, prevValue = 0, distCounter = 0, lastDist = int.MinValue, firstDist = int.MinValue;
                List<int> result = new List<int>();
                if (head == null || head.next == null)
                {
                    result.Add(-1);
                    result.Add(-1);
                    return result.ToArray();
                }

                ListNode pointer = head.next;
                prevValue = head.val;
                while (pointer.next != null)
                {
                    if ((pointer.val < pointer.next.val && pointer.val < prevValue) || (pointer.val > pointer.next.val && pointer.val > prevValue))
                    {
                        if (lastDist == int.MinValue)
                        {
                            lastDist = currentDist;
                        }
                        else
                        {
                            minDist = Math.Min(minDist, currentDist - lastDist);
                            lastDist = currentDist;
                        }
                        if (firstDist == int.MinValue)
                        {
                            firstDist = currentDist;
                        }
                        else
                        {
                            maxDist = Math.Max(maxDist, currentDist - firstDist);
                        }
                        distCounter++;
                    }
                    currentDist++;
                    prevValue = pointer.val;
                    pointer = pointer.next;
                }


                if (distCounter < 2)
                {
                    result.Add(-1);
                    result.Add(-1);
                    return result.ToArray();
                }
                result.Add(minDist);
                result.Add(maxDist);
                return result.ToArray();
            }

        // 817. Linked List Components (Medium)
        public int NumComponents(ListNode head, int[] nums)
        {
            int result = 0;
            HashSet<int> compareSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                compareSet.Add(nums[i]);
            }
            ListNode dummyHead = new ListNode(-1, head);
            while (dummyHead.next != null)
            {
                if (!compareSet.Contains(dummyHead.val) && compareSet.Contains(dummyHead.next.val))
                {
                    result++;
                }
                dummyHead = dummyHead.next;
            }
            return result;
        }

        // 92. Reverse Linked List II (Medium)
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode prev = null, next = null, temp = null;
            ListNode dummyNode = new ListNode(-1, head);
            ListNode res = dummyNode;
            int index = 0, amount = right - left + 1;
            while (dummyNode != null)
            {
                if (index == left - 1)
                {
                    index = 0;
                    ListNode currentNode = dummyNode.next;
                    temp = currentNode;
                    while (index < amount)
                    {
                        next = currentNode.next;
                        currentNode.next = prev;
                        prev = currentNode;
                        currentNode = next;
                        index++;
                    }
                    temp.next = next;
                    dummyNode.next = prev;
                    break;
                }
                dummyNode = dummyNode.next;
                index++;
            }
            return res.next;
        }

        // 61. Rotate List (Medium)
        public ListNode RotateRight(ListNode head, int k)
        {
            ListNode slow = head, fast = head;
            if (head == null)
                return null;
            int count = 0;
            ListNode temp = head;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }    
            k = k % count;
            for (int i = 0; i < k; i++)
            {
                fast = fast.next;   
            }
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            fast.next = head;
            ListNode result = slow.next;
            slow.next = null;
            return result;
        }

        // 725. Split Linked List in Parts (Medium)
        public ListNode[] SplitListToParts(ListNode head, int k)
        {
            ListNode[] result = new ListNode[k];
            if (k == 1)
            {
                result[0] = head;
                return result;
            }   
            ListNode temp = head;
            int count = 0;
            while (temp != null)
            {
                temp = temp.next;
                count++;
            }
            temp = null;
            for (int i = 0; i < k; i++)
            {
                result[i] = head;
                int j = count / k + (i < count % k ? 1 : 0);
                while (head != null && j > 0)
                {
                    temp = head;
                    head = head.next;
                    j--;
                }
                if (temp != null)
                    temp.next = null;
            }
            return result;
        }


        // 1206. Design Skiplist (Hard)
        public class Skiplist
        {
            private SkipNode head;
            private SkipNode tail;

            public Skiplist()
            {
                this.head = new SkipNode(int.MinValue);
                this.tail = new SkipNode(int.MaxValue);
                head.right = tail;
                tail.left = head;
            }

            public bool Search(int target)
            {
                SkipNode curr = head;
                while (curr != null)
                {
                    while (curr.right != null && curr.right.val <= target)
                        curr = curr.right;
                    if (curr.val == target)
                        return true;
                    curr = curr.down;
                }
                return false;
            }

            public void Add(int num)
            {
                List<SkipNode> pointersToUpdate = new List<SkipNode>();
                SkipNode curr = head;
                while (curr != null)
                {
                    while (curr.right != null && curr.right.val < num)
                    {
                        curr = curr.right;
                    }
                    pointersToUpdate.Add(curr);
                    curr = curr.down;
                }

                int level = 0;
                SkipNode newNode = null;

                while (level == 0 || FlipCoin())
                {
                    if (newNode == null)
                    {
                        newNode = new SkipNode(num);
                    }
                    else
                    {
                        newNode = new SkipNode(newNode);
                    }

                    SkipNode nodeToUpdate;

                    if (pointersToUpdate.Count() <= level)
                    {
                        CreateNewLayer();
                        nodeToUpdate = this.head;
                    }
                    else
                    {
                        nodeToUpdate = pointersToUpdate.ElementAt(pointersToUpdate.Count() - level - 1);
                    }

                    newNode.right = nodeToUpdate.right;
                    newNode.left = nodeToUpdate;
                    newNode.right.left = newNode;
                    nodeToUpdate.right = newNode;

                    level++;
                }
            }

            private bool FlipCoin()
            {
                Random rnd = new Random();
                return rnd.NextDouble() >= 0.5 ? true : false;
            }

            private void CreateNewLayer() 
            {
                SkipNode newHead = new SkipNode(int.MinValue);
                SkipNode newTail = new SkipNode(int.MaxValue);

                newHead.right = newTail;
                newTail.left = newHead;

                head.up = newHead;
                newHead.down = head;
                head = newHead;

                tail.up = newTail;
                newTail.down = tail;
                tail = newTail;
            }

            public bool Erase(int num)
            {
                List<SkipNode> pointersToUpdate = new List<SkipNode>();
                SkipNode curr = head;
                while (curr != null)
                {
                    while (curr.right != null && curr.right.val < num)
                    {
                        curr = curr.right;
                    }
                    if (curr.right.val == num)
                        pointersToUpdate.Add(curr);
                    curr = curr.down;
                }

                for (int i = 0; i < pointersToUpdate.Count(); i++)
                {
                    SkipNode nodeToUpdate = pointersToUpdate.ElementAt(i);
                    SkipNode nodeToDelete = nodeToUpdate.right;

                    nodeToUpdate.right = nodeToDelete.right;

                    nodeToDelete.up = null;
                    nodeToDelete.down = null;      
                }
                if (pointersToUpdate.Count() != 0)
                    return true;
                return false;
            }
        }

        public class SkipNode {
            public int val;
            public SkipNode left;
            public SkipNode right;
            public SkipNode up;
            public SkipNode down;

            public SkipNode(int val)
            {
                this.val = val;
                this.left = null;
                this.right = null;
                this.up = null;
                this.down = null;
            }

            public SkipNode(SkipNode lowerLevelNode)
            {
                this.val = lowerLevelNode.val;
                this.left = null;
                this.right = null;
                this.up = null;
                this.down = lowerLevelNode;
            }
        }


        // 138. Copy List with Random Pointer (Medium)
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node CopyRandomList(Node head)
        {
            if (head == null)
            {
                return null;
            }
            Node start = head;
            while (start != null)
            {
                Node newNode = new Node(start.val);
                newNode.next = start.next;
                start.next = newNode;
                start = start.next.next;
            }
            Node res = head.next;
            start = head;
            while (start != null)
            {
                Node newNode = start.next;
                if (start.random != null)
                {
                    start.next.random = start.random.next; 
                }
                start = start.next.next;
            }
            start = head;
            while (start != null)
            {
                Node newNode = start.next;
                start.next = newNode.next;
                start = newNode.next;
                newNode.next = start == null ? null : start.next;
            }
            return res;
        }

        // 23. Merge k Sorted Lists (Hard)
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
            {
                return null;
            }
            if (lists.Length == 1)
            {
                return lists[0];
            }
            int iteration = lists.Length / 2;
            int lastIteration = lists.Length % 2;
            ListNode dummyHead = new ListNode(int.MinValue);
            int j = 0;
            ListNode headOne = null, headTwo = null, appendHead = dummyHead, tempNode = null;
            for (int i = 0; i < iteration; i++)
            {
                appendHead = dummyHead;
                headOne = lists[j];
                headTwo = lists[j + 1];
                while (headOne != null && headTwo != null)
                {
                    if (headOne.val <= headTwo.val)
                    {
                        if (appendHead.next != null && appendHead.next.val < headOne.val)
                        {
                            appendHead = appendHead.next;
                        }
                        else
                        {
                            tempNode = appendHead.next;
                            ListNode insertNode = new ListNode(headOne.val);
                            appendHead.next = insertNode;
                            appendHead.next.next = tempNode;
                            headOne = headOne.next;
                        }
                    }
                    else
                    {
                        if (appendHead.next != null && appendHead.next.val < headTwo.val)
                        {
                            appendHead = appendHead.next;
                        }
                        else
                        {
                            tempNode = appendHead.next;
                            ListNode insertNode = new ListNode(headTwo.val);
                            appendHead.next = insertNode;
                            appendHead.next.next = tempNode;
                            headTwo = headTwo.next;
                        }
                    }
                }

                while (headOne != null)
                {
                    if (appendHead.next != null && appendHead.next.val < headOne.val)
                    {
                        appendHead = appendHead.next;
                    }
                    else
                    {
                        tempNode = appendHead.next;
                        ListNode insertNode = new ListNode(headOne.val);
                        appendHead.next = insertNode;
                        appendHead.next.next = tempNode;
                        headOne = headOne.next;
                    }
                }
                while (headTwo != null)
                {
                    if (appendHead.next != null && appendHead.next.val < headTwo.val)
                    {
                        appendHead = appendHead.next;
                    }
                    else
                    {
                        tempNode = appendHead.next;
                        ListNode insertNode = new ListNode(headTwo.val);
                        appendHead.next = insertNode;
                        appendHead.next.next = tempNode;
                        headTwo = headTwo.next;
                    }
                }
                j += 2;
            }

            if (lastIteration == 1)
            {
                appendHead = dummyHead;
                headOne = lists[lists.Length - 1];
                while (headOne != null)
                {
                    if (appendHead.next != null && appendHead.next.val < headOne.val)
                    {
                        appendHead = appendHead.next;
                    }
                    else
                    {
                        tempNode = appendHead.next;
                        ListNode insertNode = new ListNode(headOne.val);
                        appendHead.next = insertNode;
                        appendHead.next.next = tempNode;
                        headOne = headOne.next;
                    }
                }

            }
            return dummyHead.next;
        }
        public void PrintAllNodes(ListNode head)
        {
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }


        // 707. Design Linked List (Medium)
        public class MyLinkedList
        {
            ListNode head;
            int count = 0;
            public MyLinkedList()
            {
                head = new ListNode(-1, null);
            }

            public int Get(int index)
            {
                ListNode temp = head;
                int ind = -1;
                if (count <= index)
                    return -1;
                while (index > ind && temp.next != null)
                {
                    temp = temp.next;
                    ind++;
                }
                return temp.val;
            }

            public ListNode GetNode(int index)
            {
                ListNode temp = head;
                int ind = -1;
                if (count < index)
                    return null;
                while (index > ind && temp.next != null)
                {
                    temp = temp.next;
                    ind++;
                }
                return temp;
            }

            public void AddAtHead(int val)
            {
                if (head.next != null)
                {
                    ListNode temp = head.next;
                    head.next = new ListNode(val, temp);
                }
                else
                {
                    head.next = new ListNode(val, null);
                }
                count++;
            }

            public void AddAtTail(int val)
            {
                ListNode temp = head;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new ListNode(val, null);
                count++;
            }

            public void AddAtIndex(int index, int val)
            {
                if (index > count)
                    return;
                if (index == count)
                {
                    AddAtTail(val);
                    return;
                }
                ListNode temp = head;
                int ind = 0;
                while (temp.next != null && index > ind)
                {
                    ind++;
                    temp = temp.next;
                }
                ListNode tempList = temp.next;
                temp.next = new ListNode(val, tempList);
                count++;
            }

            public void DeleteAtIndex(int index)
            {
                if (index >= count)
                    return;
                ListNode temp = head;
                int ind = -1;
                while (temp.next != null && index - 1 > ind)
                {
                    ind++;
                    temp = temp.next;
                }
                if (temp.next.next != null)
                    temp.next = temp.next.next;
                else
                    temp.next = null;
                count--;
            }
        }

        // 1171. Remove Zero Sum Consecutive Nodes from Linked List (Medium)
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode dummyHead = new ListNode(0, head);
            ListNode currNode = dummyHead;
            int prefixSum = 0;
            Dictionary<int, ListNode> prefixSumDic = new Dictionary<int, ListNode>();
            while (currNode != null)
            {
                prefixSum += currNode.val;
                if (prefixSumDic.ContainsKey(prefixSum))
                {
                    currNode = prefixSumDic[prefixSum].next;
                    int sum = prefixSum + currNode.val;
                    while (sum != prefixSum)
                    {
                        prefixSumDic.Remove(sum);
                        currNode = currNode.next;
                        sum += currNode.val;
                    }
                    prefixSumDic[prefixSum].next = currNode.next;
                }
                else
                {
                    prefixSumDic.Add(prefixSum, currNode);
                }
                currNode = currNode.next;
            }
            return dummyHead.next;
        }
    }
}
