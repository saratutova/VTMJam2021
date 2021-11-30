using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : GameAction
{
    [SerializeField] private Item _item = default;

    protected override void DoAction()
    {
        base.DoAction();
        GameManager.Instance.RemoveItem(_item);
        Done();
    }
}