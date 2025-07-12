namespace leetcode.lcp14
{
    public class Solution
    {
        public bool IsMatch(int a, int b)
        {
            int large = Math.Max(a, b);
            int small = Math.Min(a, b);
            int temp = large % small;
            if (temp == 0)
                return true;
            var nextsmall = temp;
            while (temp > 0)
            {
                if (small < temp)
                    return false;
                temp = small % temp;
                if (temp == 0)
                    return true;
                small = nextsmall;
            }

            return false;
        }

        public int SplitArray(int[] nums)
        {

            return 0;
        }
    }
}
