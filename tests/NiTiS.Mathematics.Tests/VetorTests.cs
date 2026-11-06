using System;
using System.Numerics;
using System.Threading.Tasks;

namespace NiTiS.Mathematics.Tests;

public class VetorTests
{
	[Test]
	public async Task BinaryOperators()
	{
		Vector2<int> x = Vector2<int>.UnitX;
		Vector2<int> y = Vector2<int>.UnitY;
		_ = x ^ y;
		_ = x | y;
		_ = x & y;
		_ = x + y;
		_ = x - y;
		_ = x * y;
		Assert.Throws<DivideByZeroException>(() =>
		{
			_ = x / y;
		});
		Assert.Throws<DivideByZeroException>(() =>
		{
			_ = y / x;
		});
		Assert.Throws<DivideByZeroException>(() =>
		{
			_ = y % x;
		});
	}

	[Test]
	public async Task Vector2Arithmetic()
	{
		Vector2<int> left = new(6, 8);
		Vector2<int> right = new(2, 4);

		await Assert.That(left + right).IsEqualTo(new Vector2<int>(8, 12));
		await Assert.That(left - right).IsEqualTo(new Vector2<int>(4, 4));
		await Assert.That(left * right).IsEqualTo(new Vector2<int>(12, 32));
		await Assert.That(left / right).IsEqualTo(new Vector2<int>(3, 2));
		await Assert.That(left % right).IsEqualTo(new Vector2<int>(0, 0));
	}

	[Test]
	public async Task Vector2ScalarArithmetic()
	{
		Vector2<int> vector = new(2, 3);

		await Assert.That(vector * 2).IsEqualTo(new Vector2<int>(4, 6));
		await Assert.That(2 * vector).IsEqualTo(new Vector2<int>(4, 6));
		await Assert.That(vector / 2).IsEqualTo(new Vector2<int>(1, 1));
		await Assert.That(12 / vector).IsEqualTo(new Vector2<int>(6, 4));
		await Assert.That(vector % 2).IsEqualTo(new Vector2<int>(0, 1));
		await Assert.That(7 % vector).IsEqualTo(new Vector2<int>(1, 1));
	}

	[Test]
	public async Task Vector2Equality()
	{
		Vector2<int> vector = new(1, 2);

		await Assert.That(vector).IsEqualTo(new Vector2<int>(1, 2));
		await Assert.That(vector == new Vector2<int>(1, 2)).IsTrue();
		await Assert.That(vector != new Vector2<int>(2, 1)).IsTrue();
		await Assert.That(vector.Equals(new Vector2<int>(1, 2))).IsTrue();
		await Assert.That(vector.GetHashCode()).IsEqualTo(new Vector2<int>(1, 2).GetHashCode());
	}

	[Test]
	public async Task Vector2MinMaxClamp()
	{
		Vector2<int> left = new(1, 8);
		Vector2<int> right = new(5, 3);

		await Assert.That(Vector2<int>.Min(left, right)).IsEqualTo(new Vector2<int>(1, 3));
		await Assert.That(Vector2<int>.Max(left, right)).IsEqualTo(new Vector2<int>(5, 8));
		await Assert.That(Vector2<int>.Clamp(new Vector2<int>(-4, 20), new Vector2<int>(0, 0), new Vector2<int>(4, 4))).IsEqualTo(new Vector2<int>(0, 4));
	}

	[Test]
	public async Task Vector2Units()
	{
		await Assert.That(Vector2<int>.Zero).IsEqualTo(new Vector2<int>(0, 0));
		await Assert.That(Vector2<int>.UnitX).IsEqualTo(new Vector2<int>(1, 0));
		await Assert.That(Vector2<int>.UnitY).IsEqualTo(new Vector2<int>(0, 1));
	}

