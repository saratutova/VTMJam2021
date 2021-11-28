using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{
    [SerializeField] private bool _isOneTime = true;
    [SerializeField] private GameAction _beforeAction = default;
    [SerializeField] private GameAction _afterAction = default;

    [SerializeField] protected bool _wasUsed = false;

    private void BeforeAction()
    {
        if (_beforeAction != null)
        {
            _beforeAction.Action();
        }
    }

    public void Action()
    {
        if (_wasUsed && _isOneTime)
        {
            return;
        }
        BeforeAction();
        DoAction();
        ActerAction();
        _wasUsed = true;
    }
    
    protected virtual void DoAction()
    {
        
    }

    private void ActerAction()
    {
        if (_afterAction != null)
        {
            _afterAction.Action();
        }
    }
}
