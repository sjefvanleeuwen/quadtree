namespace Morstead.Spatial.Quadtree
{
    /// <summary>
    /// An item with a position, a size and a random colour to test
    /// the QuadTree structure.
    /// </summary>
    public class ItemT<T> : IHasRect
    {
        T Value { get; set; }

        /// <summary>
        /// Create an item at the given location with the given size.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="size"></param>
        public ItemT(Point p, int size, T value)
        {
            m_size = size;
            m_rectangle = new RectangleF(p.X, p.Y, m_size, m_size);
            Value = value;
        }

        /// <summary>
        /// Bounds of this item
        /// </summary>
        RectangleF m_rectangle;

        /// <summary>
        /// the default size of this item
        /// </summary>
        int m_size = 2;

        #region IHasRect Members

        /// <summary>
        /// The rectangular bounds of this item
        /// </summary>
        public RectangleF Rectangle { get { return m_rectangle; } }

        #endregion
    }
}
