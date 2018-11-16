using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGraphRenderer : GraphRenderer
{
    [SerializeField] private float _LineWidth;
    private LineRenderer _Line;
    
    protected override void CreateGraph()
    {
        var go = new GameObject("Line");
        go.layer = 5;
        go.transform.SetParent(_Graph2D.transform);
        go.transform.localPosition = Vector3.zero;
        _Line = go.AddComponent<LineRenderer>();
        _Line.material = new Material(Shader.Find("Sprites/Default"));
        _Line.useWorldSpace = false;
        _Line.widthCurve = new AnimationCurve()
        {
            keys = new Keyframe[]
            {
                new Keyframe(0, _LineWidth), 
            }
        };
        var points = _Graph2D.Data.GetPoints(_PointsCount);
        
        _Line.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i];
            var pointPos = GetPointPosition(i, points.Length, point);
            _Line.SetPosition(i, pointPos);
            _Line.startColor = _Line.endColor = _Color;
        }
    }
    
}
