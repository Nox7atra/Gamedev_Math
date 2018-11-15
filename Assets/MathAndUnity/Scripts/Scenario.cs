using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scenario : MonoBehaviour
{
    public event Action OnEnd;
    public string Title;
    public string Description;
    public abstract void Show();
    public abstract void Hide();
}
