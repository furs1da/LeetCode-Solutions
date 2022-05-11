using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProgrammingSkills
{
    class ProgrammingSkills
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[][] { new int[] { 1, 2, 3 }, new int[] {4,5,6 }, new int[]{7,8,9 } };
            Console.WriteLine(DiagonalSum(mat));
        }



        // 1523. Count Odd Numbers in an Interval Range (Easy)
        public int CountOdds(int low, int high)
        {
            int result = (high - low) / 2;
            if (high % 2 != 0 || low % 2 != 0)
                result++;
            return result;
        }

        // 1491. Average Salary Excluding the Minimum and Maximum Salary (Easy)
        public double Average(int[] salary)
        {
            double result = 0;
            int min = int.MaxValue, max = int.MinValue;
            int count = 0;
            for (int i = 0; i < salary.Length; i++)
            {
                if (salary[i] < min)
                {
                    min = salary[i];
                }
                if (salary[i] > max)
                {
                    max = salary[i];
                }
                result += salary[i];
            }
            result = (result - min - max) / (salary.Length - 2);
            return result;
        }


        // 1281. Subtract the Product and Sum of Digits of an Integer (Easy)
        public int SubtractProductAndSum(int n)
        {
            string nString = n.ToString();
            int product = 1, sum = 0;
            for (int i = 0; i < nString.Length; i++)
            {
                sum += Int32.Parse(nString[i].ToString());
                product = product * Int32.Parse(nString[i].ToString());
            }
            return product - sum;
        }

        // 191. Number of 1 Bits (Easy)
        public int HammingWeight(uint n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
            {
                return 1;
            }

            uint result = 0;
            while (n != 0)
            {
                result += n % 2;
                n = n >> 1;
            }
            return (int)result;
        }

        // 976. Largest Perimeter Triangle (Easy)
        public int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);

            for (int i = nums.Length - 3; i >= 0; i--)
            {
                if (nums[i + 2] < nums[i] + nums[i + 1])
                    return nums[i + 2] + nums[i] + nums[i + 1];
            }

            return 0;
        }

        // 1779. Find Nearest Point That Has the Same X or Y Coordinate (Easy)
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            int result = int.MaxValue;
            int oldResult = result;
            int index = int.MaxValue;
            for (int i = 0; i < points.GetLength(0); i++)
            {
                if (points[i][0] == x || points[i][1] == y)
                {
                    result = Math.Min(result, (Math.Max(points[i][0], x) - Math.Min(points[i][0], x)) + (Math.Max(points[i][1], y) - Math.Min(points[i][1], y)));
                    if (oldResult > result)
                    {
                        index = i;
                        oldResult = result;
                    }
                }
            }

            return result != int.MaxValue ? index : -1; ;
        }

        // 1822. Sign of the Product of an Array (Easy)
        public int ArraySign(int[] nums)
        {
            int res = 1;
            foreach (int item in nums)
            {
                if (item == 0)
                    return 0;
                else
                    res = Math.Sign(item) * res;
            }
            return res > 0 ? 1 : -1;
        }


        // 1502. Can Make Arithmetic Progression From Sequence (Easy)
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            if (arr.Length == 0 || arr.Length == 1)
                return true;

            int difference = arr[1] - arr[0];
            for(int i = 1; i < arr.Length; i++)
            {
                if (difference != arr[i] - arr[i - 1])
                    return false;
            }

            return true;
        }

        // 202. Happy Number (Easy)
        public bool IsHappy(int n)
        {
            HashSet<int> table = new HashSet<int>();
            string forN = "";
            while (n != 1)
            {
                forN = n.ToString();
                n = 0;
                for (int i = 0; i < forN.Length; i++)
                {
                    n += int.Parse(forN[i].ToString()) * int.Parse(forN[i].ToString());
                }
                if (table.Contains(n))
                    return false;
                else
                    table.Add(n);
            }
            return true;
        }

        // 1790. Check if One String Swap Can Make Strings Equal (Easy)
        public bool AreAlmostEqual(string s1, string s2)
        { 
            int counter = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    counter++;
                }
                if (counter > 2)
                    return false;
            }
            if (counter <= 2)
            {
                char[] res1 = s1.ToCharArray();
                char[] res2 = s2.ToCharArray();
                Array.Sort(res1);
                Array.Sort(res2);
                for (int i = 0; i < res1.Length; i++)
                {
                    if (res1[i] != res2[i])
                        return false;
                }

            }
            return true;
        }

        // 1232. Check If It Is a Straight Line (Easy)
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.GetLength(0) == 1 || coordinates.GetLength(0) == 0)
                return true;
            int differenceX = coordinates[0][0] - coordinates[1][0];
            int differenceY = coordinates[0][1] - coordinates[1][1];

            for (int i = 1; i < coordinates.GetLength(0); i++)
            {
                if ((coordinates[i - 1][0] - coordinates[i][0]) * differenceY != (coordinates[i - 1][1] - coordinates[i][1]) * differenceX)
                    return false;
            }
            return true;
        }

        // 496. Next Greater Element I (Easy)
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();

            Hashtable hashtable = new Hashtable();

            for(int i =0; i < nums2.Length; i++)
            {
                hashtable.Add(nums2[i], i);
            }

            int startIndex = -1;
            int addItem = -1;
            for(int i = 0; i < nums1.Length; i++)
            {
                startIndex = (int)hashtable[nums1[i]];
                addItem = -1;
                for (int j = startIndex; j < nums2.Length; j++)
                {
                    if (nums1[i] < nums2[j])
                    {
                        addItem = nums2[j];
                        break;
                    }
                }
                result.Add(addItem);
            }

            return result.ToArray();
        }

        // 589. N-ary Tree Preorder Traversal (Easy)
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root != null)
                Preorder(root, result);

            return result;
        }

        public void Preorder(Node root, List<int> result)
        {

            if (root != null)
            {
                result.Add(root.val);

                foreach (Node item in root.children)
                {
                    Preorder(item, result);
                }
            }
           
        }

        // 283. Move Zeroes (Easy)
        public void MoveZeroes(int[] nums)
        {
            int swapItem = 0;

            for (int curr = 0, lastNonZero = 0; curr < nums.Length; curr++)
            {
                if (nums[curr] != 0)
                {
                    swapItem = nums[lastNonZero];
                    nums[lastNonZero++] = nums[curr];
                    nums[curr] = swapItem;
                }
            }
        }

        // 1672. Richest Customer Wealth (Easy)
        public int MaximumWealth(int[][] accounts)
        {
            int result = int.MinValue;
            int wealth = 0;
            foreach (int [] customer in accounts)
            {
                wealth = 0;
                foreach (int account in customer)
                {
                    wealth += account;
                }
                result = Math.Max(wealth, result);
            }
            return result;
        }

        // 1588. Sum of All Odd Length Subarrays (Easy)
        public int SumOddLengthSubarrays(int[] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j += 2)
                {
                    for (int k = i; k <= j; k++)
                    {
                        result += arr[k];
                    }
                }
            }

            return result;
        }

        // 1572. Matrix Diagonal Sum (Easy)
        public static int DiagonalSum(int[][] mat)
        {
            int result = 0;
            Dictionary<KeyValuePair<int, int>, int> usedIndexes = new Dictionary<KeyValuePair<int, int>, int>();

            for (int i = 0, j = 0; i < mat.GetLength(0); i++, j++)
            {
                usedIndexes.Add(new KeyValuePair<int, int>(i, j), mat[i][j]);
            }

            for (int i = 0, j = mat.GetLength(0) - 1; i < mat.GetLength(0); i++, j--)
            {
                if (j < 0)
                    break;
                if (usedIndexes.Where(item => item.Key.Key == i && item.Key.Value == j).Count() == 0)
                {
                    usedIndexes.Add(new KeyValuePair<int, int>(i, j), mat[i][j]);
                }
            }

            foreach (KeyValuePair<KeyValuePair<int, int>, int> item in usedIndexes)
            {
                result += item.Value;
            }
            return result;

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
                for(int j = 0; j < c; j++)
                {
                    if(arrJ >= mat[arrI].Length)
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


        // 389. Find the Difference (Easy)
        public char FindTheDifference(string s, string t)
        {
            int result = 0;
            foreach (char item in t)
            {
                result += (int)item;
            }
            foreach (char item in s)
            {
                result = result - (int)item;
            }
            return (char)result;
        }

        // 1768. Merge Strings Alternately (Easy)
        public string MergeAlternately(string word1, string word2)
        {
            string result = "";
            int pointerWord1 = 0, pointerWord2 = 0;
            while (pointerWord1 < word1.Length && pointerWord2 < word2.Length)
            {
                result += word1[pointerWord1++];
                result += word2[pointerWord2++];
            }
            while (pointerWord1 < word1.Length)
            {
                result += word1[pointerWord1++];
            }
            while (pointerWord2 < word2.Length)
            {
                result += word2[pointerWord2++];
            }
            return result;
        }

        // 1678. Goal Parser Interpretation (Easy)
        public string Interpret(string command)
        {
            string result = "";

            for(int i =0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                    result += 'G';
                else if (command[i] == '(' && command[i + 1] == 'a')
                    result += "al";
                else if (command[i] == '(' && command[i + 1] == ')')
                    result += "o";
            }

            return result;
        }

        // 709. To Lower Case (Easy)
        public string ToLowerCase(string s)
        {
            string result = "";
            foreach (char item in s)
            {
                if (Char.IsUpper(item))
                    result += (char)((int)item + 32);
                else
                    result += item;
            }
            return result;
        }

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
        // 404. Sum of Left Leaves (Easy)
        public int SumOfLeftLeaves(TreeNode root)
        {
            int result = 0;

            SumOfLeftLeaves(root, ref result);

            return result;
        }
        public void SumOfLeftLeaves(TreeNode node, ref int result)
        {
            if (node != null)
            {
                if (node.left != null && node.left.left == null && node.left.right == null)
                {
                    result += node.left.val;
                }
                SumOfLeftLeaves(node.left, ref result);
                SumOfLeftLeaves(node.right, ref result);
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



        // 1309. Decrypt String from Alphabet to Integer Mapping (Easy)
        public string FreqAlphabets(string s)
        {
            Stack<string> cells = new Stack<string>();
            for(int i = s.Length -1; i >=0; i--)
            {
                if(s[i] != '#')
                {
                    cells.Push(s[i].ToString());
                }
                else
                {
                    cells.Push(s[i].ToString() + s[i - 2].ToString()+ s[i-1].ToString());
                    i = i - 2;
                }
            }
            Hashtable alphabet = new Hashtable();
            alphabet.Add("1", "a");
            alphabet.Add("2", "b");
            alphabet.Add("3", "c");
            alphabet.Add("4", "d");
            alphabet.Add("5", "e");
            alphabet.Add("6", "f");
            alphabet.Add("7", "g");
            alphabet.Add("8", "h");
            alphabet.Add("9", "i");
            alphabet.Add("#10", "j");
            alphabet.Add("#11", "k");
            alphabet.Add("#12", "l");
            alphabet.Add("#13", "m");
            alphabet.Add("#14", "n");
            alphabet.Add("#15", "o");
            alphabet.Add("#16", "p");
            alphabet.Add("#17", "q");
            alphabet.Add("#18", "r");
            alphabet.Add("#19", "s");
            alphabet.Add("#20", "t");
            alphabet.Add("#21", "u");
            alphabet.Add("#22", "v");
            alphabet.Add("#23", "w");
            alphabet.Add("#24", "x");
            alphabet.Add("#25", "y");
            alphabet.Add("#26", "z");

            string result = "";

            while (cells.Count != 0)
            {
                result += alphabet[cells.Pop()];    
            }

            return result;
        }

        // 953. Verifying an Alien Dictionary (Easy)
        public bool IsAlienSorted(string[] words, string order)
        {
            if (words.Length == 0)
                return true;
            Dictionary<char, int> sumDictionary = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                sumDictionary.Add(order[i], i);
            }

            for (int i = 1; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (j == words[i - 1].Length)
                        break;
                        
                    if (sumDictionary[words[i - 1][j]] < sumDictionary[words[i][j]])
                        break;
                    else if (sumDictionary[words[i - 1][j]] > sumDictionary[words[i][j]])
                        return false;
                    else
                    {
                        if (j == words[i].Length - 1 && words[i].Length < words[i - 1].Length)
                            return false;
                    }
                }
            }

            return true;
        }

        // 242. Valid Anagram (Easy)
        public bool IsAnagram(string s, string t)
        { 
            Dictionary<char, int> set = new Dictionary<char, int>();
            
            for(int i = 96; i < 123; i++)
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
            foreach(int item in set.Values)
            {
                if (item != 0)
                    return false;
            }
            return true;
        }

        // 876. Middle of the Linked List (Easy)
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

        // 303. Range Sum Query - Immutable (Easy)
        public class NumArray
        {
            int[] nums;

            public NumArray(int[] nums)
            {
                this.nums = nums;
            }

            public int SumRange(int left, int right)
            {
                int result = 0;
                for (int i = left; i <= right; i++)
                {
                    result += nums[i];
                }
                return result;
            }
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
                while(stackMain.Count() != 0)
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

        // 1603. Design Parking System (Easy)
        public class ParkingSystem
        {
            int big, medium, small;
            public ParkingSystem(int big, int medium, int small)
            {
                this.big = big;
                this.medium = medium;
                this.small = small;
            }

            public bool AddCar(int carType)
            {
                if (carType == 1)
                {
                    if (big != 0)
                    {
                        big -= 1;
                        return true;
                    }
                    else 
                        return false;
                }
                else if (carType == 2)
                {
                    if (medium != 0)
                    {
                        medium -= 1;
                        return true;
                    }
                    else
                        return false;
                }
                else if (carType == 3)
                {
                    if (small != 0)
                    {
                        small -= 1;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }

            }
        }


        // 1356. Sort Integers by The Number of 1 Bits (Easy)
        public int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, (num1, num2) => {
                int num1Bits = BitsCounter(num1);
                int num2Bits = BitsCounter(num2);
                if (num1Bits == num2Bits)
                    return num1.CompareTo(num2);
                else
                    return num1Bits.CompareTo(num2Bits);
            } );
            return arr;
        }
        public int BitsCounter(int number)
        {
            int counter = 0;
            while (number > 0)
            {
                if ((number & 1) != 0)
                {
                    counter++;
                }
                number = number >> 1;
            }
            return counter;
        }
    }
}
