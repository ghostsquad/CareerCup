// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WesBinaryTreeBuilder.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The wes binary tree builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Trees.Adrian
{
    using System;
    using System.Collections.Generic;

    using CareerCup.Trees.TreeComponents;

    /// <summary>
    ///     The Adrian binary tree builder.
    /// </summary>
    public class BinaryTreeBuilder : BinaryTreeBuilderBase
    {
        /// <summary>
        /// PreOrder representation of the constructed tree.
        /// </summary>
        private IList<int> PreOrderTraversal { get; set; }

        /// <summary>
        /// InOrder representation of the constructed tree.
        /// </summary>
        private IList<int> InOrderTraversal { get; set; }

        /// <summary>
        /// Current index of the pre-order traversal walkthrough.
        /// </summary>
        private int preorderIndex { get; set; }

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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override BinaryTreeNode InOrderPostOrderConstruct(
            IList<int> inOrderTraversal,
            IList<int> postOrderTraversal)
        {
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
            PreOrderTraversal = preOrderTraversal;
            InOrderTraversal = inOrderTraversal;

            return Construct(0, inOrderTraversal.Count - 1);
        }

        /// <summary>
        /// Constructs a segment of the tree.
        /// </summary>
        /// <param name="low">Low bound of the segment.</param>
        /// <param name="hi">Hi bound of the segment.</param>
        /// <returns></returns>
        private BinaryTreeNode Construct(int low, int hi)
        {
            // Checking if we haven't reach the end of the preorder traversal.
            if (preorderIndex >= PreOrderTraversal.Count)
            {
                return null;
            }

            // If the indices have crossed over each other, there is nothing down here.
            if (low > hi)
            {
                return null;
            }

            // Taking "new root".
            BinaryTreeNode newRoot = new BinaryTreeNode() { Data = PreOrderTraversal[preorderIndex] };

            // If the low and hi have narrowed down to a single node, then there are no childs for this one.
            if (low == hi)
            {
                return newRoot;
            }

            // Finds the index of the new root in the current segment.
            int newRootIndex = FindRootInInOrderTraversal(low, hi, PreOrderTraversal[preorderIndex]);

            //Move to the next "root" in the pre-order list.
            preorderIndex++;

            // Divides the left segment and builds the left sub-tree.
            newRoot.Left = Construct(low, newRootIndex - 1);

            // If we succeded building a left subtree, we move forward. 
            // If nothing was found on the left, then we must use the same index, so no advance.
            if (newRoot.Left != null)
                preorderIndex++;

            // Divides the right segment and builds the right sub-tree.
            newRoot.Right = Construct(newRootIndex + 1, hi);

            // return the constructed root to the upstream caller.
            return newRoot;

        }

        /// <summary>
        /// Returns the index of the searched root in the In-Order Traversal.
        /// </summary>
        /// <param name="low">The low bound of the segment searched.</param>
        /// <param name="hi">The high bound of the segment searched.</param>
        /// <param name="newRoot">The root from the Pre-order traversal that is being searched.</param>
        /// <returns>The index in the In order traversal of the new root.</returns>
        private int FindRootInInOrderTraversal(int low, int hi, int newRoot)
        {
            for (int i = low; i <= hi; i++)
            {
                if (InOrderTraversal[i] == newRoot)
                {
                    return i;
                }
            }

            throw new ArgumentException("The new root does not exists in the traversal. The data must be inconsistent.");
        }

        #endregion
    }
}