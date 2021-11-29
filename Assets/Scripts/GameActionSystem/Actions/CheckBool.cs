using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBool : GameAction
{
    [SerializeField] private GameAction _action = default;
    [SerializeField] private bool _valueToCompare = true;
    [SerializeField] private string _checkName = default;
    //[SerializeField] private bool _withGAM = true;
    private bool _used = false;

    protected override void DoAction()
    {
        base.DoAction();
        if (!_used && GameManager.Instance.CheckBoolValue(_checkName) == _valueToCompare)
        {
            _used = true;
            if (_action != null)
            {
                if (_withGAM)
                {
                    GameActionManager.Instance.PlayAction(_action); 
                }
                else
                {
                    _action.Action();
                }
            }
            Done();
        }
    }
}
