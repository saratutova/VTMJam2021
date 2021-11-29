using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : GameAction
{
    [SerializeField] private Item _item = default;

    protected override void DoAction()
    {
        base.DoAction();
        GameManager.Instance.AddItem(_item);
        Done();
    }
}
