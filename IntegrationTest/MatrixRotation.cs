using MatrixRotation.Matrix2D;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntegrationTest
{
    public class MatrixRotation
    {
        private Matrix Rotate(int rows, int cols, int rotations)
        {
            Matrix matrix = new Matrix(rows, cols);

            MatrixRotate matrixRotate = new MatrixRotate(matrix);

            matrixRotate.Rotate(rotations);

            return matrixRotate.Matrix;
        }

        [Test]
        public void When_Matrix_1x1_Rotate_1()
        {
            var result = Rotate(1, 1, 1).GetGeneratedMatrix();

            Assert.AreEqual(1, result[0, 0]);
        }

        [Test]
        public void When_Matrix_5x1_Rotate_1()
        {
            var result = Rotate(5, 1, 1).GetGeneratedMatrix();

            Assert.AreEqual(5, result[0, 0]);
            Assert.AreEqual(1, result[1, 0]);
            Assert.AreEqual(2, result[2, 0]);
            Assert.AreEqual(3, result[3, 0]);
            Assert.AreEqual(4, result[4, 0]);
        }

        [Test]
        public void When_Matrix_1x5_Rotate_1()
        {
            var result = Rotate(1, 5, 1).GetGeneratedMatrix();

            Assert.AreEqual(5, result[0, 0]);
            Assert.AreEqual(1, result[0, 1]);
            Assert.AreEqual(2, result[0, 2]);
            Assert.AreEqual(3, result[0, 3]);
            Assert.AreEqual(4, result[0, 4]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_0()
        {
            var result = Rotate(2, 1, 0).GetGeneratedMatrix();

            Assert.AreEqual(1, result[0, 0]);
            Assert.AreEqual(2, result[1, 0]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_1()
        {
            var result = Rotate(2, 1, 1).GetGeneratedMatrix();

            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(1, result[1, 0]);
        }

        [Test]
        public void When_Matrix_2x1_Rotate_2()
        {
            var result = Rotate(2, 1, 2).GetGeneratedMatrix();

            Assert.AreEqual(1, result[0, 0]);
            Assert.AreEqual(2, result[1, 0]);
        }



        [Test]
        public void When_Matrix_2x2_Rotate_0()
        {
            var result = Rotate(2, 2, 0).GetGeneratedMatrix();

            Assert.AreEqual(1, result[0, 0]);
            Assert.AreEqual(2, result[0, 1]);
            Assert.AreEqual(3, result[1, 0]);
            Assert.AreEqual(4, result[1, 1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_1()
        {
            var result = Rotate(2, 2, 1).GetGeneratedMatrix();

            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(4, result[0, 1]);
            Assert.AreEqual(1, result[1, 0]);
            Assert.AreEqual(3, result[1, 1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_2()
        {
            var result = Rotate(2, 2, 2).GetGeneratedMatrix();

            Assert.AreEqual(4, result[0, 0]);
            Assert.AreEqual(3, result[0, 1]);
            Assert.AreEqual(2, result[1, 0]);
            Assert.AreEqual(1, result[1, 1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_3()
        {
            var result = Rotate(2, 2, 3).GetGeneratedMatrix();

            Assert.AreEqual(3, result[0, 0]);
            Assert.AreEqual(1, result[0, 1]);
            Assert.AreEqual(4, result[1, 0]);
            Assert.AreEqual(2, result[1, 1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_4()
        {
            var result = Rotate(2, 2, 4).GetGeneratedMatrix();

            Assert.AreEqual(1, result[0, 0]);
            Assert.AreEqual(2, result[0, 1]);
            Assert.AreEqual(3, result[1, 0]);
            Assert.AreEqual(4, result[1, 1]);
        }

        [Test]
        public void When_Matrix_2x2_Rotate_5()
        {
            var result = Rotate(2, 2, 5).GetGeneratedMatrix();

            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(4, result[0, 1]);
            Assert.AreEqual(1, result[1, 0]);
            Assert.AreEqual(3, result[1, 1]);
        }



        [Test]
        public void When_Matrix_3x2_Rotate_1()
        {
            var result = Rotate(3, 2, 1).GetGeneratedMatrix();

            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(4, result[0, 1]);
            Assert.AreEqual(1, result[1, 0]);
            Assert.AreEqual(6, result[1, 1]);
            Assert.AreEqual(3, result[2, 0]);
            Assert.AreEqual(5, result[2, 1]);
        }


        [Test]
        public void When_Matrix_4x4_Rotate_1()
        {
            var result = Rotate(4, 4, 1).GetGeneratedMatrix();

            Assert.AreEqual(2, result[0, 0]);
            Assert.AreEqual(3, result[0, 1]);
            Assert.AreEqual(4, result[0, 2]);
            Assert.AreEqual(8, result[0, 3]);

            Assert.AreEqual(1, result[1, 0]);
            Assert.AreEqual(7, result[1, 1]);
            Assert.AreEqual(11, result[1, 2]);
            Assert.AreEqual(12, result[1, 3]);

            Assert.AreEqual(5, result[2, 0]);
            Assert.AreEqual(6, result[2, 1]);
            Assert.AreEqual(10, result[2, 2]);
            Assert.AreEqual(16, result[2, 3]);

            Assert.AreEqual(9, result[3, 0]);
            Assert.AreEqual(13, result[3, 1]);
            Assert.AreEqual(14, result[3, 2]);
            Assert.AreEqual(15, result[3, 3]);
        }

        public void When_Matrix_4x4_Rotate_2()
        {
            var result = Rotate(4, 4, 2).GetGeneratedMatrix();

            Assert.AreEqual(3, result[0, 0]);
            Assert.AreEqual(4, result[0, 1]);
            Assert.AreEqual(8, result[0, 2]);
            Assert.AreEqual(12, result[0, 3]);

            Assert.AreEqual(2, result[1, 0]);
            Assert.AreEqual(11, result[1, 1]);
            Assert.AreEqual(10, result[1, 2]);
            Assert.AreEqual(16, result[1, 3]);

            Assert.AreEqual(1, result[2, 0]);
            Assert.AreEqual(7, result[2, 1]);
            Assert.AreEqual(6, result[2, 2]);
            Assert.AreEqual(15, result[2, 3]);

            Assert.AreEqual(5, result[3, 0]);
            Assert.AreEqual(9, result[3, 1]);
            Assert.AreEqual(13, result[3, 2]);
            Assert.AreEqual(14, result[3, 3]);
        }
    }
}