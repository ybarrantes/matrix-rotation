using MatrixRotation.Matrix2D;
using System;

namespace MatrixRotation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine().TrimEnd());

            Console.Write("\r\nInsert number of columns: ");
            int columns = Convert.ToInt32(Console.ReadLine().TrimEnd());

            Console.Write("\r\nInsert number of rotations: ");
            int rotations = Convert.ToInt32(Console.ReadLine().TrimEnd());

            bool random = GetBoolQuestion("Use random?");

            bool print = GetBoolQuestion("Print matrix?");

            matrixRotation(rows, columns, random, rotations, print);
        }

        private static bool GetBoolQuestion(string message)
        {
            Console.Write($"\r\n{message} (yes = 1, no = any key): ");
            string strResponse = Console.ReadLine().TrimEnd();

            return (strResponse.ToLower().Trim() == "1");
        }

        static void matrixRotation(int rows, int columns, bool random, int rotations, bool print)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Matrix matrix = new Matrix(rows, columns, random);

            MatrixRotate matrixRotation = new MatrixRotate(matrix, print);
            matrixRotation.Rotate(rotations);

            watch.Stop();

            Console.Write($"\r\n Time execution: {watch.ElapsedMilliseconds} ms \r\n");
        }

    }
}
