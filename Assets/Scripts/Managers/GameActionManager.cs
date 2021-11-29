using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionManager : Manager<GameActionManager>
{
    //private List<GameAction> actions = new List<GameAction>();

    public void PlayAction(GameAction action)
    {
        var newAction = Instantiate(action, transform);
        newAction.Action();
        //actions.Add(newAction);
        //RefreshActions();
    }

    public void RefreshActions()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
