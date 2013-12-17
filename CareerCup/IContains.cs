namespace CareerCup
{
    /// <summary>
    /// The Contains interface.
    /// </summary>
    public interface IContains
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
        bool Contains(string haystack, string needle);

        #endregion
    }
}