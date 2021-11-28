using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWindowDialogueTrue : GameAction
{
    protected override void DoAction()
    {
        base.DoAction();
        SceneStuff.wasWindowDialoge = true;
    }
}
