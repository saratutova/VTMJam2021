using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFocus : GameAction
{
    [SerializeField] private int value = 0;

    protected override void DoAction()
    {
        base.DoAction();
        GameManager.Instance.ChangeFocus(value);
    }

}
