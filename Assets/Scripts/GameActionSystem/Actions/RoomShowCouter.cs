using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomShowCouter : GameAction
{
    [SerializeField] private GameAction _onCounterReached = default;
    [SerializeField] private int max = 3;
    private int couter = 0;

    protected override void DoAction()
    {
        base.DoAction();
        couter++;
        if (couter == max)
        {
            if (_onCounterReached != null)
            {
                GameActionManager.Instance.PlayAction(_onCounterReached);
            }
        }
    }
}
