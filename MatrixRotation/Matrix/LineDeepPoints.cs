using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixRotation.Matrix
{
    public class LineDeepPoints
    {
        public DeepPoint StartDeepPoint { get; internal set; }
        public DeepPoint EndDeepPoint { get; internal set; }
        public int Deep { get; }
        public bool IsLastDeep { get; }

        public LineDeepPoints(List<List<int>> matrix, int deep)
        {
            int rows = matrix.Count();
            int cols = matrix[0].Count();
            int maxDeep = (int)Math.Ceiling(Math.Min(rows, cols) / 2d);

            AbortIfDeepOutOfRange(deep, maxDeep);

            Deep = deep;
            IsLastDeep = deep == maxDeep - 1;
            StartDeepPoint = new DeepPoint(deep, deep);
            EndDeepPoint = new DeepPoint(rows - 1 - deep, cols - 1 - deep);
        }

        private void AbortIfDeepOutOfRange(int deep, int maxDeep)
        {
            if (deep < 0 || deep > maxDeep)
                throw new ArgumentOutOfRangeException($"deep between 0 - {maxDeep}");
        }
    }
}
