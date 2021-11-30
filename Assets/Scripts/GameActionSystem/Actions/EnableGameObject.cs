using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObject : GameAction
{
    [SerializeField] private GameObject _object = default;

    protected override void DoAction()
    {
        base.DoAction();
        _object.SetActive(true);
        Done();
    }
}
