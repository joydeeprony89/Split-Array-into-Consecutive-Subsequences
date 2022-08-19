using System;
using System.Collections.Generic;

namespace Split_Array_into_Consecutive_Subsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 1, 2, 3, 3, 4, 4, 5, 5 };
            Solution s = new Solution();
            var answer = s.IsPossible(nums);
            Console.WriteLine(answer);
        }
    }

    // https://www.youtube.com/watch?v=uJ8BAQ8lASE

    public class Solution
    {
        public bool IsPossible(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            var appendfreq = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (!freq.ContainsKey(i)) freq.Add(i, 0);
                freq[i]++;
            }

            foreach (int i in nums)
            {
                if (!freq.ContainsKey(i) || freq[i] == 0) continue;
                else if (appendfreq.ContainsKey(i) && appendfreq[i] > 0)
                {
                    appendfreq[i]--;
                    if (!appendfreq.ContainsKey(i + 1)) appendfreq.Add(i + 1, 0);
                    appendfreq[i + 1]++;
                }
                else if (freq.ContainsKey(i + 1) && freq[i + 1] > 0 && freq.ContainsKey(i + 2) && freq[i + 2] > 0)
                {
                    freq[i + 1]--;
                    freq[i + 2]--;
                    if (!appendfreq.ContainsKey(i + 3)) appendfreq.Add(i + 3, 0);
                    appendfreq[i + 3]++;
                }
                else return false;
                freq[i]--;
            }
            return true;
        }
    }
}
