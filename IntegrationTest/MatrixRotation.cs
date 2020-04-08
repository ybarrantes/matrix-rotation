using MatrixRotation.Matrix;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntegrationTest
{
    public class MatrixRotation
    {       

        private List<List<int>> Rotate(int rows, int cols, int rotations)
        {
            List<List<int>> matrix = MatrixGenerator.Instance.Generate(rows, cols);

            MatrixRotate matrixRotate = new MatrixRotate(matrix);

            return matrixRotate.Rotate(rotations);
        }

        [Test]
        public void When_Matrix_1x1_Rotate_1()
        {
            List<List<int>> result = Rotate(1, 1, 1);

            Assert.AreEqual(1, result[0][0]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_0()
        {
            List<List<int>> result = Rotate(2, 1, 0);

            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[1][0]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_1()
        {
            List<List<int>> result = Rotate(2, 1, 1);

            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(1, result[1][0]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_2()
        {
            List<List<int>> result = Rotate(2, 1, 2);

            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[1][0]);
        }



        [Test]
        public void When_Matrix_2x2_Rotate_0()
        {
            List<List<int>> result = Rotate(2, 2, 0);

            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(3, result[1][0]);
            Assert.AreEqual(4, result[1][1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_1()
        {
            List<List<int>> result = Rotate(2, 2, 1);

            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(4, result[0][1]);
            Assert.AreEqual(1, result[1][0]);
            Assert.AreEqual(3, result[1][1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_2()
        {
            List<List<int>> result = Rotate(2, 2, 2);

            Assert.AreEqual(4, result[0][0]);
            Assert.AreEqual(3, result[0][1]);
            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(1, result[1][1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_3()
        {
            List<List<int>> result = Rotate(2, 2, 3);

            Assert.AreEqual(3, result[0][0]);
            Assert.AreEqual(1, result[0][1]);
            Assert.AreEqual(4, result[1][0]);
            Assert.AreEqual(2, result[1][1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_4()
        {
            List<List<int>> result = Rotate(2, 2, 4);

            Assert.AreEqual(1, result[0][0]);
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(3, result[1][0]);
            Assert.AreEqual(4, result[1][1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_5()
        {
            List<List<int>> result = Rotate(2, 2, 5);

            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(4, result[0][1]);
            Assert.AreEqual(1, result[1][0]);
            Assert.AreEqual(3, result[1][1]);
        }



        [Test]
        public void When_Matrix_3x2_Rotate_1()
        {
            List<List<int>> result = Rotate(3, 2, 1);

            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(4, result[0][1]);
            Assert.AreEqual(1, result[1][0]);
            Assert.AreEqual(6, result[1][1]);
            Assert.AreEqual(3, result[2][0]);
            Assert.AreEqual(5, result[2][1]);
        }


        [Test]
        public void When_Matrix_4x4_Rotate_1()
        {
            List<List<int>> result = Rotate(4, 4, 1);

            Assert.AreEqual(2, result[0][0]);
            Assert.AreEqual(3, result[0][1]);
            Assert.AreEqual(4, result[0][2]);
            Assert.AreEqual(8, result[0][3]);

            Assert.AreEqual(1, result[1][0]);
            Assert.AreEqual(7, result[1][1]);
            Assert.AreEqual(11, result[1][2]);
            Assert.AreEqual(12, result[1][3]);

            Assert.AreEqual(5, result[2][0]);
            Assert.AreEqual(6, result[2][1]);
            Assert.AreEqual(10, result[2][2]);
            Assert.AreEqual(16, result[2][3]);

            Assert.AreEqual(9, result[3][0]);
            Assert.AreEqual(13, result[3][1]);
            Assert.AreEqual(14, result[3][2]);
            Assert.AreEqual(15, result[3][3]);
        }

        public void When_Matrix_4x4_Rotate_2()
        {
            List<List<int>> result = Rotate(4, 4, 2);

            Assert.AreEqual(3, result[0][0]);
            Assert.AreEqual(4, result[0][1]);
            Assert.AreEqual(8, result[0][2]);
            Assert.AreEqual(12, result[0][3]);

            Assert.AreEqual(2, result[1][0]);
            Assert.AreEqual(11, result[1][1]);
            Assert.AreEqual(10, result[1][2]);
            Assert.AreEqual(16, result[1][3]);

            Assert.AreEqual(1, result[2][0]);
            Assert.AreEqual(7, result[2][1]);
            Assert.AreEqual(6, result[2][2]);
            Assert.AreEqual(15, result[2][3]);

            Assert.AreEqual(5, result[3][0]);
            Assert.AreEqual(9, result[3][1]);
            Assert.AreEqual(13, result[3][2]);
            Assert.AreEqual(14, result[3][3]);
        }


        [Test]
        public void When_Matrix_5x4_Custom_Rotate_7()
        {
            List<List<int>> matrix = new List<List<int>>
            {
                new List<int> { 1, 2, 3, 4 },
                new List<int> { 7, 8, 9, 10 },
                new List<int> { 13, 14, 15, 16 },
                new List<int> { 19, 20, 21, 22 },
                new List<int> { 25, 26, 27, 28 }
            };

            MatrixRotate matrixRotate = new MatrixRotate(matrix);

            List<List<int>> result = matrixRotate.Rotate(7);

            Assert.AreEqual(28, result[0][0]);
            Assert.AreEqual(27, result[0][1]);
            Assert.AreEqual(26, result[0][2]);
            Assert.AreEqual(25, result[0][3]);

            Assert.AreEqual(22, result[1][0]);
            Assert.AreEqual(9, result[1][1]);
            Assert.AreEqual(15, result[1][2]);
            Assert.AreEqual(19, result[1][3]);

            Assert.AreEqual(16, result[2][0]);
            Assert.AreEqual(8, result[2][1]);
            Assert.AreEqual(21, result[2][2]);
            Assert.AreEqual(13, result[2][3]);

            Assert.AreEqual(10, result[3][0]);
            Assert.AreEqual(14, result[3][1]);
            Assert.AreEqual(20, result[3][2]);
            Assert.AreEqual(7, result[3][3]);

            Assert.AreEqual(4, result[4][0]);
            Assert.AreEqual(3, result[4][1]);
            Assert.AreEqual(2, result[4][2]);
            Assert.AreEqual(1, result[4][3]);
        }
    }
}