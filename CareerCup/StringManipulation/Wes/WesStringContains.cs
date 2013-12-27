// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WesStringContains.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   Wes's string contains implementation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.StringManipulation.Wes
{
    using System.Collections.Generic;

    /// <summary>
    ///     Wes's string contains implementation.
    /// </summary>
    public class StringContains : ContainsBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="haystack">
        /// The haystack.
        /// </param>
        /// <param name="needle">
        /// The needle.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Contains(string haystack, string needle)
        {
            var needleDictionary = new Dictionary<char, List<int>>();
            for (int i = 0; i < needle.Length; i++)
            {
                char character = needle[i];
                if (needleDictionary.ContainsKey(character))
                {
                    needleDictionary[character].Add(i);
                }
                else
                {
                    needleDictionary[character] = new List<int> { i };
                }
            }

            int masterPosition = 0;

            while (true)
            {
                char posChar = haystack[masterPosition];

                if (needleDictionary.ContainsKey(posChar))
                {
                    List<int> dictItem = needleDictionary[posChar];
                    foreach (int relPosition in dictItem)
                    {
                        int newPosition = masterPosition - relPosition;

                        if (newPosition + needle.Length <= haystack.Length && newPosition >= 0
                            && needleDictionary.ContainsKey(haystack[newPosition])
                            && haystack.Substring(newPosition, needle.Length) == needle)
                        {
                            return true;
                        }
                    }
                }

                masterPosition += needle.Length;

                if (masterPosition > haystack.Length - 1)
                {
                    return false;
                }
            }
        }

        #endregion
    }
}