using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	private const int Iterations = 1000;
	public static float GetApproxSquareAnimCurve(AnimationCurve curve)
	{
		float square = 0;
		for (int i = 0; i <= Iterations; i++)
		{
			square += curve.Evaluate((float) i / Iterations);
		}
		return square / Iterations;
	}
}
