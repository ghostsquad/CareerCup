// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsBase.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The Contains interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.StringManipulation
{
    /// <summary>
    ///     The Contains interface.
    /// </summary>
    public abstract class ContainsBase
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
        public abstract bool Contains(string haystack, string needle);

        #endregion
    }
}