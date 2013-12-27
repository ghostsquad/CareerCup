// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryTreeNode.cs" company="https://github.com/ghostsquad">
//   2013 Weston McNamee, Adrian Padilla
// </copyright>
// <summary>
//   The binary tree node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CareerCup.Trees.TreeComponents
{
    /// <summary>
    ///     The binary tree node.
    /// </summary>
    public class BinaryTreeNode
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        public int Data { get; set; }

        /// <summary>
        ///     Gets or sets the left.
        /// </summary>
        public BinaryTreeNode Left { get; set; }

        /// <summary>
        ///     Gets or sets the right.
        /// </summary>
        public BinaryTreeNode Right { get; set; }

        #endregion      
    }
}