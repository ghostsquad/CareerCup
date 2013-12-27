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
    ///     The wes binary tree builder.
    /// </summary>
    public class BinaryTreeBuilder : BinaryTreeBuilderBase
    {
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
            throw new NotImplementedException();
        }

        #endregion
    }
}