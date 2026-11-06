using System;

namespace NiTiS.Mathematics;

public sealed class MatrixInvalidMultiplicationException : Exception
{
    public override string Message => "Multiplication is not possible with specified matrices.";
}