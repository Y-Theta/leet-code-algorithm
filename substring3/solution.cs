namespace leetcode.substring3
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            int[] map = Enumerable.Repeat(-1, 128).ToArray();
            int left = 0;
            int right = 0;
            for (int i = 0; i < s.Length; i++)
            {
                right++;
                var loc = map[s[i]];
                if (loc < left)
                {
                    max = Math.Max(max, right - left);
                }
                else
                {
                    left = map[s[i]] + 1;
                }
                map[s[i]] = i;
            }
            return max;
        }
    }
}