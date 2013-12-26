﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCup
{
    public class AdrianStringContains : IContains
    {
        static Dictionary<char, List<int>> positions = new Dictionary<char, List<int>>();

        public bool Contains(string haystack, string needle)
        {
            char firstChar = needle[0];

            // Creates the dictionary of letter positions.
            for (int i = 0; i < needle.Length; i++)
            {
                if (!positions.ContainsKey(needle[i]))
                {
                    positions.Add(needle[i], new List<int>());
                }

                positions[needle[i]].Add(i);
            }

            for (int i = 0; i < haystack.Length; i += needle.Length)
            {
                
                char currentChar = haystack[i];

                if (currentChar == firstChar && haystack.Substring(0, needle.Length) == needle)
                {
                    return true;
                }
                else
                {
                    i = needle.Length-1;
                }

                int[] places = PositionOfLetter(currentChar);
                if (places == null)
                {
                    // i += needle.Length;
                    continue;
                }

                foreach (var item in places)
                {
                    if (haystack[i - item] == firstChar)
                    {
                        string candidate = haystack.Substring(i - item, needle.Length);
                        if (candidate == needle)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }


        private static int[] PositionOfLetter(char letter)
        {
            if (!positions.Keys.Contains<char>(letter))
            {
                return null;
            }

            return positions[letter].ToArray();
        }

    }
    
}