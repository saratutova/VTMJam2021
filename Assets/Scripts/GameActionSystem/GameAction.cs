using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameAction : MonoBehaviour
{
    //[SerializeField] private bool _isOneTime = true;
    [SerializeField] protected bool _withGAM = true;
    [SerializeField] private GameAction _beforeAction = default;
    [SerializeField] private GameAction _afterAction = default;
    public bool isDone = false;

    //[SerializeField] protected bool _wasUsed = false;

    private void BeforeAction()
    {
        if (_beforeAction != null)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(_beforeAction); 
            }
            else
            {
                _beforeAction.Action();
            }
        }
    }

    public void Action()
    {
        //if (_wasUsed && _isOneTime)
        //{
        //    return;
        //}
        BeforeAction();
        DoAction();
        ActerAction();
        //_wasUsed = true;
    }
    
    protected virtual void DoAction()
    {
        
    }

    private void ActerAction()
    {
        if (_afterAction != null)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(_afterAction); 
            }
            else
            {
                _afterAction.Action();
            }
        }
        if (gameObject.activeSelf)
        {
            StartCoroutine(AfterAction()); 
        }
        else
        {
            isDone = true;
        }
    }

    IEnumerator AfterAction()
    {
        yield return new WaitForSeconds(1f);
        isDone = true;
    }
}
