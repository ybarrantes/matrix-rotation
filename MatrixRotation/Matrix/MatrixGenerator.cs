using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixRotation.Matrix
{
    public class MatrixGenerator
    {
        private static MatrixGenerator _instance = new MatrixGenerator();

        private MatrixGenerator()
        {
        }

        public List<List<int>> Generate(int rows, int columns, bool random = false)
        {
            List<List<int>> matrix = new List<List<int>>();
            Random rand = new Random();

            int x = 1;
            for (int i = 1; i <= rows; i++)
            {
                List<int> list = new List<int>();
                for (int j = 1; j <= columns; j++)
                {
                    int element = (random) ? rand.Next(99) : x++;

                    list.Add(element);
                }

                matrix.Add(list);
            }

            return matrix;
        }

        public static MatrixGenerator Instance => _instance;
    }
}
