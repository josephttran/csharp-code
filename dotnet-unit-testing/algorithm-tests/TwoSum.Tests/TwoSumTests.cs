using Xunit;
using Algorithm.Services;

namespace AlgorithmServiceTests
{
    public class AlgorithmTwoSum
    {
		private readonly TwoSum _TwoSum;
		
		public AlgorithmTwoSum()
		{
			_TwoSum = new TwoSum();
		}
        
		[Fact]
        public void DoTwoSumPass()
        {
			int[] nums = {0, 4, 5, 2, 13, 22};
			int target = 15;
			
			int[] expected = {3, 4};
			int[] result = _TwoSum.DoTwoSum(nums, target);
			
			Assert.Equal(result, expected);
        }
    }
}
