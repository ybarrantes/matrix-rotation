namespace MatrixRotation.Matrix
{
    public class LineDeepElements
    {
        public LineDeepPoints LineDeepPoints { get; }

        public int ElementsTopToBottom
        {
            get => _elementsTopToBottom;
            internal set => _elementsTopToBottom = GetPositiveNumberOrZero(value);
        }

        public int ElementsRightToLeft
        {
            get => _elementsRightToLeft;
            internal set => _elementsRightToLeft = GetPositiveNumberOrZero(value);
        }

        public int ElementsLeftToRight
        {
            get => _elementsLeftToRight;
            internal set => _elementsLeftToRight = GetPositiveNumberOrZero(value);
        }

        public int ElementsBottomToTop
        {
            get => _elementsBottomToTop;
            internal set => _elementsBottomToTop = GetPositiveNumberOrZero(value);
        }

        public int TotalElements => ElementsTopToBottom + ElementsRightToLeft + ElementsLeftToRight + ElementsBottomToTop;

        private int _elementsTopToBottom = 0;
        private int _elementsRightToLeft = 0;
        private int _elementsLeftToRight = 0;
        private int _elementsBottomToTop = 0;

        public LineDeepElements(LineDeepPoints lineDeepPoints)
        {
            LineDeepPoints = lineDeepPoints;

            SetNumberElements();
        }

        public LineDeepElements(Matrix matrix, int deep)
        {
            LineDeepPoints = new LineDeepPoints(matrix, deep);

            SetNumberElements();
        }

        private void SetNumberElements()
        {
            ElementsTopToBottom = (LineDeepPoints.EndDeepPoint.Row + 1) - LineDeepPoints.StartDeepPoint.Row;

            ElementsLeftToRight = (LineDeepPoints.EndDeepPoint.Column + 1) - LineDeepPoints.StartDeepPoint.Column - 1;

            ElementsBottomToTop = (ElementsLeftToRight > 0) ? ElementsTopToBottom - 1 : 0;

            ElementsRightToLeft = (ElementsBottomToTop > 0) ? ElementsLeftToRight - 1 : 0;
        }

        private int GetPositiveNumberOrZero(int number) => (number >= 0) ? number : 0;
    }
}
