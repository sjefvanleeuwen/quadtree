using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Morstead.Spatial.Quadtree
{
    public struct SizeF : IEquatable<SizeF>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref='Morstead.Spatial.Quadtree.SizeF'/> class.
        /// </summary>
        public static readonly SizeF Empty;
        private float width; // Do not rename (binary serialization)
        private float height; // Do not rename (binary serialization)

        /// <summary>
        /// Initializes a new instance of the <see cref='Morstead.Spatial.Quadtree.SizeF'/> class from the specified
        /// existing <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public SizeF(SizeF size)
        {
            width = size.width;
            height = size.height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Morstead.Spatial.Quadtree.SizeF'/> class from the specified
        /// <see cref='Morstead.Spatial.Quadtree.PointF'/>.
        /// </summary>
        public SizeF(PointF pt)
        {
            width = pt.X;
            height = pt.Y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref='Morstead.Spatial.Quadtree.SizeF'/> struct from the specified
        /// <see cref="System.Numerics.Vector2"/>.
        /// </summary>
        public SizeF(Vector2 vector)
        {
            width = vector.X;
            height = vector.Y;
        }

        /// <summary>
        /// Creates a new <see cref="System.Numerics.Vector2"/> from this <see cref="Morstead.Spatial.Quadtree.SizeF"/>.
        /// </summary>
        public Vector2 ToVector2() => new Vector2(width, height);

        /// <summary>
        /// Initializes a new instance of the <see cref='Morstead.Spatial.Quadtree.SizeF'/> class from the specified dimensions.
        /// </summary>
        public SizeF(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Converts the specified <see cref="Morstead.Spatial.Quadtree.SizeF"/> to a <see cref="System.Numerics.Vector2"/>.
        /// </summary>
        public static explicit operator Vector2(SizeF size) => size.ToVector2();

        /// <summary>
        /// Converts the specified <see cref="System.Numerics.Vector2"/> to a <see cref="Morstead.Spatial.Quadtree.SizeF"/>.
        /// </summary>
        public static explicit operator SizeF(Vector2 vector) => new SizeF(vector);

        /// <summary>
        /// Performs vector addition of two <see cref='Morstead.Spatial.Quadtree.SizeF'/> objects.
        /// </summary>
        public static SizeF operator +(SizeF sz1, SizeF sz2) => Add(sz1, sz2);

        /// <summary>
        /// Contracts a <see cref='Morstead.Spatial.Quadtree.SizeF'/> by another <see cref='Morstead.Spatial.Quadtree.SizeF'/>
        /// </summary>
        public static SizeF operator -(SizeF sz1, SizeF sz2) => Subtract(sz1, sz2);

        /// <summary>
        /// Multiplies <see cref="SizeF"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Multiplier of type <see cref="float"/>.</param>
        /// <param name="right">Multiplicand of type <see cref="SizeF"/>.</param>
        /// <returns>Product of type <see cref="SizeF"/>.</returns>
        public static SizeF operator *(float left, SizeF right) => Multiply(right, left);

        /// <summary>
        /// Multiplies <see cref="SizeF"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Multiplicand of type <see cref="SizeF"/>.</param>
        /// <param name="right">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type <see cref="SizeF"/>.</returns>
        public static SizeF operator *(SizeF left, float right) => Multiply(left, right);

        /// <summary>
        /// Divides <see cref="SizeF"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="left">Dividend of type <see cref="SizeF"/>.</param>
        /// <param name="right">Divisor of type <see cref="int"/>.</param>
        /// <returns>Result of type <see cref="SizeF"/>.</returns>
        public static SizeF operator /(SizeF left, float right)
            => new SizeF(left.width / right, left.height / right);

        /// <summary>
        /// Tests whether two <see cref='Morstead.Spatial.Quadtree.SizeF'/> objects are identical.
        /// </summary>
        public static bool operator ==(SizeF sz1, SizeF sz2) => sz1.Width == sz2.Width && sz1.Height == sz2.Height;

        /// <summary>
        /// Tests whether two <see cref='Morstead.Spatial.Quadtree.SizeF'/> objects are different.
        /// </summary>
        public static bool operator !=(SizeF sz1, SizeF sz2) => !(sz1 == sz2);

        /// <summary>
        /// Converts the specified <see cref='Morstead.Spatial.Quadtree.SizeF'/> to a <see cref='Morstead.Spatial.Quadtree.PointF'/>.
        /// </summary>
        public static explicit operator PointF(SizeF size) => new PointF(size.Width, size.Height);

        /// <summary>
        /// Tests whether this <see cref='Morstead.Spatial.Quadtree.SizeF'/> has zero width and height.
        /// </summary>
        [Browsable(false)]
        public readonly bool IsEmpty => width == 0 && height == 0;

        /// <summary>
        /// Represents the horizontal component of this <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public float Width
        {
            readonly get => width;
            set => width = value;
        }

        /// <summary>
        /// Represents the vertical component of this <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public float Height
        {
            readonly get => height;
            set => height = value;
        }

        /// <summary>
        /// Performs vector addition of two <see cref='Morstead.Spatial.Quadtree.SizeF'/> objects.
        /// </summary>
        public static SizeF Add(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

        /// <summary>
        /// Contracts a <see cref='Morstead.Spatial.Quadtree.SizeF'/> by another <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public static SizeF Subtract(SizeF sz1, SizeF sz2) => new SizeF(sz1.Width - sz2.Width, sz1.Height - sz2.Height);

        /// <summary>
        /// Tests to see whether the specified object is a <see cref='Morstead.Spatial.Quadtree.SizeF'/>  with the same dimensions
        /// as this <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public override readonly bool Equals([NotNullWhen(true)] object? obj) => obj is SizeF && Equals((SizeF)obj);

        public readonly bool Equals(SizeF other) => this == other;

        public override readonly int GetHashCode() => HashCode.Combine(Width, Height);

        public readonly PointF ToPointF() => (PointF)this;

        public readonly Size ToSize() => Size.Truncate(this);

        /// <summary>
        /// Creates a human-readable string that represents this <see cref='Morstead.Spatial.Quadtree.SizeF'/>.
        /// </summary>
        public override readonly string ToString() => $"{{Width={width}, Height={height}}}";

        /// <summary>
        /// Multiplies <see cref="SizeF"/> by a <see cref="float"/> producing <see cref="SizeF"/>.
        /// </summary>
        /// <param name="size">Multiplicand of type <see cref="SizeF"/>.</param>
        /// <param name="multiplier">Multiplier of type <see cref="float"/>.</param>
        /// <returns>Product of type SizeF.</returns>
        private static SizeF Multiply(SizeF size, float multiplier) =>
            new SizeF(size.width * multiplier, size.height * multiplier);
    }

}
