using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Leetcode.dp
{
    class _472
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            Array.Sort(words, (x, y) => x.Length - y.Length);

            var result = new List<string>();
            var dictionary = new HashSet<string>();

            int i = 0;
            foreach (var word in words)
            {
                if (WordBreak(word, dictionary))
                    result.Add(word);

                dictionary.Add(words[i]);
                ++i;
            }
            return result;
        }

        public bool WordBreak(string word, IEnumerable<string> dic)
        {
            var dp = new bool[word.Length];
            return WordBreak();

            bool WordBreak(int curentIdx = 0)
            {
                if (word.Length == 0)
                    return dic.Any(x => x.Length == 0);

                if (curentIdx == word.Length)
                    return true;

                for (int i = curentIdx + 1; i <= word.Length; ++i)
                {
                    if (dp[i - 1])
                        continue;

                    var currentWord = word.Substring(curentIdx, i - curentIdx);

                    if (dic.Contains(currentWord))
                    {
                        if (WordBreak(i))
                            return true;

                        dp[i - 1] = true;
                    }
                }
                return false;
            }
        }
    }
}
