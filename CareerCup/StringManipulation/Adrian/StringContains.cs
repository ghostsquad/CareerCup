// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdrianStringContains.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The adrian string contains.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.StringManipulation.Adrian
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     The adrian string contains.
    /// </summary>
    public class StringContains : ContainsBase
    {
        #region Static Fields

        /// <summary>
        ///     The positions.
        /// </summary>
        private static readonly Dictionary<char, List<int>> positions = new Dictionary<char, List<int>>();

        #endregion

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

            for (int i = needle.Length - 1; i < haystack.Length; i += needle.Length)
            {
                char currentChar = haystack[i];
                int[] places = PositionOfLetter(currentChar);
                if (places == null)
                {
                    continue;
                }

                foreach (int item in places)
                {
                    if (((i - item) < 0) || (i - item) + needle.Length > haystack.Length)
                    {
                        continue;
                    }

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

        #endregion

        #region Methods

        /// <summary>
        /// The position of letter.
        /// </summary>
        /// <param name="letter">
        /// The letter.
        /// </param>
        /// <returns>
        /// The <see cref="int[]"/>.
        /// </returns>
        private static int[] PositionOfLetter(char letter)
        {
            if (!positions.Keys.Contains(letter))
            {
                return null;
            }

            return positions[letter].ToArray();
        }

        #endregion
    }
}