using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBool : GameAction
{
    [SerializeField] private string _checkName = default;
    [SerializeField] private bool _value = default;
    private bool _used = false;

    protected override void DoAction()
    {
        base.DoAction();
        if (!_used)
        {
            _used = true;
            GameManager.Instance.SetBool(_checkName, _value);
        }
    }
}
