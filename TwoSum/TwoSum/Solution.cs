using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    internal class Solution
    {
        public int[] TwoSumBruteForce(int[] nums, int target)
        {

            for (int i=0; i < nums.Length; i++)
            {
                for (int j=i+1; j < nums.Length; i++) // Compare every pair
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { }; // Should never reach here as per problem constraints
        }
        public int[] TwoSumTwoPointers(int[] nums, int target)
        {
            var sortedNums = nums
                .Select((value, index) => new {Value = value, Index = index}) // Store original indices
                .OrderBy(x => x.Value)
                .ToArray();

            int left = 0;
            int right = sortedNums.Length - 1;

            while (left < right) 
            { 
                int sum = sortedNums[left].Value + sortedNums[right].Value;
                if (sum == target)
                {
                    return new int[] { sortedNums[left].Index, sortedNums[right].Index };
                } else if (sum < target)
                {
                    left++;
                } else
                {
                    right--;
                }
            }

            return new int[] { }; // Should never reach here
        }

        public int[] TwoSumHashMap(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>(); // Stores number -> index

            for (int i=0; i<nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numMap.ContainsKey(complement)) // If complement exists, return indices
                {  
                    return new int[] { numMap[complement], i };
                }

                numMap[nums[i]] = i; // Store current number with its index
            }

            return new int[] { }; // Should never reach here
        }

    }

  
}
