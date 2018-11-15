using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Graph2D : MonoBehaviour
{
    public static readonly Vector2 GraphPlotDimensions = new Vector2(10, 10);
    [SerializeField] private GraphData _Data;
    [SerializeField] private TMP_Text _LabelX;
    [SerializeField] private TMP_Text _LabelY;
    [SerializeField] private TMP_Text _ScaleX;
    [SerializeField] private TMP_Text _ScaleY;
    
    public GraphData Data => _Data;

    private void Start()
    {
        _LabelX.text = _Data.LabelX;
        _LabelY.text = _Data.LabelY;
        _ScaleX.text = $"({_Data.Dismentions.x.ToString()},0)";
        _ScaleY.text = $"(0,{_Data.Dismentions.y.ToString()})";
    }

}

