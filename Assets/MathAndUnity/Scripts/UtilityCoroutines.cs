using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityCoroutines 
{
	public static IEnumerator LerpCoroutine(VectorArrow arrow, Vector3 start, Vector3 end, float animtime)
	{
		float timer = 0;
		while (timer < animtime)
		{
			arrow.SetPositions(start, Vector3.Lerp(start, end, timer / animtime));
			yield return null;
			timer += Time.deltaTime;
		}
		arrow.SetPositions(start, end);
	}
	public static IEnumerator LerpCoroutine(Transform tr, Vector3 start, Vector3 end, float animtime)
	{
		float timer = 0;
		while (timer < animtime)
		{
			tr.localPosition = Vector3.Lerp(start, end, timer / animtime);
			yield return null;
			timer += Time.deltaTime;
		}
		tr.localPosition = end;
	}
}
