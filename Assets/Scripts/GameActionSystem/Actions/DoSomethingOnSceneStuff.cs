using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomethingOnSceneStuff : GameAction
{
    protected override void DoAction()
    {
        base.DoAction();
        ScreenManager.Instance.DoSomethingOnSceneStuff();
    }
}
