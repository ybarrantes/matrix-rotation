using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixRotation.Matrix
{
    public class MatrixPrinter
    {
        private static MatrixPrinter _instance = new MatrixPrinter();

        private MatrixPrinter()
        {
        }

        public static MatrixPrinter Instance => _instance;

        public void Print(List<List<int>> matrix)
        {
            Console.WriteLine("");
            string separator = "  ";

            foreach (List<int> listColumns in matrix)
            {
                string strElement = separator;

                foreach (int element in listColumns)
                {
                    strElement += element
                        .ToString()
                        .PadLeft(2, ' ') + separator;
                }

                Console.WriteLine(strElement);
            }
        }
    }
}
