using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "default_data.asset", menuName = "Create Graph Data")]
public class GraphData : ScriptableObject
{
	public string LabelX;
	public string LabelY;
	public Vector2Int Dismentions;
	
	[SerializeField] private AnimationCurve _AnimationCurve;

	public float[] GetPoints(int count)
	{
		var result = new float[count];
		for (int i = 0; i < count; i++)
		{
			result[i] = _AnimationCurve.Evaluate((float) i / (count - 1)) * Dismentions.y;
		}

		return result;
	}

}

