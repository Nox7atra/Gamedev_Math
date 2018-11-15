using System.Collections;
using System.Collections.Generic;
using Moments;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
	[SerializeField] private Scenario[] _Scenarios;
	[SerializeField] private Recorder _Recorder;
	[SerializeField] private bool _IsRecord;
	private int _CurrentScenario = 0;
	
	private void Start ()
	{
		_Recorder.Record();
		if (_IsRecord)
		{
			_Scenarios[_CurrentScenario].OnEnd += OnScenarioRecordEnd;
		}
		else
		{
			_Scenarios[_CurrentScenario].OnEnd += OnScenarioEnd;
		}
		
		_Scenarios[_CurrentScenario].Show();
		

	}

	private void OnScenarioRecordEnd()
	{
		_Recorder.Save(_Scenarios[_CurrentScenario].Title);
		_Recorder.OnFileSaved += (id, filename) =>
		{
			Debug.Log(filename + " saved!");
			_CurrentScenario++;
			if (_CurrentScenario < _Scenarios.Length)
			{
				_Recorder.Record();
				Debug.Log(_Scenarios[_CurrentScenario].Title + " started!");
				_Scenarios[_CurrentScenario].OnEnd += OnScenarioRecordEnd;
				_Scenarios[_CurrentScenario].Show();

			}
			else
			{
				Debug.Log("The end!");
			}
		};
	
	}

	private void OnScenarioEnd()
	{
		
	}
}
