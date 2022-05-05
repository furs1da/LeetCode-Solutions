using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            //int[][] nums1 = new int[][] { new int[4] { 4, 3, 2, -1 }, new int[4] { 3, 2, 1, -1 }, new int[4] { 1, 1, -1, -2 }, new int[4] { -1, -1, -2, -3 } };
            int[] nums1 = new int[] { 21, 47, 80, 4, 3, 24, 87, 12, 22, 11, 48, 6, 89, 80, 74, 71, 74, 55, 58, 56, 4, 98, 40, 66, 49, 53, 62, 27, 3, 66, 78, 24, 48, 69, 88, 12, 80, 63, 98, 65, 46, 35, 72, 5, 64, 72, 7, 29, 37, 3, 2, 75, 44, 93, 79, 78, 13, 39, 85, 26, 15, 41, 87, 47, 29, 93, 41, 74, 6, 48, 17, 89, 27, 61, 2, 68, 99, 57, 45, 73, 25, 33, 38, 32, 58 };
            int[] nums2 = new int[] { 1, 39, 6, 81, 85, 10, 38, 22, 0, 89, 57, 93, 58, 69, 65, 80, 84, 24, 27, 54, 37, 36, 26, 88, 2, 7, 24, 36, 51, 5, 74, 57, 45, 56, 55, 67, 25, 33, 78, 49, 16, 79, 74, 80, 36, 27, 89, 49, 64, 73, 96, 60, 92, 31, 98, 72, 22, 31, 0, 93, 70, 87, 80, 66, 75, 69, 81, 52, 94, 90, 51, 90, 74, 36, 58, 38, 50, 9, 64, 55, 4, 21, 49, 60, 65, 47, 67, 8, 38, 83 };
            int[] result = Intersect(nums1, nums2);
            
            foreach(int item in result)
            Console.WriteLine(item);
            
        }
        // 704. Binary Search (Easy)
        //public int Search(int[] nums, int target)
        //{
        //    int mid, left = 0, right = nums.Length - 1;
        //    while (left <= right)
        //    {
        //        mid = left + (right - left) / 2;
        //        if (nums[mid] == target)
        //        {
        //            return mid;
        //        }
        //        else if (nums[mid] < target)
        //            left = mid + 1;
        //        else
        //            right = mid - 1;
        //    }
        //    return -1;
        //}

        // 374. Guess Number Higher or Lower (Easy)
        public int GuessNumber(int n)
        {
            int low = 1;
            int high = n;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                //int result = this.guess(mid); API method
                //if (result == 0)
                //    return mid;
                //else if (result == -1)
                //    high = mid - 1;
                //else
                //    low = mid + 1;
            }
            return -1;
        }

        // 35. Search Insert Position (Easy)
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, mid = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }


        // 852. Peak Index in a Mountain Array (Easy)
        public int PeakIndexInMountainArray(int[] arr)
        {
            int left = 0, right = arr.Length - 1, mid;
            while (left < right)
            {
                mid = left + (right - left) / 2;
                if (arr[mid] < arr[mid + 1])
                    left = mid + 1;
                else
                    right = mid;
            }
            return left;
        }

        // 69. Sqrt(x) (Easy)
        public int MySqrt(int x)
        {
            int result = 0;
            long left = 0, right = x, mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (mid * mid == x)
                {
                    result = (int)mid;
                    break;
                }
                else if (mid * mid < x)
                {
                    result = (int)mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }

        // 33. Search in Rotated Sorted Array (Medium)
        public int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                {
                    if (nums[left] > nums[mid] && nums[right] < target)
                    {
                         right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                    
                }
                else
                {
                    if (nums[mid] > nums[right] && nums[left] > target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                    
                }
            }

            return -1;
        }

        // 162. Find Peak Element (Medium)
        public int FindPeakElement(int[] nums)
        {
            int mid, left = 0, right = nums.Length - 1;
            while (left < right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        //153. Find Minimum in Rotated Sorted Array (Medium)
        public int FindMin(int[] nums)
        {
            int result = int.MaxValue;
            int mid, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] < result)
                {
                    result = nums[mid];

                    if (nums[mid] < nums[right])
                    {
                        right = mid;    
                    }
                    else 
                    {
                        left = mid + 1;
                    }

                }
                else
                {
                    if (nums[mid] < nums[right])
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }          
                }
            }
            return result;
        }

        // 34. Find First and Last Position of Element in Sorted Array (Medium)
        public static int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[2] {-1, -1};
            int startIndex = -1, endIndex = -1;
            int mid, left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    endIndex = mid;
                    left = mid + 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (endIndex == -1)
                return result;
            left = 0;
            right = endIndex;
            
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    startIndex = mid;
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            result[0] = startIndex;
            result[1] = endIndex;

            return result;
        }

        // 658. Find K Closest Elements (Medium)
        public static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (k == arr.Length)
                return arr;
            else
            {
                List<int> result = new List<int>();
                int left = 0, right = arr.Length - 1, mid;
                while (left < right)
                {
                    mid = left + (right - left) / 2;
                    if (mid + k > arr.Length - 1)
                        right = mid;

                    else if (arr[mid + k] - x < x - arr[mid])
                        left = mid + 1;
                    else
                        right = mid;
                }

                for(int i = left; i < left + k; i++)
                {
                    result.Add(arr[i]);
                }
                return result;
            }
        }

        // 367. Valid Perfect Square (Easy)
        public bool IsPerfectSquare(int num)
        {
            long left = 0, right = num, mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (mid * mid == num)
                {
                    return true;
                }
                else if (mid * mid > (long)num)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return false;
        }

        // 1385. Find the Distance Value Between Two Arrays (Easy)
        public static int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            int result = 0;
            Array.Sort(arr2);
            int closestNumber = -10000000;
            foreach(int item in arr1)
            {
                int left = 0, right = arr2.Length - 1, mid;
                closestNumber = -1002;
                while (left + 1 < right)
                {
                    mid = left + (right - left) / 2;
                    if (arr2[mid] == item)
                    {
                        left = mid;
                        break;
                    }
                    else if (arr2[mid] < item)
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                if(Math.Abs(item - arr2[left]) < Math.Abs(item - arr2[right]))
                    closestNumber = arr2[left];
                else
                    closestNumber = arr2[right];



                if (Math.Abs(item - closestNumber) > d)
                {
                    result++;
                }
            }
            return result;
        }

        // 744. Find Smallest Letter Greater Than Target (Easy)
        public char NextGreatestLetter(char[] letters, char target)
        {
            int left = 0, right = letters.Length, mid;
            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (letters[mid] <= target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }

            }
            return letters[left % letters.Length];
        }

        // 441. Arranging Coins (Easy)
        public int ArrangeCoins(int n)
        {
            long counter = 0, curr;

            long left = 0, right = n;
            while (left <= right)
            {
                curr = left + (right - left) / 2;
                counter = curr * (curr + 1) / 2; // number of coins which we need for n-complete staircases

                if (counter == n) 
                    return (int)curr;

                if (n < counter)
                    right = curr - 1;
                else
                    left = curr + 1;
            }

            return (int)right;
        }

        // 1608. Special Array With X Elements Greater Than or Equal X (Easy)
        public static int SpecialArray(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            for (int i = 0; i <= nums.Length ; i++)
            {
                result = 0;
                int left = 0, right = nums.Length - 1, mid;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (nums[mid] >= i)
                    {
                       result = mid;
                       right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                if (nums[result] < i)
                    continue;
                result = nums.Length - result;
                
                if (result == i)
                    return i;
            }
            return -1;
        }

        // 1539. Kth Missing Positive Number (Easy)
        public static int FindKthPositive(int[] arr, int k)
        {
            int left = 0, right = arr.Length - 1, mid;
            int missing = 0;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                missing = arr[mid] - (mid + 1);
                if (missing >= k)
                    right = mid - 1;
                else
                    left = mid + 1;  
            }
            if (right == -1)
                return k;
            return arr[right] + k - (arr[right] - right - 1);
        }

        // 1351. Count Negative Numbers in a Sorted Matrix (Easy)
        public static int CountNegatives(int[][] grid)
        {
            int counter = 0;
            int left, right, mid;
            for(int i =0; i < grid.GetLength(0); i++)
            {
                left = 0; 
                right = grid[i].Length - 1;
                while (left < right)
                {
                    mid = left + (right - left) / 2;
                    if (grid[i][mid] >= 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                   
                }
                if (grid[i][right] < 0)
                    counter += grid[i].Length - right;
            }
            return counter;
        }

        // 350. Intersection of Two Arrays II (Easy)
        public static int[] Intersect(int[] nums1, int[] nums2)
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

        // 1346. Check If N and Its Double Exist (Easy)
        public bool CheckIfExist(int[] arr)
        {
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int left = 0, right = arr.Length - 1, mid;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (arr[i] * 2 == arr[mid] && i != mid)
                        return true;
                    else if (arr[i] * 2 >= arr[mid])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

            }

            return false;
        }

        // 633. Sum of Square Numbers (Medium)
        public bool JudgeSquareSum(int c)
        {
            for(long a =0; a * a <= c; a++)
            {
                int b = c - (int)(a * a);

                long left = 0, right = b, mid;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (mid * mid == b)
                    {
                        return true;
                    }
                    else if (mid * mid > b)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
            }
            return false;
        }

        // 1855. Maximum Distance Between a Pair of Values (Medium)
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            int result = 0;
            int left, right, mid;
            for (int i = 0; i < nums1.Length; i++)
            {
                left = i;
                right = nums2.Length - 1;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (i <= mid && nums1[i] <= nums2[mid])
                    {
                        result = Math.Max(result, mid - i);
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

            }



            return result;
        }

        // 167. Two Sum II - Input Array Is Sorted (Medium)
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int j = int.MinValue;
                int left = 0, right = nums.Length - 1, mid;

                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (target - nums[i] == nums[mid])
                    {
                        j = mid;
                        break;
                    }
                    else if (target - nums[i] > nums[mid])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (j != int.MinValue)
                    return new int[] { i + 1, j + 1 };
            }

            return new int[] { int.MinValue, int.MinValue };
        }
    }
}
