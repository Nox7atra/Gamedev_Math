using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCameraController : MonoBehaviour
{
	[SerializeField] private Camera _Camera;
	[SerializeField] private float _DistanceFromPlanet = 10;
	[SerializeField] private float _Offset = 5;
	private bool _IsMoving;

	public event Action<Vector3, Vector3, Vector3, float, float> OnMove;
	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !_IsMoving)
		{
			RaycastHit hit;
			Debug.Log("Click");
			var ray = _Camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				Debug.Log("hit");
				var startPosition = _Camera.transform.position;
				var right = Vector3.Cross(hit.normal, Vector3.up).normalized;
				var endPosition = hit.point + hit.normal * _DistanceFromPlanet + right * _Offset;
				StartCoroutine(MoveCoroutine(startPosition, endPosition, hit.point + right * _Offset));
				
				OnMove?.Invoke(startPosition, hit.point, hit.normal, _DistanceFromPlanet, _Offset);
			}
		}
	}

	private IEnumerator MoveCoroutine(Vector3 start, Vector3 end, Vector3 lookAt)
	{
		_IsMoving = true;
		var startForward = transform.forward;
		float timer = 0;
		while (timer < Scenario.AnimTime)
		{

			transform.position = Vector3.Slerp(start, end, timer / Scenario.AnimTime);
			transform.forward = Vector3.Slerp(startForward, (lookAt - transform.position).normalized, 
				timer / Scenario.AnimTime);
			yield return null;
			timer += Time.deltaTime;
		}
		transform.position = end;
		transform.forward = (lookAt - transform.position).normalized;
		_IsMoving = false;
	}
}
