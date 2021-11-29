using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoList : GameAction
{
    [SerializeField] private List<GameAction> _actions = new List<GameAction>();
    [SerializeField] private bool _withGAM = true;

    protected override void DoAction()
    {
        base.DoAction();
        if (_actions != null)
        {
            if (_withGAM)
            {
                _actions.ForEach(x => GameActionManager.Instance.PlayAction(x));
            }
            else
            {
                _actions.ForEach(x => x.Action());
            }
        }
    }
}
