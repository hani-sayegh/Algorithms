using System.Collections.Generic;
using System.Linq;

namespace Leetcode.DataStructures
{
    class _211
    {
        public class WordDictionary
        {
            private class WordNode
            {
                public bool IsWord { get; set; } = false;
                Dictionary<char, WordNode> wordNode = new Dictionary<char, WordNode>();

                public WordNode Add(char c)
                {
                    if (!wordNode.ContainsKey(c))
                        wordNode[c] = new WordNode();
                    return wordNode[c];
                }

                public WordNode GetChildNode(char c)
                {
                    if (!wordNode.ContainsKey(c))
                        return null;
                    return wordNode[c];
                }

                public IEnumerable<WordNode> GetAllChildNodes()
                {
                    foreach (var key in wordNode.Keys)
                    {
                        yield return GetChildNode(key);
                    }
                }
            }

            readonly WordNode root = new WordNode();
            /** Initialize your data structure here. */
            public WordDictionary()
            {

            }

            /** Adds a word into the data structure. */
            public void AddWord(string word)
            {
                var currentWordNode = root;
                foreach (var currentChar in word)
                {
                    currentWordNode = currentWordNode.Add(currentChar);
                }
                currentWordNode.IsWord = true;
            }

            /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
            public bool Search(string word)
            {
                return Search(root, 0);
                bool Search(WordNode current, int startIdx)
                {
                    if (current == null)
                        return false;
                    if (startIdx == word.Length)
                        return current.IsWord;

                    var currentChar = word[startIdx];

                    if (currentChar == '.')
                    {
                        return current.GetAllChildNodes().Any(x => Search(x, startIdx + 1));
                    }
                    else
                    {
                        return Search(current.GetChildNode(currentChar), startIdx + 1);
                    }
                }
            }
        }
    }
}
