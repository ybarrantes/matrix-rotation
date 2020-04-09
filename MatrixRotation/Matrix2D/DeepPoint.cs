using System;
using System.Diagnostics.CodeAnalysis;

namespace MatrixRotation.Matrix2D
{
    public class DeepPoint : ICloneable, IEquatable<DeepPoint>
    {
        public int Column { get; set; } = -1;
        public int Row { get; set; } = -1;

        public string Tag { get; set; } = null;

        public DeepPoint(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public DeepPoint(int row, int column, string tag)
            :this (row, column)
        {
            Tag = tag;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }

        public object Clone()
        {
            return new DeepPoint(Row, Column, Tag);
        }

        public bool Equals([AllowNull] DeepPoint deepPoint)
        {
            return (Column, Row, Tag) == (deepPoint.Column, deepPoint.Row, deepPoint.Tag);
        }
    }
}
