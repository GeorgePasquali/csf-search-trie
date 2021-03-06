﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace III_upr3
{
 /**
 * A space-saving data structure to store words and their counts.
 * Words that share prefixes will have common paths along a branch of the tree.
 */
    class Trie
    {
        private TrieNode head;

        public Trie()
        {
            head = new TrieNode();
        }

        /**
         * Add a word to the trie.
         * Adding is O (|A| * |W|), where A is the alphabet and W is the word being searched.
         */
        public void AddWord(string word)
        {
            TrieNode curr = head;

            curr = curr.GetChild(word[0], true);

            for (int i = 1; i < word.Length; i++)
            {
                curr = curr.GetChild(word[i], true);
            }

            curr.AddCount();
        }

        public void addCollectionToTrie(List<string> inputCollection)
        {
            foreach(string element in inputCollection)
            {
                AddWord(element);
            }
        }

        /**
         * Get the count of a partictlar word.
         * Retrieval is O (|A| * |W|), where A is the alphabet and W is the word being searched.
         */
        public int GetCount(string word)
        {
            TrieNode curr = head;

            foreach (char c in word)
            {
                curr = curr.GetChild(c);

                if (curr == null)
                {
                    return 0;
                }
            }

            return curr.count;
        }

        public int GetSyllableCount(string word)
        {
            TrieNode curr = head;

            foreach (char c in word)
            {
                curr = curr.GetChild(c);

                if (curr == null)
                {
                    return 0;
                }
            }

            return curr.syllableCount;
        }

        internal class TrieNode
        {
            private LinkedList<TrieNode> children;

            public int count { private set; get; }
            public int syllableCount { private set; get; }
            public char data { private set; get; }

            public TrieNode(char data = ' ')
            {
                this.data = data;
                count = 0;
                syllableCount = 1;
                children = new LinkedList<TrieNode>();
            }

            public TrieNode GetChild(char c, bool createIfNotExist = false)
            {
                foreach (var child in children)
                {
                    if (child.data == c)
                    {
                        child.syllableCount++;
                        return child;
                    }
                }

                if (createIfNotExist)
                {
                    return CreateChild(c);
                }

                return null;
            }

            public void AddCount()
            {
                count++;
            }

            public TrieNode CreateChild(char c)
            {
                var child = new TrieNode(c);
                children.AddLast(child);

                return child;
            }
        }
    }
}
