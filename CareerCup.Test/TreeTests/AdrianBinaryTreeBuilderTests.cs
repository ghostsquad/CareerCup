// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WesBinaryTreeBuilderTests.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The wes binary tree builder tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CareerCup.Test.TreeTests
{
    using System.Diagnostics.CodeAnalysis;

    using CareerCup.Trees.Adrian;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The wes binary tree builder tests.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AdrianBinaryTreeBuilderTests : BinaryTreeBuilderTestBase
    {
        #region Public Methods and Operators

        /// <summary>
        /// The set algorithm.
        /// </summary>
        [TestInitialize]
        public void SetAlgorithm()
        {
            this.BinaryTreeBuilder = new BinaryTreeBuilder();
        }

        #endregion
    }
}