// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryTreeBuilderBase.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The binary tree builder base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup
{
    using System.Collections.Generic;

    using CareerCup.Trees.TreeComponents;

    /// <summary>
    ///     The binary tree builder base.
    /// </summary>
    public abstract class BinaryTreeBuilderBase
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
        public abstract BinaryTreeNode InOrderPostOrderConstruct(
            IList<int> inOrderTraversal, 
            IList<int> postOrderTraversal);

        /// <summary>
        /// The construct.
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
        public abstract BinaryTreeNode PreOrderInOrderConstruct(
            IList<int> preOrderTraversal, 
            IList<int> inOrderTraversal);

        #endregion
    }
}