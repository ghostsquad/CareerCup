﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WesBinaryTreeBuilder.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The wes binary tree builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Trees.Wes
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using CareerCup.Trees.TreeComponents;

    /// <summary>
    ///     The wes binary tree builder.
    /// </summary>
    public class BinaryTreeBuilder : BinaryTreeBuilderBase
    {
        private IList<int> InOrderTraversal = new List<int>();
        private IList<int> PreOrderTraversal = new List<int>();
        private IList<int> PostOrderTraversal = new List<int>();

        private int PreOrderIndex = 0;

        private static bool AreCollectionsEquivalent(IList<int> collection1, IList<int> collection2)
        {
            var oddity = 0;
            for (var i = 0; i < collection1.Count; i++)
            {
                oddity ^= collection1[i] ^ collection2[i];
            }

            if (oddity == 0)
            {
                return true;
            }

            return false;
        }


        #region Public Methods and Operators

        /// <summary>
        /// The in order post order construct.
        /// </summary>
        /// <param name="inOrderTraversal">
        /// The in order traversal.
        /// </param>
        /// <param name="postOrderTraversal">
        /// The post order traversal.
        /// </param>
        /// <returns>
        /// The <see cref="BinaryTreeNode"/>.
        /// </returns>
        public override BinaryTreeNode InOrderPostOrderConstruct(
            IList<int> inOrderTraversal, 
            IList<int> postOrderTraversal)
        {
            if (inOrderTraversal == null)
            {
                throw new ArgumentNullException("inOrderTraversal");
            }

            if (postOrderTraversal == null)
            {
                throw new ArgumentNullException("postOrderTraversal");
            }

            if (inOrderTraversal.Count != postOrderTraversal.Count || !AreCollectionsEquivalent(inOrderTraversal, postOrderTraversal))
            {
                throw new ArgumentException("Collections are different (order doesn't matter)");
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// The pre order in order construct.
        /// </summary>
        /// <param name="preOrderTraversal">
        /// The pre order traversal.
        /// </param>
        /// <param name="inOrderTraversal">
        /// The in order traversal.
        /// </param>
        /// <returns>
        /// The <see cref="BinaryTreeNode"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override BinaryTreeNode PreOrderInOrderConstruct(
            IList<int> preOrderTraversal, 
            IList<int> inOrderTraversal)
        {
            if (inOrderTraversal == null)
            {
                throw new ArgumentNullException("inOrderTraversal");
            }

            if (preOrderTraversal == null)
            {
                throw new ArgumentNullException("preOrderTraversal");
            }

            if (inOrderTraversal.Count != preOrderTraversal.Count || !AreCollectionsEquivalent(inOrderTraversal, preOrderTraversal))
            {
                throw new ArgumentException("Collections are different (order doesn't matter)");
            }

            if (inOrderTraversal.Count == 0)
            {
                throw new ArgumentOutOfRangeException("inOrderTraversal", "Traversal Sequence is empty.");
            }

            this.PreOrderTraversal = preOrderTraversal;
            this.InOrderTraversal = inOrderTraversal;

            var absoluteRoot = new BinaryTreeNode() { Data = this.PreOrderTraversal[0] };
            var absoluteRootInOrderIndex = this.FindNextIndex(0, inOrderTraversal.Count - 1, absoluteRoot.Data);

            // left
            this.Construct(0, absoluteRootInOrderIndex - 1, absoluteRoot, Direction.Left);

            // right
            this.Construct(absoluteRootInOrderIndex + 1, inOrderTraversal.Count - 1, absoluteRoot, Direction.Right);
            
            return absoluteRoot;
        }

        #endregion

        private void Construct(int low, int high, BinaryTreeNode previousRoot, Direction direction)
        {
            this.PreOrderIndex++;

            if (this.PreOrderIndex >= this.PreOrderTraversal.Count)
            {
                return;
            }
            
            var newRoot = new BinaryTreeNode() { Data = this.PreOrderTraversal[this.PreOrderIndex] };            
            var newRootInOrderIndex = this.FindNextIndex(low, high, newRoot.Data);

            // left
            if (direction == Direction.Left)
            {
                previousRoot.Left = newRoot;
            }
            else
            {
                previousRoot.Right = newRoot;
            }
            
            if (newRootInOrderIndex - 1 >= 0 && newRootInOrderIndex > low)
            {
                this.Construct(low, newRootInOrderIndex - 1, newRoot, Direction.Left);
            }

            if (newRootInOrderIndex >= 0 && newRootInOrderIndex + 1 < this.InOrderTraversal.Count - 1 && newRootInOrderIndex < high)
            {
                this.Construct(newRootInOrderIndex + 1, high, newRoot, Direction.Right);
            }
        }

        private enum Direction
        {
            Left,
            Right
        }

        private int FindNextIndex(int low, int high, int value)
        {
            for (; low <= high; low++)
            {
                if (this.InOrderTraversal[low] == value)
                {
                    return low;
                }
            }

            return -1;
        }
    }
}