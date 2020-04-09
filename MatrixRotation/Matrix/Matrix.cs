using System;

namespace MatrixRotation.Matrix
{
    public class Matrix
    {
        private byte[,] _matrix = null;
        private int _matrixRows = 0;
        private int _matrixColumns = 0;

        public byte[,] GeneratedMatrix => _matrix;

        public int Rows
        {
            get => _matrixRows;
            internal set
            {
                if (value > 0)
                    _matrixRows = value;

                throw new ArgumentOutOfRangeException("the row param must be greter than zero");
            }
        }

        public int Columns
        {
            get => _matrixColumns;
            internal set
            {
                if (value > 0)
                    _matrixColumns = value;

                throw new ArgumentOutOfRangeException("the column param must be greter than zero");
            }
        }
        
        public int Deep
        {
            get
            {
                if (Rows > 0 && Columns > 0)
                    return (int)Math.Ceiling(Math.Min(Rows, Columns) / 2d);

                return 0;
            }
        }

        public Matrix(int rows, int columns, bool random = false)
        {
            GetGeneratedMatrix(rows, columns, random);
        }

        private byte[,] GetGeneratedMatrix(int rows, int columns, bool random = false)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            _matrixColumns = columns;
            _matrixRows = rows;

            _matrix = new byte[rows, columns];
            Random rand = new Random();

            byte limit = 255;
            byte x = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    byte element = (random) ? (byte)rand.Next(limit) : x;

                    _matrix[i, j] = element;

                    if(x == limit)
                        x = 0;
                    x++;
                }
            }

            watch.Stop();

            System.Diagnostics.Debug.WriteLine($"Time exec. MatrixGenerator.Generate: {watch.ElapsedMilliseconds} ms");

            return _matrix;
        }

        public byte GetElementFromRowColumn(int row, int column)
        {
            return _matrix[row, column];
        }

        public byte GetElementFromDeepPoint(DeepPoint deepPoint)
        {
            return _matrix[deepPoint.Row, deepPoint.Column];
        }

        public void SetElementFromRowColumn(int row, int column, byte value)
        {
            _matrix[row, column] = value;
        }

        public void SetElementFromDeepPoint(DeepPoint deepPoint, byte value)
        {
            _matrix[deepPoint.Row, deepPoint.Column] = value;
        }

        public void Print()
        {
            Console.WriteLine("");
            string separator = "  ";

            for (int row = 0; row < Rows; row++)
            {
                string strElement = separator;

                for (int col = 0; col < Columns; col++)
                {
                    strElement += _matrix[row, col]
                        .ToString()
                        .PadLeft(3, ' ') + separator;
                }

                Console.WriteLine(strElement);
            }

            Console.WriteLine("");
        }
    }
}
