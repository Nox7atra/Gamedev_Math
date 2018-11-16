using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorNormalBlock : VectorBlock 
{
	[SerializeField] private VectorArrow _VectorA;
	[SerializeField] private VectorArrow _VectorB;
	[SerializeField] private VectorArrow _VectorC;
	[SerializeField] private VectorArrow _VectorNormal;
	[SerializeField] private VectorArrow _VectorD;
	[SerializeField] private Vector3 _VectorAPosition;
	[SerializeField] private Vector3 _VectorBPosition;
	
	public override void Show(Action onFinish)
	{
		_VectorA.SetLabel("point1");
		_VectorB.SetLabel("point2");
		_VectorC.SetLabel("");
		_VectorD.SetLabel("equal");
		_VectorNormal.SetLabel("normal");
		_VectorA.gameObject.SetActive(true);
		_VectorB.gameObject.SetActive(false);
		_VectorC.gameObject.SetActive(false);
		_VectorD.gameObject.SetActive(false);
		_VectorNormal.gameObject.SetActive(false);
		StartCoroutine(ShowCoroutine(onFinish));
	}
	private IEnumerator ShowCoroutine(Action onFinish)
	{
		yield return UtilityCoroutines.LerpCoroutine(_VectorA, Vector3.zero, _VectorAPosition, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		_VectorB.gameObject.SetActive(true);
		yield return UtilityCoroutines.LerpCoroutine(_VectorB, Vector3.zero, _VectorBPosition, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		_VectorC.gameObject.SetActive(true);
		yield return UtilityCoroutines.LerpCoroutine(_VectorC, Vector3.zero,
			_VectorAPosition + _VectorBPosition, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		_VectorD.gameObject.SetActive(true);
		var dv = _VectorAPosition + _VectorBPosition;
		yield return UtilityCoroutines.LerpCoroutine(_VectorD.transform, Vector3.zero, 
			(_VectorAPosition + _VectorBPosition) / 2, Scenario.AnimTime);
		yield return UtilityCoroutines.LerpCoroutine(_VectorD, Vector3.zero, 
			(_VectorAPosition + _VectorBPosition) / 2 - _VectorBPosition, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		yield return UtilityCoroutines.LerpCoroutine(_VectorD.transform, _VectorD.transform.localPosition, 
			_VectorBPosition, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime / 5);
		
		_VectorNormal.gameObject.SetActive(true);
		yield return UtilityCoroutines.LerpCoroutine(_VectorNormal.transform, Vector3.zero,
			(_VectorAPosition + _VectorBPosition) / 2, Scenario.AnimTime);
		yield return UtilityCoroutines.LerpCoroutine(_VectorNormal, Vector3.zero, 
			new Vector3(-dv.y, dv.x).normalized, Scenario.AnimTime);
		yield return new WaitForSeconds(Scenario.AnimTime * 2);
		onFinish?.Invoke();
	}
}
