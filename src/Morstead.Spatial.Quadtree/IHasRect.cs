using System;

namespace Morstead.Spatial.Quadtree
{
    /// <summary>
    /// An interface that defines and object with a rectangle
    /// </summary>
    public interface IHasRect
    {
        RectangleF Rectangle { get; }
    }
}
