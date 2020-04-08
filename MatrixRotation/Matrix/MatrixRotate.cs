using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixRotation.Matrix
{
    public class MatrixRotate
    {
        private readonly List<List<int>> _matrix;

        public int MatrixDeep { get; internal set; } = 0;
        public List<List<int>> OriginalMatrix => _matrix;

        public int MatrixRows { get; internal set; } = 0;
        public int MatrixColumns { get; internal set; } = 0;

        public MatrixRotate(List<List<int>> matrix)
        {
            _matrix = matrix;

            SetMatrixLimits();
        }

        private void SetMatrixLimits()
        {
            MatrixRows = OriginalMatrix.Count();
            MatrixColumns = OriginalMatrix[0].Count();
            MatrixDeep = (int)Math.Ceiling(Math.Min(MatrixRows, MatrixColumns) / 2d);
        }

        public List<List<int>> Rotate(int numberRotations)
        {
            List<List<int>> rotatedMatrix = GenericCopier<List<List<int>>>.DeepCopy(OriginalMatrix);

            if (numberRotations <= 0)
            {
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");
                return rotatedMatrix;
            }

            for (int i = 0; i < MatrixDeep; i++)
            {
                RotateMatrixLineDeep(rotatedMatrix, i, numberRotations);
            }

            return rotatedMatrix;
        }

        private void RotateMatrixLineDeep(List<List<int>> matrix, int deep, int numberRotations)
        {
            LineDeepElements lineDeepElements = new LineDeepElements(matrix, deep);

            int realNumberRotation = Math.Abs(numberRotations) % lineDeepElements.TotalElements;

            System.Diagnostics.Debug.WriteLine($"-- rotations: {realNumberRotation}");

            // if realNumberRotation is 0 then not apply rotation, line deep keep same position
            if (realNumberRotation > 0)
            {
                for (int element = 1; element <= lineDeepElements.TotalElements; element++)
                {
                    DeepPoint positionElementOriginChange = GetDeepPointFromNumberOfElement(matrix, lineDeepElements, element);

                    int newPosition = element + realNumberRotation;

                    if (newPosition > lineDeepElements.TotalElements)
                        newPosition = newPosition - lineDeepElements.TotalElements;

                    DeepPoint positionElementDestinationChange = GetDeepPointFromNumberOfElement(matrix, lineDeepElements, newPosition);

                    int value = OriginalMatrix[positionElementOriginChange.Row][positionElementOriginChange.Column];

                    matrix[positionElementDestinationChange.Row][positionElementDestinationChange.Column] = value;
                }
            }
            else
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");
        }

        private DeepPoint GetDeepPointFromNumberOfElement(List<List<int>> matrix, LineDeepElements lineDeepElements, int number)
        {
            if (number > lineDeepElements.TotalElements)
                throw new ArgumentOutOfRangeException($"the required number between 1 - {lineDeepElements.TotalElements}");

            int currentNumberElement = 0;

            if (lineDeepElements.ElementsTopToBottom >= number)
            {
                return new DeepPoint(
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Row + number - 1,
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Column);
            }

            currentNumberElement = lineDeepElements.ElementsTopToBottom;

            if (currentNumberElement + lineDeepElements.ElementsLeftToRight >= number)
            {
                return new DeepPoint(
                    lineDeepElements.LineDeepPoints.EndDeepPoint.Row,
                    lineDeepElements.LineDeepPoints.StartDeepPoint.Column + (number - currentNumberElement));
            }

            currentNumberElement += lineDeepElements.ElementsLeftToRight;

            if (currentNumberElement + lineDeepElements.ElementsTopToBottom > number)
            {
                return new DeepPoint(
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Row - (number - currentNumberElement),
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Column);
            }

            currentNumberElement += lineDeepElements.ElementsBottomToTop;

            if (currentNumberElement + lineDeepElements.ElementsRightToLeft >= number)
            {
                return new DeepPoint(
                   lineDeepElements.LineDeepPoints.StartDeepPoint.Row,
                   lineDeepElements.LineDeepPoints.EndDeepPoint.Column - (number - currentNumberElement));
            }

            throw new NullReferenceException();
        }

    }
}
