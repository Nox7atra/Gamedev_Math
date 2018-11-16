using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveObject : MonoBehaviour
{
	[SerializeField] private Transform _Target;

	[SerializeField] private GraphData _Data;

	private Rigidbody _Rigidbody;
	private void Start()
	{
		_Rigidbody = GetComponent<Rigidbody>();
		Move(2f, _Data.AnimationCurve);
	}

	public void Move(float time, AnimationCurve speedLaw)
	{
		StartCoroutine(MovingCoroutine(time, speedLaw));
	}

	private IEnumerator MovingCoroutine(float time, AnimationCurve speedLaw)
	{
		float timer = 0;
		var dv = (_Target.position - transform.position);
		var distance = dv.magnitude;
		var direction = dv.normalized;
		var speedK = distance / (Utils.GetApproxSquareAnimCurve(speedLaw) * time);
	
		while (timer < time)
		{
			_Rigidbody.velocity = speedLaw.Evaluate(timer / time) * direction * speedK;
			yield return new WaitForFixedUpdate();
			timer += Time.fixedDeltaTime;
		}

		_Rigidbody.isKinematic = true;

	}
}