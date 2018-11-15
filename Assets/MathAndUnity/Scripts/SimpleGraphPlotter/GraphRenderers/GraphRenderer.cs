using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GraphRenderer : MonoBehaviour
{
	[SerializeField] protected int _PointsCount = 20;
	[SerializeField] private float YOffset;
	[SerializeField] private int _Order;
	[SerializeField] protected Color _Color;
	
	protected Graph2D _Graph2D;

	protected virtual void Start()
	{
		_Graph2D = GetComponent<Graph2D>();
		CreateGraph();
	}

	protected Vector3 GetPointPosition(int index, int pointsCount, float point)
	{
		var dimensions = _Graph2D.Data.Dismentions;
		float x = (float) index / (pointsCount - 1) * Graph2D.GraphPlotDimensions.x / dimensions.x;
		
		float height = point / dimensions.y * Graph2D.GraphPlotDimensions.y + YOffset;
		return new Vector3(x, height, -_Order);
	}
	protected abstract void CreateGraph();
}
