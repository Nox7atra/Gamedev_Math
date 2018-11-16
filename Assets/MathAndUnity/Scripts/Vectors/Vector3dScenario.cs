using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3dScenario : Scenario
{
	[SerializeField] private Camera _MainCamera;
	[SerializeField] private SphereCameraController _ScenarioCamera;
	[SerializeField] private Camera _VectorPreview;
	[SerializeField] private VectorArrow _VectorArrowPrefab;
	public override void Show()
	{
		_MainCamera.clearFlags = CameraClearFlags.Depth;
		_ScenarioCamera.gameObject.SetActive(true);
		_VectorPreview.gameObject.SetActive(true);
		_ScenarioCamera.OnMove += ShowCalculations;
	}
	
	public override void Hide()
	{
		_MainCamera.clearFlags = CameraClearFlags.SolidColor;
		_ScenarioCamera.gameObject.SetActive(false);
		_VectorPreview.gameObject.SetActive(false);
	}

	public void ShowCalculations(Vector3 startPosition, Vector3 hitpoint, Vector3 hitnormal, 
		float distanceFromPlanet, float offset)
	{
		StartCoroutine(ShowCalculationsCoroutine(startPosition, hitpoint, hitnormal, distanceFromPlanet, offset));
	}

	private IEnumerator ShowCalculationsCoroutine(Vector3 startPosition, Vector3 hitpoint, Vector3 hitnormal, 
		float distanceFromPlanet, float offset)
	{
		var right = Vector3.Cross(hitnormal, Vector3.up).normalized;
		var normalOffset = hitpoint + hitnormal * distanceFromPlanet;
		var endPosition =  normalOffset + right * offset;
		var vectorRay = Instantiate(_VectorArrowPrefab);
		vectorRay.SetLabel("raycast");
		vectorRay.SetColor(Color.green);
		yield return UtilityCoroutines.LerpCoroutine(vectorRay, startPosition, hitpoint, AnimTime);
		var vectorNormal = Instantiate(_VectorArrowPrefab);
		vectorNormal.SetLabel("hit normal * distance from planet");
		yield return UtilityCoroutines.LerpCoroutine(vectorNormal, hitpoint,
			normalOffset, AnimTime);
		var vectorOffset = Instantiate(_VectorArrowPrefab);
		vectorOffset.SetLabel("offset");
		yield return UtilityCoroutines.LerpCoroutine(vectorOffset, normalOffset,
			endPosition, AnimTime);
	}
}
