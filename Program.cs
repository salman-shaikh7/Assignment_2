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
                // Create a HashSet to store unique numbers from the array
                HashSet<int> numberSet = new HashSet<int>(nums);
                List<int> missingNumbers = new List<int>();

                // Identify missing numbers from 1 to the length of the array
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!numberSet.Contains(i))
                    {
                        missingNumbers.Add(i); // Add missing number to the list
                    }
                }
                return missingNumbers; // Return the list of missing numbers
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int[] outputArray = new int[nums.Length];
                int evenPosition = 0; // Index for placing even numbers
                int oddPosition = nums.Length - 1; // Index for placing odd numbers

                // Distribute even and odd numbers
                foreach (var number in nums)
                {
                    if (number % 2 == 0) // If the number is even
                    {
                        outputArray[evenPosition++] = number; // Place it at the current even index
                    }
                    else // If the number is odd
                    {
                        outputArray[oddPosition--] = number; // Place it at the current odd index
                    }
                }
                return outputArray; // Return the rearranged array
            }

            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Create a dictionary to keep track of numbers and their indices
                Dictionary<int, int> indexMap = new Dictionary<int, int>();

                // Iterate through the array to find the two numbers
                for (int i = 0; i < nums.Length; i++)
                {
                    int difference = target - nums[i]; // Calculate the needed complement
                    if (indexMap.ContainsKey(difference)) // Check if the complement is already in the dictionary
                    {
                        return new int[] { indexMap[difference], i }; // Return the indices of the two numbers
                    }
                    indexMap[nums[i]] = i; // Add the current number and its index to the dictionary
                }
                return new int[0]; // Return empty array if no solution found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array to access largest/smallest values easily
                int arrayLength = nums.Length; // Get the length of the array
                
                // Calculate the maximum product using the three largest numbers or two smallest and the largest
                return Math.Max(nums[arrayLength - 1] * nums[arrayLength - 2] * nums[arrayLength - 3],
                                nums[0] * nums[1] * nums[arrayLength - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Use built-in conversion to get the binary representation
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int leftIndex = 0, rightIndex = nums.Length - 1; // Set up pointers for binary search
                
                // Apply binary search to find the minimum element
                while (leftIndex < rightIndex)
                {
                    int midIndex = leftIndex + (rightIndex - leftIndex) / 2; // Calculate middle index
                    if (nums[midIndex] > nums[rightIndex]) // If mid value is greater than the rightmost value
                    {
                        leftIndex = midIndex + 1; // Move left pointer to mid + 1
                    }
                    else // Otherwise, the minimum is in the left half (including mid)
                    {
                        rightIndex = midIndex; 
                    }
                }
                return nums[leftIndex]; // Return the found minimum value
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
            if (x < 0) return false; // Negative numbers cannot be palindromes
            int reversedNumber = 0; // Variable to hold the reversed number
            int originalNumber = x ; // Store the original number for comparison

            // Reverse the number
            while (x  > 0)
            {
                reversedNumber = reversedNumber * 10 + x  % 10; // Build the reversed number
                x  /= 10; // Remove the last digit
            }
            return originalNumber == reversedNumber; // Compare original and reversed numbers
            }

            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {   

                if (n < 0 || n > 30)
                {
                    throw new ArgumentOutOfRangeException("n", "Input must be between 0 and 30 inclusive.");
                }

                if (n <= 1) return n; // Return n for base cases (0 or 1)
                int first = 0, second = 1, fibNumber = 0; // Initialize the first two Fibonacci numbers

                // Compute the Fibonacci number iteratively
                for (int i = 2; i <= n; i++)
                {
                    fibNumber = first + second; // Get the next Fibonacci number
                    first = second; // Update first to the previous second
                    second = fibNumber; // Update second to the new Fibonacci number
                }
                return fibNumber; // Return the Fibonacci number at index n
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}