using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorPlusBlock : VectorBlock
{
	[SerializeField] private VectorArrow _VectorA;
	[SerializeField] private VectorArrow _VectorB;
	[SerializeField] private VectorArrow _VectorResult;
	[SerializeField] private Vector3 _VectorAPosition;
	[SerializeField] private Vector3 _VectorBPosition;
	[SerializeField] private float _AnimTime;

	public void Show(Action onFinish)
	{
		_VectorA.SetLabel("a");
		_VectorB.SetLabel("b");
		_VectorResult.SetLabel("a+b");
		_VectorA.gameObject.SetActive(true);
		_VectorB.gameObject.SetActive(false);
		_VectorResult.gameObject.SetActive(false);
		StartCoroutine(ShowCoroutine(onFinish));
	}


	private IEnumerator ShowCoroutine(Action onFinish)
	{
		yield return UtilityCoroutines.LerpCoroutine(_VectorA, Vector3.zero, _VectorAPosition, _AnimTime);
		yield return new WaitForSeconds(_AnimTime / 5);
		_VectorB.gameObject.SetActive(true);
		yield return UtilityCoroutines.LerpCoroutine(_VectorB, Vector3.zero, _VectorBPosition, _AnimTime);
		yield return new WaitForSeconds(_AnimTime / 5);
		_VectorResult.gameObject.SetActive(true);
		yield return UtilityCoroutines.LerpCoroutine(_VectorResult, Vector3.zero, _VectorAPosition + _VectorBPosition, 
			_AnimTime);
		yield return new WaitForSeconds(_AnimTime / 5);
		yield return UtilityCoroutines.LerpCoroutine(_VectorB.transform, Vector3.zero, _VectorAPosition,
			_AnimTime);
		yield return new WaitForSeconds(_AnimTime);
		onFinish?.Invoke();
	}
}
