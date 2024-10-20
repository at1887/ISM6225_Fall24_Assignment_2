using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Initialize a result list to store missing numbers
                List<int> result = new List<int>();
                // Use a HashSet to store unique elements from the array
                HashSet<int> set = new HashSet<int>(nums);
                // Check for missing numbers by iterating from 1 to the array length
                for (int i = 1; i <= nums.Length; i++) 
                {
                    if (!set.Contains(i))
                    {
                        result.Add(i);
                    }
                }
                return result; // Placeholder
              }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        // Question 2: Sort Array by Parity
         public static int[] SortArrayByParity(int[] A)
        {
            try
            {
                // Two-pointer approach to sort even numbers to the front
                int left = 0, right = A.Length - 1;
                // While pointers haven't crossed
                while (left < right)
                {
                    // Swap when left is odd and right is even
                    if (A[left] % 2 > A[right] % 2)
                    {
                        int temp = A[left];
                        A[left] = A[right];
                        A[right] = temp;
                    }
                     // Increment left if the current number is even
                    if (A[left] % 2 == 0) left++;
                    // Decrement right if the current number is odd
                    if (A[right] % 2 == 1) right--;
                }
                return A;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Use a dictionary to store the complement and index of each element
                Dictionary<int, int> map = new Dictionary<int, int>();
                // Loop through the array to check if complement exists
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    // If complement is found, return the indices
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    // Otherwise, store the current number and its index
                    map[nums[i]] = i;
                }
                return new int[0]; // No solution
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort the array to get the largest and smallest numbers easily
                Array.Sort(nums);
                int n = nums.Length;
                // Maximum product can be from either three largest or two smallest + largest
                return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 3] * nums[n - 2] * nums[n - 1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int num)
        {
            try
            {
                // If the number is zero, return "0"
                if (num == 0) return "0";
                // Initialize a string to store the binary result
                string binary = "";
                // Convert the decimal to binary by dividing by 2
                while (num > 0)
                {
                    binary = (num % 2) + binary;
                    num /= 2;
                }
                return binary;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        // Question 6: Find Minimum in Rotated Sorted Array
         public static int FindMin(int[] nums)
        {
            try
            {
                // Use binary search to find the minimum element
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    // If mid is greater than right, the minimum is to the right
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                // Return the minimum element found
                return nums[left];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0) return false;
                int original = x, reversed = 0;
                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit;
                    x /= 10;
                }
                // Check if the original number is equal to the reversed number
                return original == reversed;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }


        // Question 8: Fibonacci Number
        public static int Fibonacci(int N)
        {
            try
            {
                // Handle base cases for N=0 and N=1
                if (N == 0) return 0;
                if (N == 1) return 1;
                // Initialize variables for the Fibonacci sequence
                int a = 0, b = 1, sum = 0;
                // Loop to calculate the Fibonacci number
                for (int i = 2; i <= N; i++)
                {
                    sum = a + b;
                    a = b;
                    b = sum;
                }
                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
