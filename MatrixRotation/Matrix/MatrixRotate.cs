using System;

namespace MatrixRotation.Matrix
{
    public class MatrixRotate
    {
        private Matrix _matrix;
        public Matrix Matrix => _matrix;
        private bool _printMatrix = false;

        public MatrixRotate(Matrix matrix, bool printMatrix = false)
        {
            _matrix = matrix;
            _printMatrix = printMatrix;
        }

        public Matrix Rotate(int numberRotations)
        {
            PrintMatrix();

            if (numberRotations <= 0)
            {
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");
                return Matrix;
            }

            for (int i = 0; i < Matrix.Deep; i++)
            {
                RotateMatrixLineDeep(i, numberRotations);
            }

            PrintMatrix();

            return Matrix;
        }

        private void PrintMatrix()
        {
            if (_printMatrix)
                Matrix.Print();
        }

        private void RotateMatrixLineDeep(int deep, int numberRotations)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            LineDeepElements lineDeepElements = new LineDeepElements(this.Matrix, deep);

            int realNumberRotation = Math.Abs(numberRotations) % lineDeepElements.TotalElements;

            // if realNumberRotation is 0 then not apply rotation, line deep keep same position
            if (realNumberRotation > 0)
            {
                DeepPoint positionElementOriginChange = null;
                DeepPoint firstElementOriginChange = null;

                int indexRotation = 1;
                int nextPosition = 0;
                var nextValue = Matrix.GetElementFromRowColumn(0, 0);

                do
                {
                    if(positionElementOriginChange == null || positionElementOriginChange.Equals(firstElementOriginChange))
                    {
                        positionElementOriginChange = GetDeepPointFromNumberOfElement(lineDeepElements, ++nextPosition);
                        firstElementOriginChange = (DeepPoint)positionElementOriginChange.Clone();
                        nextValue = this.Matrix.GetElementFromDeepPoint(positionElementOriginChange);
                    }

                    int newPosition = nextPosition + realNumberRotation;

                    if (newPosition > lineDeepElements.TotalElements)
                        newPosition = newPosition - lineDeepElements.TotalElements;

                    DeepPoint positionElementDestinationChange = GetDeepPointFromNumberOfElement(lineDeepElements, newPosition);

                    var currentValue = this.Matrix.GetElementFromDeepPoint(positionElementDestinationChange);
                    this.Matrix.SetElementFromDeepPoint(positionElementDestinationChange, nextValue);

                    nextValue = currentValue;
                    nextPosition = newPosition;

                    positionElementOriginChange = (DeepPoint)positionElementDestinationChange.Clone();
                } while (indexRotation++ < lineDeepElements.TotalElements);
            }
            else
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");

            watch.Stop();

            System.Diagnostics.Debug.WriteLine($"-- rotations: {realNumberRotation} - deep: {deep} - elements: {lineDeepElements.TotalElements}. Time exec LineDeep: {watch.ElapsedMilliseconds} ms");
        }

        private DeepPoint GetDeepPointFromNumberOfElement(LineDeepElements lineDeepElements, int linePosition)
        {
            if (linePosition > lineDeepElements.TotalElements)
                throw new ArgumentOutOfRangeException($"the required number between 1 - {lineDeepElements.TotalElements}");

            int currentNumberElement = 0;

            if (lineDeepElements.ElementsTopToBottom >= linePosition)
            {
                return new DeepPoint(
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Row + linePosition - 1,
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Column,
                    linePosition.ToString());
            }

            currentNumberElement = lineDeepElements.ElementsTopToBottom;

            if (currentNumberElement + lineDeepElements.ElementsLeftToRight >= linePosition)
            {
                return new DeepPoint(
                    lineDeepElements.LineDeepPoints.EndDeepPoint.Row,
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Column + (linePosition - currentNumberElement),
                    linePosition.ToString());
            }

            currentNumberElement += lineDeepElements.ElementsLeftToRight;

            if (currentNumberElement + lineDeepElements.ElementsTopToBottom > linePosition)
            {
                return new DeepPoint(
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Row - (linePosition - currentNumberElement),
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Column,
                   linePosition.ToString());
            }

            currentNumberElement += lineDeepElements.ElementsBottomToTop;

            if (currentNumberElement + lineDeepElements.ElementsRightToLeft >= linePosition)
            {
                return new DeepPoint(
                   lineDeepElements.LineDeepPoints.StartDeepPoint.Row,
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Column - (linePosition - currentNumberElement),
                   linePosition.ToString());
            }

            throw new NullReferenceException();
        }

    }
}
