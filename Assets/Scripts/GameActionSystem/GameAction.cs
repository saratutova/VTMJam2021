using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{
    [SerializeField] private GameAction _beforeAction = default;
    [SerializeField] private GameAction _afterAction = default;

    private void BeforeAction()
    {
        if (_beforeAction != null)
        {
            _beforeAction.Action();
        }
    }

    public void Action()
    {
        BeforeAction();
        DoAction();
        ActerAction();
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