	[Test]
	public async Task Vector2BitwiseOperators()
	{
		Vector2<int> left = new(6, 3);
		Vector2<int> right = new(3, 5);

		await Assert.That(left | right).IsEqualTo(new Vector2<int>(7, 7));
		await Assert.That(left & right).IsEqualTo(new Vector2<int>(2, 1));
		await Assert.That(left ^ right).IsEqualTo(new Vector2<int>(5, 6));
	}

	[Test]
	public async Task Vector2Length()
	{
		Vector2<float> vector = new(3, 4);

		await Assert.That(Vector2Extensions.LengthSquared(vector)).IsEqualTo(25f);
		await Assert.That(Vector2Extensions.Length(vector)).IsEqualTo(5f);
	}

	[Test]
	public async Task Vector3Arithmetic()
	{
		Vector3<int> left = new(6, 8, 10);
		Vector3<int> right = new(2, 4, 5);

		await Assert.That(left + right).IsEqualTo(new Vector3<int>(8, 12, 15));
		await Assert.That(left - right).IsEqualTo(new Vector3<int>(4, 4, 5));
		await Assert.That(left * right).IsEqualTo(new Vector3<int>(12, 32, 50));
		await Assert.That(left / right).IsEqualTo(new Vector3<int>(3, 2, 2));
		await Assert.That(left % right).IsEqualTo(new Vector3<int>(0, 0, 0));
	}

	[Test]
	public async Task Vector3ScalarArithmetic()
	{
		Vector3<int> vector = new(2, 3, 4);

		await Assert.That(vector * 3).IsEqualTo(new Vector3<int>(6, 9, 12));
		await Assert.That(3 * vector).IsEqualTo(new Vector3<int>(6, 9, 12));
		await Assert.That(vector / 2).IsEqualTo(new Vector3<int>(1, 1, 2));
		await Assert.That(12 / vector).IsEqualTo(new Vector3<int>(6, 4, 3));
	}

	[Test]
	public async Task Vector3MinMaxClamp()
	{
		Vector3<int> left = new(1, 8, 4);
		Vector3<int> right = new(5, 3, 9);

		await Assert.That(Vector3<int>.Min(left, right)).IsEqualTo(new Vector3<int>(1, 3, 4));
		await Assert.That(Vector3<int>.Max(left, right)).IsEqualTo(new Vector3<int>(5, 8, 9));
		await Assert.That(Vector3<int>.Clamp(new Vector3<int>(-4, 20, 6), new Vector3<int>(0, 0, 0), new Vector3<int>(4, 8, 8))).IsEqualTo(new Vector3<int>(0, 8, 6));
	}

	[Test]
	public async Task Vector3BitwiseOperators()
	{
		Vector3<int> left = new(6, 3, 12);
		Vector3<int> right = new(3, 5, 10);

		await Assert.That(left | right).IsEqualTo(new Vector3<int>(7, 7, 14));
		await Assert.That(left & right).IsEqualTo(new Vector3<int>(2, 1, 8));
		await Assert.That(left ^ right).IsEqualTo(new Vector3<int>(5, 6, 6));
	}

	[Test]
	public async Task Vector3Length()
	{
		Vector3<float> vector = new(2, 3, 6);

		await Assert.That(Vector3Extensions.LengthSquared(vector)).IsEqualTo(49f);
		await Assert.That(Vector3Extensions.Length(vector)).IsEqualTo(7f);
	}

	[Test]
	public async Task Vector4Arithmetic()
	{
		Vector4<int> left = new(6, 8, 10, 12);
		Vector4<int> right = new(2, 4, 5, 3);

		await Assert.That(left + right).IsEqualTo(new Vector4<int>(8, 12, 15, 15));
		await Assert.That(left - right).IsEqualTo(new Vector4<int>(4, 4, 5, 9));
		await Assert.That(left * right).IsEqualTo(new Vector4<int>(12, 32, 50, 36));
		await Assert.That(left / right).IsEqualTo(new Vector4<int>(3, 2, 2, 4));
		await Assert.That(left % right).IsEqualTo(new Vector4<int>(0, 0, 0, 0));
	}

