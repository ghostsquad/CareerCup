// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryTreeBuilderTestBase.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The binary tree builder test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Test.TreeTests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using CareerCup.Trees.TreeComponents;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The binary tree builder test base.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public abstract class BinaryTreeBuilderTestBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the binary tree builder.
        /// </summary>
        public BinaryTreeBuilderBase BinaryTreeBuilder { get; set; }

        #endregion

        // Given a sequence of numbers, defined as the PreOrder, InOrder, and/or PostOrder traversal of a binary tree. Recreate the tree.

        // Example:
        // PreOrder 7,10,4,3,1,2,8,11
        // InOrder 4,10,3,1,7,11,8,2

        // Resulting Binary Tree:

        // ---- 7 ----
        // /                 \
        // 10                    2
        // /   \                /
        // 4     3              8
        // \          /
        // 1       11
        #region Public Methods and Operators

        /// <summary>
        ///     The given example tree.
        /// </summary>
        [TestMethod]
        public void GivenExampleTreeWhenInOrderPostOrderProvided()
        {
            // arrange            
            var expectedTreeRoot = new BinaryTreeNode { Data = 7 };            
            expectedTreeRoot.Left = new BinaryTreeNode { Data = 10 };
            expectedTreeRoot.Left.Left = new BinaryTreeNode { Data = 4 };
            expectedTreeRoot.Left.Right = new BinaryTreeNode { Data = 3 };
            expectedTreeRoot.Left.Right.Right = new BinaryTreeNode { Data = 1 };

            expectedTreeRoot.Right = new BinaryTreeNode { Data = 2 };
            expectedTreeRoot.Right.Left = new BinaryTreeNode { Data = 8 };
            expectedTreeRoot.Right.Left.Left = new BinaryTreeNode { Data = 11 };

            var preOrder = new List<int> { 7, 10, 4, 3, 1, 2, 8, 11 };
            var inOrder = new List<int> { 4, 10, 3, 1, 7, 11, 8, 2 };

            // act
            BinaryTreeNode actualTreeRoot = this.BinaryTreeBuilder.PreOrderInOrderConstruct(preOrder, inOrder);

            // assert
            Assert.AreEqual(expectedTreeRoot.Data, actualTreeRoot.Data);
            Assert.AreEqual(expectedTreeRoot.Left.Data, actualTreeRoot.Left.Data);
            Assert.AreEqual(expectedTreeRoot.Left.Left.Data, actualTreeRoot.Left.Left.Data);
            Assert.AreEqual(expectedTreeRoot.Left.Right.Data, actualTreeRoot.Left.Right.Data);
            Assert.AreEqual(expectedTreeRoot.Left.Right.Right.Data, actualTreeRoot.Left.Right.Right.Data);

            Assert.AreEqual(expectedTreeRoot.Right.Data, actualTreeRoot.Right.Data);
            Assert.AreEqual(expectedTreeRoot.Right.Left.Data, actualTreeRoot.Right.Left.Data);
            Assert.AreEqual(expectedTreeRoot.Right.Left.Left.Data, actualTreeRoot.Right.Left.Left.Data);
        }

        #endregion
    }
}