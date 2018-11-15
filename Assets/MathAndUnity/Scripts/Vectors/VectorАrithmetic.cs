using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorАrithmetic : Scenario
{
    [SerializeField] private VectorBlock[] _Blocks;

    private int _CurrentBlock = 0;
    public override void Show()
    {
        _Blocks[_CurrentBlock].Show(OnShowed);
    }

    private void OnShowed()
    {
        _CurrentBlock++;
        if (_CurrentBlock < _Blocks.Length)
        {
            _Blocks[_CurrentBlock].gameObject.SetActive(true);
            _Blocks[_CurrentBlock].Show(OnShowed);
        }
        else
        {
            ScreenCapture.CaptureScreenshot("vector-arith.png");
            OnEnd?.Invoke();
            Hide();
        }
    }
    public override void Hide()
    {
        StartCoroutine(HideCoroutine());
    }

    private IEnumerator HideCoroutine()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < _Blocks.Length; i++)
        {
            _Blocks[i].gameObject.SetActive(false);
        }
    }
}
