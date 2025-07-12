namespace leetcode.candy135
{
    public class Solution
    {
        public int Candy2(int[] ratings)
        {
            if (ratings is null || ratings.Length == 0)
                return 0;

            Dictionary<int, List<int>> posrat = new Dictionary<int, List<int>>();
            for (int i = 0; i < ratings.Length; i++)
            {
                if (posrat.TryGetValue(ratings[i], out var list))
                {
                    list.Add(i);
                }
                else
                {
                    posrat[ratings[i]] = new List<int> { i };
                }
            }

            var candies = new int[ratings.Length];
            var poslist = posrat.OrderBy(p => p.Key).ToList();
            for (int index = 0; index < poslist.Count; index++)
            {
                var pos = poslist[index];
                bool top = index == posrat.Count - 1;
                foreach (var item in pos.Value)
                {
                    var mecandy = candies[item];

                    if (item > 0)
                    {
                        var left = ratings[item - 1];
                        var leftcandy = candies[item - 1];
                        if (left > pos.Key && leftcandy <= mecandy)
                        {
                            candies[item - 1] = mecandy + 1;
                        }
                    }

                    if (item < ratings.Length - 1)
                    {
                        var right = ratings[item + 1];
                        var rightcandy = candies[item + 1];
                        if (right > pos.Key && rightcandy <= mecandy)
                        {
                            candies[item + 1] = mecandy + 1;
                        }
                    }
                }
            }

            return candies.Sum() + candies.Length;
        }

        public int Candy(int[] ratings)
        {
            if (ratings is null || ratings.Length == 0)
                return 0;

            int l = ratings.Length;
            int sum = 1;
            int downcount = 0;
            int pre = 1;
            int tempmax = 0;

            for (int i = 1; i < l; i++)
            {
                int current = 1;
                var des = ratings[i] - ratings[i - 1];
                if (des >= 0)
                {
                    downcount = 0;
                    if (des == 0)
                    {
                        sum += current;
                        pre = current;
                        tempmax = 0;
                        continue;
                    }
                    current = pre + 1;
                }
                else
                {
                    if (pre > 1)
                    {
                        tempmax = pre;
                    }

                    if (pre <= current)
                    {
                        downcount++;
                        sum += downcount;
                        if (tempmax > 1 && downcount + 1 >= tempmax)
                        {
                            sum += 1;
                        }
                    }
                }
                pre = current;
                sum += current;
            }

            return sum;
        }
    }
}
