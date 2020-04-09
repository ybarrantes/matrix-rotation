using System;

namespace MatrixRotation.Matrix2D
{
    public class LineDeepPoints
    {
        public DeepPoint StartDeepPoint { get; internal set; }
        public DeepPoint EndDeepPoint { get; internal set; }
        public int Deep { get; }
        public bool IsLastDeep { get; }

        public LineDeepPoints(Matrix matrix, int deep)
        {
            AbortIfDeepOutOfRange(deep, matrix.Deep);

            Deep = deep;
            IsLastDeep = (deep == matrix.Deep - 1);
            StartDeepPoint = new DeepPoint(deep, deep);
            EndDeepPoint = new DeepPoint(matrix.Rows - 1 - deep, matrix.Columns - 1 - deep);
        }

        private void AbortIfDeepOutOfRange(int deep, int maxDeep)
        {
            if (deep < 0 || deep > maxDeep)
                throw new ArgumentOutOfRangeException($"deep between 0 - {maxDeep}");
        }
    }
}
