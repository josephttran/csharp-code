/*
Given an array of integers, return indices of the two numbers
such that they add up to a specific target.
You may assume that each input would have exactly one solution, 
and you may not use the same element twice.
*/

using System;

namespace Algorithm.Services
{
	public class TwoSum
	{
		public int[] DoTwoSum(int[] nums, int target) 
		{
			for (int i = 0; i < nums.Length; i++)
			{
				for (int j = i + 1; j < nums.Length; j++)
				{
					if (nums[i] + nums[j] == target)
					{
						return new int[] {i, j};
					}
				}
			}
			throw new ArgumentException("No two sum solution");
		}
	}
}
