using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Data_Structure_I
{
    class DataStructureI
    {
        static void Main(string[] args)
        {
            
        }

        // 217. Contains Duplicate (Easy)
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashSet.Contains(nums[i]))
                    return true;
                hashSet.Add(nums[i]);
            }
            return false;
        }

        // 53. Maximum Subarray (Easy)
        public int MaxSubArray(int[] nums)
        {
            int result = int.MinValue, currValue = int.MinValue;
            for(int i = 0; i < nums.Length; i++)
            {
                currValue = Math.Max(nums[i], currValue + nums[i]);
                result = Math.Max(result, currValue);
            }
            return result;
        }

        // 1. Two Sum (Easy)
        public int[] TwoSum(int[] nums, int target)
        {
            List<int> result = new List<int>();
            List<int> array = nums.ToList();

            for (int i = 0; i < nums.Length; i++)
            {
                if (array.FindIndex(item => item == (target - array[i])) != -1)
                {
                    if (i != array.FindIndex(item => item == (target - array[i])))
                    {
                        result.Add(i);
                        result.Add(array.FindIndex(item => item == (target - array[i])));
                        break;
                    }
                }

            }

            return result.ToArray();
        }

        // 88. Merge Sorted Array (Easy)
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = m, j =0; i < nums1.Length; i++, j++)
            {
                nums1[i] = nums2[j];
            }
            Array.Sort(nums1);
        }

        // 350. Intersection of Two Arrays II (Easy)
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();
            Array.Sort(nums1);
            Array.Sort(nums2);
            if (nums1.Length > nums2.Length)
            {
                int startIndex = 0;

                bool isUpdated = false;

                for (int i = 0; i < nums2.Length; i++)
                {
                    if (isUpdated && nums2[i] == nums2[i - 1])
                        startIndex++;
                    int left = startIndex, right = nums1.Length - 1, mid = 0;
                    isUpdated = false;
                    while (left <= right)
                    {
                        mid = left + (right - left) / 2;
                        if (mid > nums1.Length - 1)
                            break;
                        if (nums1[mid] == nums2[i])
                        {
                            startIndex = mid;
                            right = mid - 1;
                            isUpdated = true;
                        }
                        else if (nums1[mid] > nums2[i])
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    if (startIndex > nums1.Length - 1)
                        continue;
                    if (nums1[startIndex] == nums2[i] && isUpdated)
                        result.Add(nums1[startIndex]);

                }
            }
            else
            {
                int startIndex = 0;
                bool isUpdated = false;

                for (int i = 0; i < nums1.Length; i++)
                {


                    if (isUpdated && nums1[i] == nums1[i - 1])
                        startIndex++;
                    int left = startIndex, right = nums2.Length - 1, mid = 0;
                    isUpdated = false;
                    while (left <= right)
                    {
                        mid = left + (right - left) / 2;

                        if (nums2[mid] == nums1[i])
                        {
                            startIndex = mid;
                            right = mid - 1;
                            isUpdated = true;
                        }
                        else if (nums2[mid] > nums1[i])
                        {
                            right = mid - 1;
                        }
                        else
                        {
                            left = mid + 1;
                        }
                    }
                    if (startIndex > nums2.Length - 1)
                        continue;
                    if (nums2[startIndex] == nums1[i] && isUpdated)
                        result.Add(nums2[startIndex]);
                }
            }

            return result.ToArray();
        }

        // 121. Best Time to Buy and Sell Stock (Easy)
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int result = 0;
            
            int minPrice = prices[0];
            for (int i = 0; i < prices.Length; i++)
            {
                result = Math.Max(result, prices[i] - minPrice);
                minPrice = Math.Min(minPrice, prices[i]);

            }
            return result;
        }

        // 118. Pascal's Triangle (Easy)
        public static IList<IList<int>> Generate(int numRows)
        {
            List<List<int>> result = new List<List<int>>();

            if (numRows == 1)
            {
                result.Add(new List<int>(1));
                result[0].Add(1);
                return result.ToArray();
            }
            if (numRows == 2)
            {
                result.Add(new List<int>(1));
                result[0].Add(1);
                result.Add(new List<int>(2));
                result[1].Add(1);
                result[1].Add(1);
                return result.ToArray();
            }
            result.Add(new List<int>(1));
            result[0].Add(1);
            result.Add(new List<int>(2));
            result[1].Add(1);
            result[1].Add(1);
            result.Add(new List<int>(3));
            result[2].Add(1);
            result[2].Add(2);
            result[2].Add(1);
            for (int i = 3; i < numRows; i++)
            {
                result.Add(new List<int>());
                result[i].Add(1);
                for (int j = 1; j <= i - 1; j++)
                {
                    result[i].Add(result[i - 1][j - 1] + result[i - 1][j]);
                }
                result[i].Add(1);
            }
            return result.ToArray();
        }

        // 566. Reshape the Matrix (Easy)
        public int[][] MatrixReshape(int[][] mat, int r, int c)
        {
            if (mat.GetLength(0) * mat[0].Length != r * c)
                return mat;

            int[][] result = new int[r][];

            for (int i = 0; i < r; i++)
                result[i] = new int[c];

            int arrI = 0, arrJ = 0;
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (arrJ >= mat[arrI].Length)
                    {
                        arrJ = 0;
                        arrI++;
                    }
                    if (arrI >= mat.GetLength(0))
                        break;
                    result[i][j] = mat[arrI][arrJ];
                    arrJ++;
                }
                if (arrI >= mat.GetLength(0))
                    break;
            }
            return result;
        }

        // 74. Search a 2D Matrix (Medium)
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int i = 0, j = matrix[0].Length - 1;
            int numberOfRows = matrix.GetLength(0);
            while (i < numberOfRows && j >= 0)
            {
                if (matrix[i][j] == target)
                    return true;
                else if (matrix[i][j] > target)
                    j--;
                else
                    i++;
            }
            return false;
        }

        // 36. Valid Sudoku (Medium)
        public static bool IsValidSudoku(char[][] board)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            counter.Add('.', 0);
            for (int i = 49; i <= 57; i++)
                counter.Add((char)i, 0);

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    counter[board[i][j]] += 1;
                }
                if (CheckCounter(counter))
                    return false;
                CleanCounter(counter);
            }

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    counter[board[j][i]] += 1;
                }
                if (CheckCounter(counter))
                    return false;
                CleanCounter(counter);
            }
            for (int i = 0; i < 9-2; i = i + 3)
            { 
                for(int j = 0; j < 9; j++)
                {
                    counter[board[i][j]] += 1;
                    counter[board[i + 1][j]] += 1;
                    counter[board[i + 2][j]] += 1;
                    if ((j+1) % 3 == 0)
                    {
                        if (CheckCounter(counter))
                            return false;
                        CleanCounter(counter);
                    }
                }
            }
            return true;

        }
        public static Dictionary<char, int> CleanCounter(Dictionary<char, int> counter)
        {
            for (int i = 49; i <= 57; i++)
                counter[(char)i] = 0;
            return counter;
        }
        public static bool CheckCounter(Dictionary<char, int> counter)
        {
            foreach (KeyValuePair<char, int> item in counter)
            {
                if (item.Value > 1 && item.Key != '.')
                    return true;
            }
            return false;
        }


        // 242. Valid Anagram (Easy)
        public bool IsAnagram(string s, string t)
        {
            Dictionary<char, int> set = new Dictionary<char, int>();

            for (int i = 96; i < 123; i++)
            {
                set.Add((char)i, 0);
            }

            foreach (char item in s)
            {
                set[item]++;
            }
            foreach (char item in t)
            {
                set[item]--;
                if (set[item] < 0)
                    return false;
            }
            foreach (int item in set.Values)
            {
                if (item != 0)
                    return false;
            }
            return true;
        }

        // 387. First Unique Character in a String (Easy)
        public static int FirstUniqChar(string s)
        {
            int result = -1;
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (letters.ContainsKey(s[i]))
                    letters[s[i]] += 1;
                else
                    letters.Add(s[i], 1);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (letters[s[i]] == 1)
                {
                    result = i;
                    break;
                }    
                 
            }

            return result;
        }

        // 383. Ransom Note (Easy)
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (letters.ContainsKey(magazine[i]))
                    letters[magazine[i]] += 1;
                else
                    letters.Add(magazine[i], 1);
            }
            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (!letters.ContainsKey(ransomNote[i]))
                    return false;
                else if (letters.ContainsKey(ransomNote[i]))
                {
                    if (letters[ransomNote[i]] == 0)
                        return false;
                    else
                        letters[ransomNote[i]] -= 1;
                }

            }
            return true;
        }

        
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
            public ListNode(int x, ListNode next)
            {
                val = x;
                this.next = next;
            }
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

        // 206. Reverse Linked List (Easy)
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
            {
                return head;
            }
            ListNode prev = null, next = null;
            while(head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
                
            }

            head = prev;

            return head;
        }


        // 83. Remove Duplicates from Sorted List (Easy)
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;
            ListNode curr = head;
            while (curr.next != null)
            {
                    while (curr.next != null && curr.val == curr.next.val)
                    {
                        curr.next = curr.next.next;
                    }
                if (curr.next == null)
                    break;
                curr = curr.next;
            }
            return head;
        }

        // 232. Implement Queue using Stacks (Easy)
        public class MyQueue
        {

            Stack<int> stackMain;
            Stack<int> stackSupport;

            public MyQueue()
            {
                stackMain = new Stack<int>();
                stackSupport = new Stack<int>();

            }

            public void Push(int x)
            {
                stackSupport.Clear();
                while (stackMain.Count() != 0)
                {
                    stackSupport.Push(stackMain.Pop());
                }
                stackMain.Push(x);
                while (stackSupport.Count() != 0)
                {
                    stackMain.Push(stackSupport.Pop());
                }
            }

            public int Pop()
            {
                return stackMain.Pop();
            }

            public int Peek()
            {
                return stackMain.Peek();
            }

            public bool Empty()
            {
                return stackMain.Count() == 0 ? true : false;
            }
        }

        // 20. Valid Parentheses (Easy)
        public bool IsValid(string s)
        {
            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[' || s[i] == '{' || s[i] == '(')
                {
                    parentheses.Push(s[i]);
                }
                else
                {
                    if (parentheses.Count != 0)
                    {
                        if ((s[i] == ')' && '(' != parentheses.Peek()) || (s[i] == '}' && '{' != parentheses.Peek()) || (s[i] == ']' && '[' != parentheses.Peek()))
                            return false;
                        else
                            parentheses.Pop();
                    }
                    else
                        return false;
                }
            }

            if (parentheses.Count() != 0)
                return false;

            return true;
        }

        // 144. Binary Tree Preorder Traversal (Easy)
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null)
            {
                PreorderTraversal(root, result);
            }
            return result.ToArray();

        }
        public void PreorderTraversal(TreeNode root, List<int> result)
        {
            if (root != null)
            {
                result.Add(root.val);
                PreorderTraversal(root.left, result);
                PreorderTraversal(root.right, result);
            }
        }


        // 94. Binary Tree Inorder Traversal(Easy)

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null)
            {
                InorderTraversal(root, result);
            }
            return result.ToArray();

        }
        public void InorderTraversal(TreeNode root, List<int> result)
        {
            if (root != null)
            {
                InorderTraversal(root.left, result);
                result.Add(root.val);
                InorderTraversal(root.right, result);
            }
        }

        // 145. Binary Tree Postorder Traversal (Easy)
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null)
            {
                PostorderTraversal(root, result);
            }
            return result.ToArray();

        }
        public void PostorderTraversal(TreeNode root, List<int> result)
        {
            if (root != null)
            {
                PostorderTraversal(root.left, result);
                PostorderTraversal(root.right, result);
                result.Add(root.val);
                
            }
        }

        // 104. Maximum Depth of Binary Tree (Easy)
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            int currentMax = int.MinValue, result = 1;
            MaxDepth(root, result, ref currentMax);

            return currentMax;
        }
        public void MaxDepth(TreeNode node, int result, ref int currentMax)
        {
            result++;
            if (node == null)
            {
                result = result - 2;
                currentMax = Math.Max(currentMax, result);
            }
            else
            {
                MaxDepth(node.left, result, ref currentMax);
                MaxDepth(node.right, result, ref currentMax);
            }

        }

        // 101. Symmetric Tree (Easy)
        public bool IsSymmetric(TreeNode root)
        {    
            return IsMirror(root, root);
        }
        public bool IsMirror(TreeNode leftNode, TreeNode rightNode)
        {
            if (leftNode == null && rightNode == null)
                return true;
            else if (leftNode == null || rightNode == null)
                return false;
            return leftNode.val == rightNode.val && IsMirror(leftNode.left, rightNode.right) && IsMirror(leftNode.right, rightNode.left);
        }

        // 102. Binary Tree Level Order Traversal (Medium)
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<List<int>> levelOrder = new List<List<int>>();
            int currLevel = 0, maxLevel = int.MinValue;

            if (root == null)
                return levelOrder.ToArray();

            TreeTraversal(root, currLevel, ref maxLevel, levelOrder);

            
            return levelOrder.ToArray();
        }

        public static void TreeTraversal(TreeNode root, int currLevel, ref int maxLevel, List<List<int>> result)
        {
            if (root != null)
            {
                currLevel++;
                if (currLevel > maxLevel)
                {
                    maxLevel = currLevel;
                    result.Add(new List<int>());
                }
                result[--currLevel].Add(root.val);
                TreeTraversal(root.left, currLevel + 1, ref maxLevel, result);
                TreeTraversal(root.right, currLevel + 1, ref maxLevel, result);
            }
        }

        // 112. Path Sum (Easy)
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;

            HashSet<int> results = new HashSet<int>();
            
            HasPathSum(root, 0, results);
            
            if (results.Contains(targetSum))
                return true;
            return false;
        }
        public void HasPathSum(TreeNode root, int result, HashSet<int> results)
        {
            if (root != null)
            {
                result += root.val;
                HasPathSum(root.left, result, results);
                HasPathSum(root.right, result, results);
                if (!results.Contains(result) && root.left == null && root.right == null)
                    results.Add(result);
            }
        }

        // 226. Invert Binary Tree (Easy)
        public TreeNode InvertTree(TreeNode root)
        {
            InvertTreeMethod(root);

            return root;
        }
        public void InvertTreeMethod(TreeNode root)
        {
            if (root != null)
            {
                TreeNode temp = root.left;
                root.left = root.right;
                root.right = temp;
                InvertTreeMethod(root.left);
                InvertTreeMethod(root.right);
            }
        }

        // 700. Search in a Binary Search Tree (Easy)
        public TreeNode SearchBST(TreeNode root, int val)
        {
            TreeNode result = null;
            SearchBST(root, val, ref result);
            return result;
        }
        public void SearchBST(TreeNode root, int val, ref TreeNode result)
        {
            if (root != null)
            {
                if (result != null && result.val == val)
                    return;
                if (root.val == val)
                {
                    result = root;
                    return;
                }
                if(root.val > val)
                SearchBST(root.left, val, ref result);
                else
                SearchBST(root.right, val, ref result);
            }
        }

        // 235. Lowest Common Ancestor of a Binary Search Tree (Easy)
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (p.val == root.val || q.val == root.val)
                return root;
            if (p.val < root.val && q.val > root.val)
                return root;
            if (p.val > root.val && q.val < root.val)
                return root;
            List<TreeNode> pNodes = new List<TreeNode>();

            FindPath(root, p, pNodes);

            Queue<TreeNode> nodesVisisted = new Queue<TreeNode>();

            for (int i = pNodes.Count - 1; i >= 0; i--)
            {
                nodesVisisted.Enqueue(pNodes[i]);
                while (nodesVisisted.Count() != 0)
                {
                    TreeNode Node = nodesVisisted.Dequeue();
                    if (Node == q)
                        return pNodes[i];
                    if (Node.left != null)
                    {
                        if (Node.left == q)
                            return pNodes[i];
                        nodesVisisted.Enqueue(Node.left);
                    }
                    if (Node.right != null)
                    {
                        if (Node.right == q)
                            return pNodes[i];
                        nodesVisisted.Enqueue(Node.right);
                    }
                }
            }
            return root;
        }

        public void FindPath(TreeNode root, TreeNode p, List<TreeNode> treeNodes)
        {
            if (root != null)
            {
                treeNodes.Add(root);
                if (root.left == null)
                {
                    if (root.right != null)
                    {
                        if (root.right.val == p.val)
                        {
                            treeNodes.Add(root.right);
                            return;
                        }
                        FindPath(root.right, p, treeNodes);
                    }
                    
                }
                else
                {
                    if (root.right == null)
                    {
                        if (root.left.val == p.val)
                        {
                            treeNodes.Add(root.left);
                            return;
                        }
                        FindPath(root.left, p, treeNodes);
                    }
                    else
                    {
                        if (root.left.val == p.val || root.right.val == p.val)
                        {
                            if(root.left.val == p.val)
                                treeNodes.Add(root.left);
                            else
                                treeNodes.Add(root.right);
                            return;
                        }
                        else if(p.val > root.val)
                            FindPath(root.right, p, treeNodes);
                        else
                            FindPath(root.left, p, treeNodes);
                    }
                }
            }
        }

        // 701. Insert into a Binary Search Tree (Medium)
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);
            if (root.val < val)
            {
                root.right = InsertIntoBST(root.right, val);
            }
            else if (root.val > val)
            {
                root.left = InsertIntoBST(root.left, val);
            }


            return root;
        }

        // 98. Validate Binary Search Tree (Medium)
        public bool IsValidBST(TreeNode root)
        {
            bool isValid = true;

            List<int> treeValues = new List<int>();
            DFS(root, treeValues, ref isValid);

            return isValid;
        }
        public void DFS(TreeNode root, List<int> treeValues, ref bool isValid)
        {
            if (root != null && isValid)
            {
                DFS(root.left, treeValues, ref isValid);
                if (treeValues.Where(item => item >= root.val).Count() != 0) 
                {
                    isValid = false;
                    return;
                }
                treeValues.Add(root.val);
                DFS(root.right, treeValues, ref isValid);
            }
        }
        // 653. Two Sum IV - Input is a BST (Easy)
        public bool FindTarget(TreeNode root, int k)
        {
            bool result = false;
            List<int> treeNodes = new List<int>();
            FindK(root, k, ref result, treeNodes);
            return result;
        }
        public void FindK(TreeNode root, int k, ref bool result, List<int> treeNodes)
        {
            if (root != null && !result)
            {
                if(treeNodes.Contains(k - root.val))
                {
                    result = true;
                    return;
                }
                treeNodes.Add(root.val);
                FindK(root.left, k, ref result, treeNodes);
                FindK(root.right, k, ref result, treeNodes);
            }
        }
    }
}
