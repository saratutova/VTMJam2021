using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomethingOnSceneStuff : GameAction
{
    [SerializeField] private string stuffName = default;

    protected override void DoAction()
    {
        base.DoAction();
        ScreenManager.Instance.DoSomethingOnSceneStuff(stuffName);
    }
}