	[Test]
	public async Task Vector4ScalarArithmetic()
	{
		Vector4<int> vector = new(2, 3, 4, 6);

		await Assert.That(vector * 3).IsEqualTo(new Vector4<int>(6, 9, 12, 18));
		await Assert.That(3 * vector).IsEqualTo(new Vector4<int>(6, 9, 12, 18));
		await Assert.That(vector / 2).IsEqualTo(new Vector4<int>(1, 1, 2, 3));
		await Assert.That(12 / vector).IsEqualTo(new Vector4<int>(6, 4, 3, 2));
	}

	[Test]
	public async Task Vector4MinMaxClamp()
	{
		Vector4<int> left = new(1, 8, 4, 7);
		Vector4<int> right = new(5, 3, 9, 2);

		await Assert.That(Vector4<int>.Min(left, right)).IsEqualTo(new Vector4<int>(1, 3, 4, 2));
		await Assert.That(Vector4<int>.Max(left, right)).IsEqualTo(new Vector4<int>(5, 8, 9, 7));
		await Assert.That(Vector4<int>.Clamp(new Vector4<int>(-4, 20, 6, 0), new Vector4<int>(0, 0, 0, 0), new Vector4<int>(4, 8, 8, 4))).IsEqualTo(new Vector4<int>(0, 8, 6, 0));
	}

	[Test]
	public async Task Vector4Units()
	{
		await Assert.That(Vector4<int>.Zero).IsEqualTo(new Vector4<int>(0, 0, 0, 0));
		await Assert.That(Vector4<int>.UnitX).IsEqualTo(new Vector4<int>(1, 0, 0, 0));
		await Assert.That(Vector4<int>.UnitY).IsEqualTo(new Vector4<int>(0, 1, 0, 0));
		await Assert.That(Vector4<int>.UnitZ).IsEqualTo(new Vector4<int>(0, 0, 1, 0));
		await Assert.That(Vector4<int>.UnitW).IsEqualTo(new Vector4<int>(0, 0, 0, 1));
	}

	[Test]
	public async Task Vector4BitwiseOperators()
	{
		Vector4<int> left = new(6, 3, 12, 9);
		Vector4<int> right = new(3, 5, 10, 6);

		await Assert.That(left | right).IsEqualTo(new Vector4<int>(7, 7, 14, 15));
		await Assert.That(left & right).IsEqualTo(new Vector4<int>(2, 1, 8, 0));
		await Assert.That(left ^ right).IsEqualTo(new Vector4<int>(5, 6, 6, 15));
	}

	[Test]
	public async Task Vector4Length()
	{
		Vector4<float> vector = new(1, 2, 2, 4);

		await Assert.That(Vector4Extensions.LengthSquared(vector)).IsEqualTo(25f);
		await Assert.That(Vector4Extensions.Length(vector)).IsEqualTo(5f);
	}

	[Test]
	public async Task SpanConstructors()
	{
		Vector2<int> vector2 = new(new int[] { 1, 2 });
		Vector3<int> vector3 = new(new int[] { 1, 2, 3 });
		Vector4<int> vector4 = new(new int[] { 1, 2, 3, 4 });

		await Assert.That(vector2).IsEqualTo(new Vector2<int>(1, 2));
		await Assert.That(vector3).IsEqualTo(new Vector3<int>(1, 2, 3));
		await Assert.That(vector4).IsEqualTo(new Vector4<int>(1, 2, 3, 4));

		Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Vector2<int>(new int[] { 1 }));
		Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Vector3<int>(new int[] { 1, 2 }));
		Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Vector4<int>(new int[] { 1, 2, 3 }));
	}

	[Test]
	public async Task FirstRefPointsToFirstComponent()
	{
		Vector3<int> vector = new(1, 2, 3);

		vector.FirstRef = 42;

		await Assert.That(vector.X).IsEqualTo(42);
		await Assert.That(vector).IsEqualTo(new Vector3<int>(42, 2, 3));
	}
}
