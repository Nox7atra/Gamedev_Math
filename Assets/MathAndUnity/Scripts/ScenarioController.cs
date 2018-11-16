using System.Collections;
using System.Collections.Generic;
using Moments;
using TMPro;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{
	[SerializeField] private Recorder _Recorder;
	[SerializeField] private TMP_Text _Title;
	[SerializeField] private Scenario[] _Scenarios;

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
		LaunchScenario();

	}


	private void LaunchScenario()
	{
		_Scenarios[_CurrentScenario].Show();
		_Title.text = _Scenarios[_CurrentScenario].Title;
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
				LaunchScenario();
			}
			else
			{
				Debug.Log("The end!");
			}
		};
	
	}

	private void OnScenarioEnd()
	{
		_CurrentScenario++;
		if (_CurrentScenario < _Scenarios.Length)
		{
			Debug.Log(_Scenarios[_CurrentScenario].Title + " started!");
			_Scenarios[_CurrentScenario].OnEnd += OnScenarioEnd;
			LaunchScenario();
		}
	}
}
