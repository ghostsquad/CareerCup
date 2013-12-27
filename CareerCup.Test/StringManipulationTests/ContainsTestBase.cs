// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainsTestBase.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The contains test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Test.StringManipulationTests
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;

    using CareerCup.StringManipulation;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Ploeh.AutoFixture;

    /// <summary>
    ///     The contains test base.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public abstract class ContainsTestBase
    {
        #region Constants

        /// <summary>
        ///     The strong needle.
        /// </summary>
        private const string StrongNeedle = "abcdef";

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the contains algorithm.
        /// </summary>
        public ContainsBase ContainsBaseAlgorithm { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The given haystack is partial needle expect return false.
        /// </summary>
        [TestMethod]
        public void GivenHaystackIsPartialNeedleExpectReturnFalse()
        {
            // arrange
            string haystack = StrongNeedle.Substring(0, StrongNeedle.Length - 1);

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        ///     The given haystack no needle expect return false.
        /// </summary>
        [TestMethod]
        public void GivenHaystackNoNeedleExpectReturnFalse()
        {
            // arrange
            var fixture = new Fixture();
            var haystack = fixture.Create<string>();

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        ///     The given needle at beginning of haystack expect return true.
        /// </summary>
        [TestMethod]
        public void GivenNeedleAtBeginningOfHaystackExpectReturnTrue()
        {
            // arrange
            var fixture = new Fixture();
            string haystack = StrongNeedle + "|" + fixture.Create<string>();

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given needle at end of haystack expect return true.
        /// </summary>
        [TestMethod]
        public void GivenNeedleAtEndOfHaystackExpectReturnTrue()
        {
            // arrange
            var fixture = new Fixture();
            string haystack = fixture.Create<string>() + "|" + StrongNeedle;

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given needle cut off at beginning of haystack expect return false.
        /// </summary>
        [TestMethod]
        public void GivenNeedleCutOffAtBeginningOfHaystackExpectReturnFalse()
        {
            // arrange
            var fixture = new Fixture();
            var haystackEnd = fixture.Create<string>();
            string haystack = StrongNeedle.Substring(0, StrongNeedle.Length - 1) + "|" + haystackEnd;

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        ///     The given needle cut off at end of haystack expect return false.
        /// </summary>
        [TestMethod]
        public void GivenNeedleCutOffAtEndOfHaystackExpectReturnFalse()
        {
            // arrange
            var fixture = new Fixture();
            string haystack = fixture.Create<string>() + "|" + StrongNeedle.Substring(0, StrongNeedle.Length - 1);

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        ///     The given needle only expect return true.
        /// </summary>
        [TestMethod]
        public void GivenNeedleOnlyExpectReturnTrue()
        {
            // act
            bool result = this.ContainsBaseAlgorithm.Contains(StrongNeedle, StrongNeedle);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given needle with duplicate characters expect return true.
        /// </summary>
        [TestMethod]
        public void GivenNeedleWithDuplicateCharactersExpectReturnTrue()
        {
            // arrange
            var fixture = new Fixture();
            var haystackPartial = fixture.Create<string>();
            var needleSb = new StringBuilder();
            foreach (char c in fixture.CreateMany<char>())
            {
                needleSb.Append(c);
            }

            string haystack = haystackPartial + "|" + needleSb + "|" + haystackPartial;

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, needleSb.ToString());

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given single character needle and haystack expect return true.
        /// </summary>
        [TestMethod]
        public void GivenSingleCharacterNeedleAndHaystackExpectReturnTrue()
        {
            // arrange
            var fixture = new Fixture();
            string both = fixture.Create<char>().ToString(CultureInfo.InvariantCulture);

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(both, both);

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given single character needle in haystack expect return true.
        /// </summary>
        [TestMethod]
        public void GivenSingleCharacterNeedleInHaystackExpectReturnTrue()
        {
            // arrange
            var fixture = new Fixture();
            char needleChar = StrongNeedle[0];
            char haystackChar;
            do
            {
                haystackChar = fixture.Create<char>();
            }
            while (haystackChar == needleChar);
            var sb = new StringBuilder();
            sb.Append(haystackChar).Append(needleChar).Append(haystackChar);

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(
                sb.ToString(), 
                needleChar.ToString(CultureInfo.InvariantCulture));

            // assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     The given start of hay stack shorter than needle.
        /// </summary>
        [TestMethod]
        public void GivenStartOfHayStackStartIdenticalToNeedleButShorterThanNeedle()
        {
            // arrange            
            string haystack = StrongNeedle.Substring(0, StrongNeedle.Length - 1) + StrongNeedle;

            // act
            bool result = this.ContainsBaseAlgorithm.Contains(haystack, StrongNeedle);

            // assert
            Assert.IsTrue(result);
        }

        #endregion
    }
}