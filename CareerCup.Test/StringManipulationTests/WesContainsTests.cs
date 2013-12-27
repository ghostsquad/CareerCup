// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WesContainsTests.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The wes contains tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Test.StringManipulationTests
{
    using System.Diagnostics.CodeAnalysis;

    using CareerCup.StringManipulation.Wes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The wes contains tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WesContainsTests : ContainsTestBase
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The set the algorithm.
        /// </summary>
        [TestInitialize]
        public void SetTheAlgorithm()
        {
            this.ContainsBaseAlgorithm = new StringContains();
        }

        #endregion
    }
}