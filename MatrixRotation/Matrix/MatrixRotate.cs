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
                DeepPoint positionElementOrigin = null;
                DeepPoint firstElementOrigin = null;

                int indexRotation = 1;
                int nextPosition = 0;
                var nextValue = Matrix.GetElementFromRowColumn(0, 0);

                do
                {
                    if(positionElementOrigin == null || positionElementOrigin.Equals(firstElementOrigin))
                    {
                        positionElementOrigin = lineDeepElements.GetDeepPointFromLinePositionElement(++nextPosition);
                        firstElementOrigin = (DeepPoint)positionElementOrigin.Clone();
                        nextValue = this.Matrix.GetElementFromDeepPoint(positionElementOrigin);
                    }

                    int currentPosition = nextPosition + realNumberRotation;

                    if (currentPosition > lineDeepElements.TotalElements)
                        currentPosition -= lineDeepElements.TotalElements;

                    DeepPoint positionElementDestination = lineDeepElements.GetDeepPointFromLinePositionElement(currentPosition);

                    var currentValue = this.Matrix.GetElementFromDeepPoint(positionElementDestination);
                    this.Matrix.SetElementFromDeepPoint(positionElementDestination, nextValue);

                    nextValue = currentValue;
                    nextPosition = currentPosition;

                    positionElementOrigin = (DeepPoint)positionElementDestination.Clone();
                } while (indexRotation++ < lineDeepElements.TotalElements);
            }
            else
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");

            watch.Stop();

            System.Diagnostics.Debug.WriteLine($"-- rotations: {realNumberRotation} - deep: {deep} - elements: {lineDeepElements.TotalElements}. Time exec LineDeep: {watch.ElapsedMilliseconds} ms");
        }
    }
}
