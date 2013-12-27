// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdrianContainsTests.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The adrian contains tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Test.StringManipulationTests
{
    using System.Diagnostics.CodeAnalysis;

    using CareerCup.StringManipulation.Adrian;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The adrian contains tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AdrianContainsTests : ContainsTestBase
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdrianContainsTests" /> class.
        /// </summary>
        public AdrianContainsTests()
        {
            this.ContainsBaseAlgorithm = new StringContains();
        }

        #endregion
    }
}