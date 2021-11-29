using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBool : GameAction
{
    [SerializeField] private GameAction _action = default;
    [SerializeField] private string _checkName = default;
    private bool _used = false;

    protected override void DoAction()
    {
        base.DoAction();
        if (!_used && GameManager.Instance.CheckBoolValue(_checkName))
        {
            _used = true;
            if (_action != null)
            {
                GameActionManager.Instance.PlayAction(_action);
            }
        }
    }
}
