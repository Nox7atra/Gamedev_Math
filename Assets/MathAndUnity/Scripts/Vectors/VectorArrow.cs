using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VectorArrow : MonoBehaviour
{
	[SerializeField] private Vector3 _VectorStart;
	[SerializeField] private Vector3 _VectorEnd;
	[SerializeField] private float TextOffsetY;
	[SerializeField] private TMP_Text _Label;
	[SerializeField] private Color _Color;
	[SerializeField] private LineRenderer _Line;
	[SerializeField] private float _CupLength;
	[SerializeField] private LineRenderer _Cup;

	private void OnValidate()
	{
		UpdateVector();
	}

	private void UpdateVector()
	{
		if(_Line == null || _Cup == null) return;
		
		SetColor(_Color);
		_Line.positionCount = _Cup.positionCount = 2;
		_Line.SetPosition(0, _VectorStart);
		_Line.SetPosition(1, _VectorEnd - (_VectorEnd - _VectorStart).normalized * _CupLength);
	
		_Cup.SetPosition(0, _VectorEnd - (_VectorEnd - _VectorStart).normalized * _CupLength);
		_Cup.SetPosition(1, _VectorEnd );

		if (_Label != null)
		{
			var dv = _VectorEnd - _VectorStart;
			var normal = new Vector3(-dv.y, dv.x).normalized;
			normal = normal.y > 0 ? normal : -normal;
			_Label.transform.localPosition 
				= (_VectorEnd + _VectorStart) / 2
				  + normal * TextOffsetY;
			_Label.transform.up = normal;
		}
	
	}

	public void SetPositions(Vector3 start, Vector3 end)
	{
		_VectorStart = start;
		_VectorEnd = end;
		UpdateVector();
	}

	public void SetLabel(string label)
	{
		_Label.text = label;
	}

	public void SetColor(Color color)
	{
		_Color = color;
		_Line.startColor = _Line.endColor = _Cup.startColor = _Cup.endColor = _Color;
	}
}
