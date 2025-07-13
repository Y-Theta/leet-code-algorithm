using System.ComponentModel.DataAnnotations;

namespace leetcode.lcp14
{

    public class Solution
    {
        public bool HCF(int a, int b)
        {
            int large = Math.Max(a, b);
            int small = Math.Min(a, b);
            int temp = large % small;
            if (temp == 0)
                return true;
            if (temp == 1)
                return false;
            var nextsmall = temp;
            while (temp > 0)
            {
                if (small < temp)
                    return false;
                temp = small % temp;
                if (temp == 1)
                    return false;
                if (temp == 0)
                    return true;
                small = nextsmall;
                nextsmall = temp;
            }

            return false;
        }

        List<int>[] primes = Enumerable.Range(0, 1000001).Select(i => new List<int>()).ToArray();
        public bool IsPrime(int prime)
        {
            int start = (int)Math.Floor(Math.Sqrt(prime));
            for (int i = 2; i <= start; i++)
            {
                if (prime % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public void FillPrimesList(List<int>[] list)
        {
            list[0] = list[1] = new List<int> { 1 };
            for (int i = 2; i < list.Length; i++)
            {
                if (IsPrime(i))
                {
                    for (int j = 1; i * j < list.Length; j++)
                    {
                        list[i * j].Add(i);
                    }
                }
            }
        }

        public List<int> GetFactors(int num)
        {
            return primes[num];
        }

        // 定义函数 f(i) = Math.Min(f(i-1) + 1, ) 
        int[] results;
        public int SplitArray(int[] nums)
        {
            FillPrimesList(primes);
            results = new int[nums.Length];
            results[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                results[i] = GetPrevious(nums, i, results);
            }
            return results[nums.Length - 1];
        }

        private int GetPrevious(int[] nums, int current, int[] cachedResults)
        {
            int min = cachedResults[current - 1] + 1;
            HashSet<int> currentfactor = new HashSet<int>(GetFactors(nums[current]));
            for (int i = current - 1; i >= 0; i--)
            {
                var numfactor = GetFactors(nums[i]);
                if (currentfactor.Intersect(numfactor).Count() > 0)
                {
                    if (i == 0)
                    {
                        min = 1;
                    }
                    else
                    {
                        min = Math.Min(min, cachedResults[i - 1] + 1);
                    }
                }
            }
            return min;
        }

        public int SplitArray(int[] nums, int start, int end)
        {
            if (start == end)
                return 1;
            if (end - start == 1)
                return HCF(nums[start], nums[end]) ? 1 : 2;
            if (nums is null || nums.Length == 0)
                return 0;
            var len = end - start;
            if (len > nums.Length - 1)
                return 0;

            int sublen = len;
            bool find = false;
            while (sublen > 0)
            {
                int newstart = start;
                int newend = end;
                for (int i = start; i < end; i++)
                {
                    int tempend = i + sublen;
                    if (tempend > end)
                        break;
                    find = HCF(nums[i], nums[tempend]);
                    if (find)
                    {
                        newstart = i;
                        newend = tempend;
                        break;
                    }
                }
                if (find)
                {
                    int left = 0;
                    int right = 0;
                    if (start == newstart - 1)
                    {
                        left = 1;
                    }
                    else if (start != newstart)
                    {
                        left = SplitArray(nums, start, newstart - 1);
                    }

                    if (newend + 1 == end)
                    {
                        right = 1;
                    }
                    else if (newend != end)
                    {
                        right = SplitArray(nums, newend + 1, end);
                    }
                    return right + left + 1;
                }
                sublen--;
            }

            return end - start + 1;
        }
    }


}
