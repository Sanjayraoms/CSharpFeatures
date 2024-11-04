using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Solution
    {

        public bool CanBeEqual(int[] target, int[] arr)
        {
            Dictionary<int, int> ctr = new Dictionary<int, int>();
            for (int i = 0; i < target.Length; i++)
            {
                ctr[target[i]] = ctr[target[i]] + 1;
            }
            for (int j = 0; j < arr.Length; j++)
            {
                if (ctr.ContainsKey(arr[j]))
                {
                    ctr[arr[j]]--;
                    if (ctr[arr[j]] == 0)
                        ctr.Remove(arr[j]);
                }
                else
                    return false;
            }
            return true;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            string firstStr = strs[0];
            string secondStr = strs[1];
            string strToCompare = "";
            StringBuilder commonPrefix = new StringBuilder("");
            StringBuilder str2ToCompare = new StringBuilder("");
            for (int i = 0; i < Math.Min(firstStr.Length, secondStr.Length); i++)
            {
                if (firstStr[i] == secondStr[i])
                    commonPrefix.Append(firstStr[i]);
                else
                    break;
            }
            if (commonPrefix.ToString() == "")
                return "";
            else
            {
                for (int i = 2; i < strs.Length; i++)
                {
                    strToCompare = commonPrefix.ToString();
                    str2ToCompare.Clear();
                    str2ToCompare.Append(strs[i]);
                    commonPrefix.Clear();
                    for (int j = 0; j < Math.Min(strToCompare.Length, str2ToCompare.Length); j++)
                    {
                        if (strToCompare[j] == str2ToCompare[j])
                            commonPrefix.Append(strToCompare[j]);
                        else
                            break;
                    }
                    if (commonPrefix.ToString() == "")
                        return "";
                }
            }
            return commonPrefix.ToString();
        }

        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            IList<int> list;
            IList<IList<int>> results = new List<IList<int>>();
            Dictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
            foreach (int[] edge in edges)
            {
                if (map.TryGetValue(edge[1],out list))
                {
                    list.Add(edge[0]);
                }
                else
                {
                    list = new List<int>();
                    list.Add(edge[0]);
                    map.Add(edge[1], list);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (map.TryGetValue(i, out list))
                {
                    results.Add(list);
                }
                else
                {
                    results.Add(new List<int>());
                }
            }
            return results;
        }
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            int num = 0;
            List<int> intersection = new List<int>();
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (int item in nums1)
            {
                if (frequency.TryGetValue(item, out num))
                {
                    frequency[item] = num + 1;
                }
                else
                {
                    frequency.Add(item, 1);
                }
            }
            foreach (int item in nums2)
            {
                if (frequency.TryGetValue(item, out num))
                {
                    frequency[item] = num - 1;
                    intersection.Add(item);
                    num--;
                    if (num == 0)
                    {
                        frequency.Remove(item);
                    }
                }
            }
            return intersection.ToArray();
        }

        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            Dictionary<int, TreeNode> DictNodes = new Dictionary<int, TreeNode>();
            HashSet<int> children = new HashSet<int>();
            foreach (int[] description in descriptions)
            {
                int parent = description[0];
                int child = description[1];
                bool isLeft = (description[2] == 1);
                if (!DictNodes.ContainsKey(parent))
                {
                    DictNodes.Add(parent, new TreeNode(parent));
                }
                var parentNode = DictNodes[parent];
                if (!DictNodes.ContainsKey(child))
                {
                    DictNodes.Add(child, new TreeNode(child));
                }
                var childNode = DictNodes[child];
                if (isLeft)
                {
                    parentNode.left = childNode;
                }
                else
                {
                    parentNode.right = childNode;
                }
                children.Add(child);
            }
            foreach (var item in children)
            {
                if (!DictNodes.ContainsKey(item))
                {
                    return DictNodes[item];
                }
            }
            return null;
        }

        public int MinimumPushes(string word)
        {
            Dictionary<char, int> charfreq = new Dictionary<char, int>();
            Dictionary<char, int> keymaps = new Dictionary<char, int>();
            int keyStrokes = 1;
            int keyctr = 0;
            int totalStrokes = 0;

            foreach (char item in word)
            {
                if (!charfreq.ContainsKey(item))
                    charfreq[item] = 1;
                else
                    charfreq[item]++;
            }
            var keyValuePairs = charfreq.OrderBy(key => key.Value).ToList();

            foreach (KeyValuePair<char, int> item in keyValuePairs)
            {
                if (keyctr == 8)
                {
                    keyStrokes++;
                    keyctr = 0;
                }
                if (!keymaps.ContainsKey(item.Key))
                {
                    keymaps[item.Key] = keyStrokes;
                    keyctr++;
                }
            }

            foreach (char item in word)
                totalStrokes += keymaps[item];

            return totalStrokes;
        }
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length > t.Length)
                return false;
            int i = 0;
            int j = 0;
            while (i < s.Length && j < t.Length)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j++;
                    if (i == s.Length)
                        return true;
                }
                else
                    j++;
            }
            return false;
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int top = 0;
            int bottom = matrix.Length - 1;
            int right = matrix.Length - 1;
            int left = 0;
            int dir = 0;
            List<int> spiralVal = new List<int>();
            while (top <= bottom && left <= right)
            {
                if (dir == 0)
                {
                    for (int i = left; i <= right; i++)
                        spiralVal.Add(matrix[left][i]);
                    top += 1;
                }
                else if (dir == 1)
                {
                    for (int i = top; i <= bottom; i++)
                        spiralVal.Add(matrix[i][bottom]);
                    right -= 1;
                }
                else if (dir == 2)
                {
                    for (int i = right; i >= left; i--)
                        spiralVal.Add(matrix[bottom][i]);
                    bottom -= 1;
                }
                else if (dir == 3)
                {
                    for (int i = bottom; i >= top; i--)
                        spiralVal.Add(matrix[i][left]);
                    left += 1;
                }
                dir = (dir + 1) % 4;
            }
            return spiralVal;
        }
        public string RemoveStars(string s)
        {
            Stack<char> st = new Stack<char>();
            Stack<char> res = new Stack<char>();
            int stars = 0;
            foreach (char c in s)
            {
                st.Push(c);
            }
            while (st.Count > 0)
            {
                if (st.Peek() == '*')
                {
                    stars++;
                    st.Pop();
                }
                else
                {
                    if (stars > 0)
                    {
                        st.Pop();
                        stars--;
                    }
                    else
                        res.Push(st.Pop());
                }

            }
            if (res.Count > 0)
            {
                return new String(res.ToArray());
            }
            return "";
        }
        public bool IncreasingTriplet(int[] nums)
        {
            int i = 0;
            int j = 1;
            int k = 2;
            while (k < nums.Length)
            {
                if ((nums[i] < nums[j]) && (nums[j] < nums[k]))
                    return true;
                if (nums[i] < nums[j] && (nums[j] > nums[k] && nums[i] >= nums[k]))
                {
                    if (k + 1 < nums.Length && nums[j] < nums[k + 1])
                        return true;
                    else
                    {
                        i = k;
                        j = k + 1;
                        k = k + 2;
                    }
                }
                if (nums[i] < nums[j] && nums[j] > nums[k])
                {
                    j++;
                    k++;
                }
                else
                {
                    i++;
                    j++;
                    k++;
                }
            }
            return false;
        }

        public double FindMaxAverage(int[] nums, int k)
        {
            double MaxAverage;
            double Average;
            double sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += nums[i];
            }
            MaxAverage = (double)(sum / k);
            for (int i = 0; i < nums.Length - k; i++)
            {
                sum = sum - nums[i] + nums[i + k ];
                Average = (double)(sum / k);
                MaxAverage = Math.Max(MaxAverage, Average);
            }
            return MaxAverage;
        }

        //public int MaxVowels(string s, int k)
        //{
        //    int maxVowels = 0;
        //    int tempK = k;
        //    int start = 0;
        //    int tempCnt = 0;
        //    int prevVowelStart = 0;
        //    while (start <= s.Length - 1)
        //    {
        //        if (s[start] == 'a' || s[start] == 'e' || s[start] == 'i' || s[start] == 'o' || s[start] == 'u')
        //        {
        //            if (tempCnt == 1)
        //                prevVowelStart = start;
        //            tempCnt++;
        //            maxVowels = Math.Max(maxVowels, tempCnt);
        //            if (maxVowels == k)
        //                break;
        //        }
        //        tempK--;
        //        start++;
        //        if (tempK == 0)
        //        {
        //            tempK = k;
        //            if (prevVowelStart > 0)
        //                start = prevVowelStart;
        //            prevVowelStart = 0;
        //            tempCnt = 0;
        //        }
        //    }
        //    return maxVowels;
        //}
        //public int MaxVowels(string s, int k)
        //{
        //    int maxVowels = 0;
        //    int tempK = k;
        //    int start = 0;
        //    int tempCnt = 0;
        //    while (start < s.Length - 1)
        //    {
        //        if (s[start] == 'a' || s[start] == 'e' || s[start] == 'i' || s[start] == 'o' || s[start] == 'u')
        //        {
        //            tempCnt++;
        //            maxVowels = Math.Max(maxVowels, tempCnt);
        //            if (maxVowels == 3)
        //                break;
        //        }
        //        tempK--;
        //        start++;
        //        if (tempK == 0)
        //        {
        //            tempK = k;
        //            start = start - tempCnt;
        //            tempCnt = 0;
        //        }
        //    }
        //    return maxVowels;
        //}

        public int MaxVowels(string s, int k)
        {
            int maxVowels = 0;
            int tempK = k;
            int start = 0;
            int tempCnt = 0;
            int prevVowelStart = 0;
            while (start <= s.Length - 1)
            {
                if (s[start] == 'a' || s[start] == 'e' || s[start] == 'i' || s[start] == 'o' || s[start] == 'u')
                {
                    if (tempCnt == 1)
                        prevVowelStart = start;
                    tempCnt++;
                    maxVowels = Math.Max(maxVowels, tempCnt);
                    if (maxVowels == k)
                        break;
                }
                tempK--;
                if (tempK == 0)
                {
                    tempK = k;
                    if (prevVowelStart > 0)
                        start = prevVowelStart - 1;
                    else if (prevVowelStart == 0 && tempCnt == 1)
                        start = start - 2;
                    prevVowelStart = 0;
                    tempCnt = 0;
                }
                start++;
            }
            return maxVowels;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] res = new int[2];
            int diff = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                diff = target - (nums[i]);
                if (map.ContainsKey(diff))
                    return new int[] { i, map[diff] };
                if (!map.ContainsKey(i))
                    map[nums[i]] = i;
            }
            return res;
        }
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> astStack = new Stack<int>();
            int len = asteroids.Length - 1;
            astStack.Push(asteroids[len]);
            for (int i = len - 1; i >= 0; i--)
            {
                if (astStack.Count > 0)
                {
                    var curast = astStack.Peek();
                    if (curast < 0 && asteroids[i] > 0)
                    {
                        if (Math.Abs(curast) > Math.Abs(asteroids[i]))
                        {
                            continue;
                        }
                        else if (Math.Abs(asteroids[i]) > Math.Abs(curast))
                        {
                            astStack.Pop();
                            astStack.Push(asteroids[i]);
                        }
                        else
                            astStack.Pop();
                    }
                    else
                        astStack.Push(asteroids[i]);
                }
                else
                    astStack.Push(asteroids[i]);
            }
            return astStack.ToArray();
        }

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var l1 = new List<int>();
            var l2 = new List<int>();
            void Traverse(TreeNode node, List<int> list)
            {
                if (node.left != null) Traverse(node.left, list);
                if (node.right != null) Traverse(node.right, list);
                if (node.right == null && node.left == null)
                    list.Add(node.val); 
            }
            Traverse(root1, l1);
            Traverse(root2, l2);
            if (l1.Count != l2.Count)
                return false;
            else
            {
                for (int i = 0; i < l1.Count; i++)
                {
                    if (l1[i] != l2[i])
                        return false;
                }
            }
            return true;
        }

        public int RemoveDuplicates(int[] nums)
        {
            int k = 0;
            int j = 1;
            int prev = nums[k];
            while (j < nums.Length)
            {
                if (nums[k] != nums[j])
                {
                    if (nums[j] != prev)
                    {
                        k++;
                        nums[k] = nums[j];
                    }
                    j++;
                    prev = nums[k];
                }
                else
                {
                    j++;
                }
            }
            return k;
        }

        public int PivotIndex(int[] nums)
        {
            int[] prefixSum = new int[nums.Length];
            int[] suffixSum = new int[nums.Length];

            prefixSum[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                prefixSum[i] = prefixSum[i] + prefixSum[i - 1];
            }

            suffixSum[suffixSum.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                suffixSum[i] = suffixSum[i] + suffixSum[i + 1];
            }

            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (prefixSum[i - 1] == suffixSum[i + 1])
                    return i;
            }
            return -1;
        }

        int suffixCnt;
        int prefixCnt;
        public bool AreSentencesSimilar(string sentence1, string sentence2)
        {
            var sen1 = sentence1.Split(" ");
            var sen2 = sentence2.Split(" ");
            prefixCnt = 0;
            string newStr;
            for (int i = 0; i < Math.Min(sen1.Length, sen2.Length); i++)
            {
                if (sen1[i] == sen2[i])
                    prefixCnt++;
                else
                    break;
            }
            if (prefixCnt == Math.Min(sen1.Length, sen2.Length))
                return true;
            if (sen1.Length >= sen2.Length)
            {
                suffixCnt = getSuffixCnt(sen1, sen2);
                newStr = buildString(sen1);
                if (newStr.Trim() == sentence2)
                    return true;
            }
            else
            {
                suffixCnt = getSuffixCnt(sen2, sen1);
                newStr = buildString(sen2);
                if (newStr.Trim() == sentence1)
                    return true;
            }
            return false;
        }

        private int getSuffixCnt(string[] big, string[] small)
        {
            suffixCnt = 0;
            int i = big.Length - 1;
            int j = small.Length - 1;
            for (int k = i; j >= 0; k--)
            {
                if (big[k] == small[j])
                    suffixCnt++;
                else
                    break;
                j--;
            }
            return suffixCnt;
        }
        private string buildString(string[] str)
        {
            StringBuilder sb = new StringBuilder("");
            int i = 0;
            if (i < prefixCnt)
            {
                sb.Append($"{str[i]} ");
            }
            i = str.Length - suffixCnt;
            if (i < str.Length)
            {
                sb.Append($"{str[i]} ");
            }
            return sb.ToString();
        }

        public int[] FindXSum(int[] nums, int k, int x)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            if (x > nums.Length)
            {
                var sum = nums.Sum();
                return new int[] { sum };
            }
            var res = new int[nums.Length - k + 1];
            int i = 0;
            int j = k - 1;
            while (i < res.Length)
            {
                dict.Clear();
                var l = x;
                for (int m = i; m < j; m++)
                {
                    if (dict.ContainsKey(nums[m]))
                    {
                        dict[nums[m]]++;
                    }
                    else
                        dict[nums[m]] = 1;
                }
                var sorted = dict.OrderByDescending(x => x.Value)
                                 .ThenByDescending(x => x.Key).ToDictionary(x => x.Key, x => x.Value).Take(l);
                foreach (KeyValuePair<int, int> key in sorted)
                {
                    res[i] = res[i] + key.Key * key.Value;
                }
                i++;
                j++;
            }
            return res;
        }

        public int NumberOfSubstrings(string s, int k)
        {
            int cntr = 0;
            int i = 0;
            int j = k - 1;
            Dictionary<char, int> freq = new Dictionary<char, int>();
            for (int l = i; l <= j; l++)
            {
                if (freq.ContainsKey(s[l]))
                {
                    freq[s[l]]++;
                }
                else
                {
                    freq[s[l]] = 1;
                }
            }
            while (true)
            {
                foreach (char key in freq.Keys)
                {
                    if (freq[key] >= k)
                    {
                        cntr++;
                        break;
                    }
                }
                if (j < s.Length - 1)
                {
                    j++;
                    if (freq.ContainsKey(s[j]))
                    {
                        freq[s[j]]++;
                    }
                    else
                    {
                        freq[s[j]] = 1;
                    }
                }
                else if (i < s.Length)
                {
                    i++;
                    freq[s[i - 1]]--;
                }
                else
                    break;
            }
            return cntr;
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
                return s;
            String resStr = "";
            int maxLen = 0;
            int longStr = 0;
            int left, right;
            for (int i = 0; i < s.Length; i++)
            {
                longStr = 0;
                left = i;
                right = i;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    longStr = right - left + 1;
                    left--;
                    right++;
                }
                if (resStr.Length < longStr)
                {
                    resStr = s.Substring(left + 1, right);
                }

                longStr = 0;
                left = i;
                right = i + 1;
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    longStr = right - left + 1;
                    left--;
                    right++;
                }
                if (resStr.Length < longStr)
                {
                    resStr = s.Substring(left + 1, right);
                }
            }
            return resStr;
        }

        public string getPalindrome(int n, int k)
        {
            StringBuilder sb = new StringBuilder();
            char c = Convert.ToChar(97);
            if(n%2 == 1)
            {
                sb.Append(c);
                n--;
            }
            else
            {
                sb.Append($"{c}{c}");
                n = n - 2;
            }
            k--;
            while(n > 0)
            {
                if(k >= 1)
                {
                    c = Convert.ToChar(Convert.ToInt16(c) + 1);
                    k--;
                }
                sb.Append(c);
                sb.Insert(0, c);
                n = n - 2;
            }
            return sb.ToString();
        }

        public int removeChars(string s)
        {
            int count = 0;
            int? prevVal = null;
            List<int> values = new List<int>();
            Dictionary<char, int> keyValues = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (keyValues.ContainsKey(c))
                    keyValues[c]++;
                else
                    keyValues[c] = 1;
            }
            foreach (int val in keyValues.Values)
            {
                values.Add(val);
            }
            values.Sort();
            for(int i = 0; i < values.Count - 1; i++)
            {
                if (values[i] == values[i + 1])
                {
                    values[i]--;
                    count++;
                    if(prevVal != null)
                    {
                        if(values[i] == prevVal)
                        {
                            count = count + values[i];
                            values[i] = 0;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                if (values[i] != 0)
                    prevVal = values[i];
            }
            return count;
        }

        public int returnSmall(int n)
        {
            StringBuilder sb = new StringBuilder();
            while (n > 0)
            {
                if(n > 9)
                {
                    sb.Append("9");
                    n = n - 9;
                }
                else
                {
                    sb.Append(n);
                    n = 0;
                }
            }
            if(sb.Length > 1)
            {
                (sb[0], sb[sb.Length - 1]) = (sb[sb.Length - 1], sb[0]);
            }
            return Convert.ToInt32(sb.ToString());
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
       public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
         this.val = val;
         this.left = left;
         this.right = right;
        }

    }

    public class SmallestInfiniteSet
    {
        List<int> poppedValues;
        PriorityQueue<int, int> q;
        int prevsmallest = 0;
        public SmallestInfiniteSet()
        {
            prevsmallest++;
            q = new PriorityQueue<int, int>();
            q.Enqueue(prevsmallest, prevsmallest);
            poppedValues = new List<int>();
        }

        public int PopSmallest()
        {
            var currsmallest = q.Dequeue();
            poppedValues.Add(currsmallest);
            prevsmallest++;
            q.Enqueue(prevsmallest, prevsmallest);
            return currsmallest;
        }

        public void AddBack(int num)
        {
            if (poppedValues.Contains(num))
            {
                q.Enqueue(num, num);
                poppedValues.Remove(num);
            }
        }
    }




}
