using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Graph2D))]
public class HistogramGraphRenderer : GraphRenderer
{
	protected override void CreateGraph()
	{
		var points = _Graph2D.Data.GetPoints(_PointsCount);
		for(int i = 0; i < points.Length; i++)
		{
			var point = points[i];
			var go = GameObject.CreatePrimitive(PrimitiveType.Quad);
			go.transform.SetParent(_Graph2D.transform);

			var pointPos = GetPointPosition(i, points.Length, point);
			go.transform.localPosition = new Vector3(pointPos.x, pointPos.y / 2, pointPos.z);
			go.transform.localScale
				= new Vector3(Graph2D.GraphPlotDimensions.x / _PointsCount, pointPos.y, 1);
			go.GetComponent<MeshRenderer>().material.color = _Color ;
		}
	}
}
