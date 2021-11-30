using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeAnimation : GameAction
{
    [SerializeField] private GameAction _action = default;
    public Animator animator;

    protected override void DoAction()
    {
        base.DoAction();
        animator.Play("New Animation");
    }

    public void FinishedAnimation()
    {
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
