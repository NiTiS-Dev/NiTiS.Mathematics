using System;
using System.Numerics;
using CommunityToolkit.Diagnostics;

namespace NiTiS.Mathematics;

public sealed class Matrix<T>
    where T : INumber<T>
{
    private readonly T[] _matrix;
    public int Rows { get; }
    public int Columns { get; }

    private Matrix(T[] matrix, int rows, int columns)
    {
        Guard.IsGreaterThan(rows, 0);
        Guard.IsGreaterThan(columns, 0);
        Guard.IsNotNull(matrix);
        _matrix = matrix;
        Rows = rows;
        Columns = columns;

        if (matrix.Length != Rows * Columns)
        {
            ThrowHelper.ThrowArgumentException(nameof(matrix), "Provided matrix array is not aligned with provided dimensions.");
        }
    }

    private Matrix(int rows, int columns)
    {
        Guard.IsGreaterThan(rows, 0);
        Guard.IsGreaterThan(columns, 0);
        _matrix = new T[rows * columns];
        Rows = rows;
        Columns = columns;
    }

    public T this[int row, int column]
    {
        get
        {
            int index = row * Columns + column;
            return _matrix[index];
        }
        set
        {
            int index = row * Columns + column;
            _matrix[index] = value;
        }
    }
    
    public static Matrix<T> CreateIdentity(int size)
    {
        Guard.IsGreaterThan(size, 0);
        T[] matrix = new T[size * size];

        for (int i = 0; i < matrix.Length; i += size + 1)
        {
            matrix[i] = T.One;
        }
        
        return new Matrix<T>(matrix, size, size);
    }

    public static bool CanMultiply(Matrix<T> lhs, Matrix<T> rhs)
    {
        return lhs.Rows == rhs.Columns;
    }

    public static Matrix<T> operator *(Matrix<T> lhs, Matrix<T> rhs)
    {
        if (!CanMultiply(lhs, rhs))
        {
            throw new MatrixInvalidMultiplicationException();
        }

        int rows = lhs.Rows;
        int columns = rhs.Columns;
        int commonDimension = lhs.Columns;
        Matrix<T> result = new Matrix<T>(rows, columns);
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                T sum = T.Zero;
                for (int k = 0; k < commonDimension; k++)
                {
                    sum += lhs[i, k] * rhs[k, j];
                }
                result[i, j] = sum;
            }
        }

        return result;
    }
}