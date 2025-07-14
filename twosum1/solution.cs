namespace leetcode.tosum1
{
    public class Solution
    {
        Dictionary<int, int> targetdic = new Dictionary<int, int>();
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                if (targetdic.TryGetValue(current, out var pos))
                {
                    return [pos, i];
                }
                targetdic[target - current] = i;
            }

            return new int[0];
        }
    }
}