using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MatrixOperations;

namespace MatrixOperations.Tests
{
    [TestClass]
    public class GenericUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckingTypeOfMatrices()
        {
            GenericMatrix<char> genericMatrix = new GenericMatrix<char>(2,2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddingWithDifferentRowsAndColums()
        {
            GenericMatrix<double> first = new GenericMatrix<double>(5, 3);
            GenericMatrix<double> second = new GenericMatrix<double>(3, 5);
            GenericMatrix<double> result;
            result = first + second;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeRowAndCols()
        {
            GenericMatrix<double> first = new GenericMatrix<double>(-5, 3);
            GenericMatrix<double> second = new GenericMatrix<double>(3, -5);
            GenericMatrix<double> result;
            result = first + second;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MultiplyingWithDifferentRowsAndColums()
        {
            GenericMatrix<double> first = new GenericMatrix<double>(5, 3);
            GenericMatrix<double> second = new GenericMatrix<double>(6, 5);
            GenericMatrix<double> result;
            result = first * second;
        }
        [TestMethod]
        public void Adding()
        {
            int row = 3;
            int col = 4;
            GenericMatrix<int> first = new GenericMatrix<int>(row, col);
            GenericMatrix<int> second = new GenericMatrix<int>(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    first[i, j] = i + j;
                    second[i, j] = i + j;
                }
            }
            GenericMatrix<int> result = first + second;
            int[,] expected = new int[,]
            {
                 {0,2,4,6},
                { 2,4,6,8},
                {4,6,8,10 }
            };
            var actual = result.ToArrays();
            bool resultValue = true;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (expected[i,j]!=actual[i,j])
                    {
                        resultValue = false;
                        break;
                    }
                }
            }
            Assert.AreEqual(resultValue, true);
        }

        [TestMethod]
        public void Multiplying()
        {
            int row = 3;
            int col = 4;
            GenericMatrix<int> first = new GenericMatrix<int>(row, col);
            GenericMatrix<int> second = new GenericMatrix<int>(col, row);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    first[i, j] = i + j; 
                }
            }
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    second[i, j] = i + j;
                }
            }
            GenericMatrix<int> result = new GenericMatrix<int>(row, row);
            result = first * second;
            int[,] expected = new int[,]
            {
                 {14,20,26},
                {20,30,40 },
                {26,40,54}
            };
            var actual = result.ToArrays();
            bool resultValue = true;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Column; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        resultValue = false;
                        break;
                    }
                }
            }
            Assert.AreEqual(resultValue, true);
        }
    }
}
