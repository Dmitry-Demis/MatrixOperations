using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations
{
    public class GenericMatrix<T>
          where T : struct
    {
        protected T[,] ArrayOfT;
        public GenericMatrix(int row, int column)
        {
            if (typeof(T) != typeof(int) && typeof(T) != typeof(double) && typeof(T) != typeof(float))
            {
                throw new ArgumentException($"<T> can be only int, double, float for GenericMatrix<T>");
            }
            IsNatural(row);
            IsNatural(column);
            Row = row;
            Column = column;
            ArrayOfT = new T[Row, Column];

        }
        public T this[int row, int column]
        {
            get => ArrayOfT[row, column];
            set => ArrayOfT[row, column] = value;
        }
        public static GenericMatrix<T> operator +(GenericMatrix<T> lhs, GenericMatrix<T> rhs)
        {
            if (lhs.Row != rhs.Row || rhs.Column != lhs.Column)
            {
                throw new ArgumentException("You can't add two matrices. Wether rows or colums are not equal");
            }
            GenericMatrix<T> result = new GenericMatrix<T>(lhs.Row, rhs.Column);
            for (int i = 0; i < lhs.Row; i++)
            {
                for (int j = 0; j < lhs.Column; j++)
                {
                    result[i, j] = (dynamic)lhs[i, j] + rhs[i, j];
                }
            }
            return result;
        }
        public static GenericMatrix<T> operator *(GenericMatrix<T> lhs, GenericMatrix<T> rhs)
        {
            if (lhs.Column != rhs.Row)
            {
                throw new ArgumentException("Matrices can't be multiplied. Cols and Row must have this relation: A(m,n) B(n, k)");
            }
            GenericMatrix<T> result = new GenericMatrix<T>(lhs.Row, rhs.Column);
            for (int i = 0; i < lhs.Row; i++)
            {
                for (int j = 0; j < rhs.Column; j++)
                {
                    for (int k = 0; k < rhs.Row; k++)
                    {
                        result[i, j] += (dynamic)lhs[i, k] * rhs[k, j];
                    }
                }
            }
            return result;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        private bool IsNatural(int value)
        {
            return (value > 0) ? true : throw new ArgumentException("Value can't be equal to 0 or less value");
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < Row; i++)
            {
                bool f = false;
                for (int j = 0; j < Column; j++)
                {
                    if (f)
                    {
                        Console.Write(" ");
                    }
                    Console.Write($"{ArrayOfT[i, j]:d3}");
                    f = true;
                }
                Console.WriteLine();
            }
        }
        public void PrintMatrix(int lhs_col, int rhs_row)
        {
            for (int i = 0; i < lhs_col; i++)
            {
                bool f = false;
                for (int j = 0; j < rhs_row; j++)
                {
                    if (f)
                    {
                        Console.Write(" ");
                    }
                    Console.Write($"{ArrayOfT[i, j]:d3}");
                    f = true;
                }
                Console.WriteLine();
            }
        }
        public T[,] ToArrays()
        {
            return ArrayOfT;
        }
       /* public override bool Equals(object obj)
        {
            var result = obj as GenericMatrix<T>;
            bool equals = true;
            if (result == null)
            {
                throw new Exception("An object can't be considered like a type of GenericMatrix<>");
            }
            else
            {
                for (int i = 0; i < result.Row; i++)
                {
                    for (int j = 0; j < result.Column; j++)
                    {
                        if (ArrayOfT[i, j].ToString() != result[i, j].ToString())
                        {
                            equals = false;
                            break;
                        }
                    }
                }
            }
            return equals;
        }*/
    }
}
