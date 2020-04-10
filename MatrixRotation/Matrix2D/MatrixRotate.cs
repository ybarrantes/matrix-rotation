using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatrixRotation.Matrix2D
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

        public async Task<Matrix> Rotate(int numberRotations)
        {
            PrintMatrix();

            if (numberRotations <= 0)
            {
                System.Diagnostics.Debug.WriteLine("-- Not rotate!!!");
                return Matrix;
            }

            int elementsByTask = 20000 * 20000;
            int totalElements = Matrix.Rows * Matrix.Columns;

            if(totalElements > elementsByTask)
            {
                System.Diagnostics.Debug.WriteLine("async method");

                int balancedElementsByTask = totalElements / (int)Math.Ceiling((decimal)totalElements / elementsByTask);

                List<Task> taskList = new List<Task> { };

                int initialDeep = 0;
                int taskDeepElementsAssigned = 0;
                for (int i = 0; i < Matrix.Deep; i++)
                {
                    int currentDeepRows = Matrix.Rows - (i * 2);
                    int currentDeepColumns = Matrix.Columns - (i * 2);

                    int nextDeepRows = Matrix.Rows - ((i + 1) * 2);
                    int nextDeepColumns = Matrix.Columns - ((i + 1) * 2);

                    int matrixElementsCurrentDeep = currentDeepRows * currentDeepColumns;
                    int matrixElementsNextDeep = nextDeepRows * nextDeepColumns;

                    int currentDeepElements = matrixElementsCurrentDeep - matrixElementsNextDeep;

                    taskDeepElementsAssigned += currentDeepElements;

                    if(taskDeepElementsAssigned >= balancedElementsByTask || i == Matrix.Deep - 1)
                    {
                        int initDeep = initialDeep;
                        int endDeep = i;
                        int taskNumber = taskList.Count;

                        Task task = Task.Run(() =>
                            {
                                System.Diagnostics.Debug.WriteLine($"------------------------- start task # {taskNumber} {initDeep}:{endDeep}");
                                for (int iDeep = initDeep; iDeep <= endDeep; iDeep++)
                                {
                                    RotateMatrixLineDeep(iDeep, numberRotations);
                                }
                                System.Diagnostics.Debug.WriteLine($"------------------------- end task # {taskNumber} {initDeep}:{endDeep}");
                            }
                        );

                        taskList.Add(task);

                        initialDeep = i + 1;
                        taskDeepElementsAssigned = 0;
                    }
                }

                System.Diagnostics.Debug.WriteLine($"------- Task Number: {taskList.Count}");

                await Task.WhenAll(taskList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("traditional method");

                for (int i = 0; i < Matrix.Deep; i++)
                {
                    RotateMatrixLineDeep(i, numberRotations);
                }
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
