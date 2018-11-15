using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scenario : MonoBehaviour
{
    public const float AnimTime = 0.5f;
    public Action OnEnd;
    public string Title;
    public string Description;
    public abstract void Show();
    public abstract void Hide();
}
