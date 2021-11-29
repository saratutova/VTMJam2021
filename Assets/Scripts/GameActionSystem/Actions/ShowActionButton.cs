using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowActionButton : GameAction
{
    [SerializeField] private Canvas _canvas = default;

    protected override void DoAction()
    {
        base.DoAction();
        _canvas.worldCamera = FadeManager.Instance.Camera;
        _canvas.gameObject.SetActive(true);
        Done();
    }
}
