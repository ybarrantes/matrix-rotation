using MatrixRotation;
using MatrixRotation.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RotacionMatricial
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert number of rows: ");

            int m = Convert.ToInt32(Console.ReadLine().TrimEnd());

            Console.Write("\r\nInsert number of columns: ");

            int n = Convert.ToInt32(Console.ReadLine().TrimEnd());

            Console.Write("\r\nInsert number of rotations: ");

            int r = Convert.ToInt32(Console.ReadLine().TrimEnd());

            Console.Write("\r\nGenerate random numbers (y, n): ");

            string strRandom = Console.ReadLine().TrimEnd();

            bool random = (strRandom.ToLower().Trim() == "y");

            List<List<int>> matrix = MatrixGenerator.Instance.Generate(m, n, random);

            /*List<List<int>> matrix = new List<List<int>>
            {
                new List<int> { 1, 2, 3, 4 },
                new List<int> { 7, 8, 9, 10 },
                new List<int> { 13, 14, 15, 16 },
                new List<int> { 19, 20, 21, 22 },
                new List<int> { 25, 26, 27, 28 }
            };*/

            matrixRotation(matrix, r);
        }

        static void matrixRotation(List<List<int>> matrix, int r)
        {
            MatrixPrinter.Instance.Print(matrix);

            MatrixRotation.Matrix.MatrixRotate matrixRotation = new MatrixRotation.Matrix.MatrixRotate(matrix);

            List<List<int>> matrixResult = matrixRotation.Rotate(r);

            Console.WriteLine("");

            MatrixPrinter.Instance.Print(matrixResult);

            Console.WriteLine("");
        }

    }
}
