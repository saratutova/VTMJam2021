using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeArrowVisiblility : GameAction
{
    [SerializeField] private bool value = true;

    protected override void DoAction()
    {
        base.DoAction();
        ScreenManager.Instance.ShouldArrowsBeVisible = value;
        Done();
    }
}
