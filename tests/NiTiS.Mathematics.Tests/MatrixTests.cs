using System.Threading.Tasks;
using MatrixF = NiTiS.Mathematics.Matrix<float>;

namespace NiTiS.Mathematics.Tests;

public class MatrixTests
{
    [Test]
    public async Task IsIdentity()
    {
        MatrixF matrix = MatrixF.CreateIdentity(4);
        await Assert.That(matrix[0, 0]).IsEqualTo(1);
        await Assert.That(matrix[1, 1]).IsEqualTo(1);
        await Assert.That(matrix[2, 2]).IsEqualTo(1);
        await Assert.That(matrix[3, 3]).IsEqualTo(1);
    }

    [Test]
    public async Task IdentityHasZeroOffDiagonal()
    {
        MatrixF matrix = MatrixF.CreateIdentity(3);
        await Assert.That(matrix[0, 1]).IsEqualTo(0);
        await Assert.That(matrix[2, 0]).IsEqualTo(0);
        await Assert.That(matrix[1, 2]).IsEqualTo(0);
    }

    [Test]
    public async Task IdentityDimensions()
    {
        MatrixF matrix = MatrixF.CreateIdentity(3);
        await Assert.That(matrix.Rows).IsEqualTo(3);
        await Assert.That(matrix.Columns).IsEqualTo(3);
    }

    [Test]
    public async Task SingleElementIdentity()
    {
        MatrixF matrix = MatrixF.CreateIdentity(1);
        await Assert.That(matrix.Rows).IsEqualTo(1);
        await Assert.That(matrix.Columns).IsEqualTo(1);
        await Assert.That(matrix[0, 0]).IsEqualTo(1);
    }

    [Test]
    public async Task IndexerCanSetValues()
    {
        MatrixF matrix = MatrixF.CreateIdentity(2);
        matrix[0, 0] = 4;
        matrix[0, 1] = 7;
        matrix[1, 0] = 2;
        matrix[1, 1] = 6;

        await Assert.That(matrix[0, 0]).IsEqualTo(4);
        await Assert.That(matrix[0, 1]).IsEqualTo(7);
        await Assert.That(matrix[1, 0]).IsEqualTo(2);
        await Assert.That(matrix[1, 1]).IsEqualTo(6);
    }

    [Test]
    public async Task CanMultiplyIdentities()
    {
        MatrixF matrix1 = MatrixF.CreateIdentity(3);
        MatrixF matrix2 = MatrixF.CreateIdentity(3);
        MatrixF matrix3 = MatrixF.CreateIdentity(5);

        await Assert.That(MatrixF.CanMultiply(matrix1, matrix2)).IsTrue();
        await Assert.That(MatrixF.CanMultiply(matrix2, matrix1)).IsTrue();
        
        await Assert.That(MatrixF.CanMultiply(matrix1, matrix3)).IsFalse();
    }

    [Test]
    public async Task MultiplyByIdentity()
    {
        MatrixF value = MatrixF.CreateIdentity(2);
        value[0, 1] = 5;
        value[1, 0] = 3;

        MatrixF result = value * MatrixF.CreateIdentity(2);

        await Assert.That(result[0, 0]).IsEqualTo(1);
        await Assert.That(result[0, 1]).IsEqualTo(5);
        await Assert.That(result[1, 0]).IsEqualTo(3);
        await Assert.That(result[1, 1]).IsEqualTo(1);
    }

    [Test]
    public async Task MultiplyKnownMatrices()
    {
        MatrixF left = MatrixF.CreateIdentity(2);
        left[0, 0] = 1;
        left[0, 1] = 2;
        left[1, 0] = 3;
        left[1, 1] = 4;

        MatrixF right = MatrixF.CreateIdentity(2);
        right[0, 0] = 5;
        right[0, 1] = 6;
        right[1, 0] = 7;
        right[1, 1] = 8;

        MatrixF result = left * right;

        await Assert.That(result.Rows).IsEqualTo(2);
        await Assert.That(result.Columns).IsEqualTo(2);
        await Assert.That(result[0, 0]).IsEqualTo(19);
        await Assert.That(result[0, 1]).IsEqualTo(22);
        await Assert.That(result[1, 0]).IsEqualTo(43);
        await Assert.That(result[1, 1]).IsEqualTo(50);
    }

    [Test]
    public async Task MultiplyMismatchedMatricesThrows()
    {
        MatrixF left = MatrixF.CreateIdentity(2);
        MatrixF right = MatrixF.CreateIdentity(3);

        Assert.Throws<MatrixInvalidMultiplicationException>(() => _ = left * right);
    }
}
