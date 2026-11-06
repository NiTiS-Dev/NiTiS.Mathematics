using System;
using System.Numerics;

namespace NiTiS.Mathematics;

/// <summary>
/// Set of useful mathematics algorithms.
/// </summary>
public static class Algorithm
{
	/// <summary>
	/// Resolves greatest divisor for <paramref name="a"/> and <paramref name="b"/>.
	/// </summary>
	/// <param name="a">The first argument.</param>
	/// <param name="b">The second argument.</param>
	/// <returns>Greatest common divisor.</returns>
	#if NET10_0_OR_GREATER
	[Obsolete("Use modern extension instead.")]
	#endif
	public static N GreatestCommonDivisor<N>(N a, N b)
		where N : INumberBase<N>, IComparisonOperators<N, N, bool>, IModulusOperators<N, N, N>
	{
		while (true)
		{
			if (b == N.Zero) return a < N.Zero ? -a : a;
			N temp = a;
			a = b;
			b = temp % b;
		}
	}

	/// <summary>
	/// Resolves least multiple for <paramref name="a"/> and <paramref name="b"/>.
	/// </summary>
	/// <param name="a">The first argument.</param>
	/// <param name="b">The second argument.</param>
	/// <returns>Least common multiple.</returns>
	#if NET10_0_OR_GREATER
	[Obsolete("Use modern extension instead.")]
	#endif
	public static N LeastCommonMultiple<N>(N a, N b)
		where N : INumberBase<N>, IComparisonOperators<N, N, bool>, IModulusOperators<N, N, N>
	{
		N lcm = (a / GreatestCommonDivisor(a, b)) * b;
		return lcm > N.Zero ? lcm : -lcm;
	}
}