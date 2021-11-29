using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionManager : Manager<GameActionManager>
{
    private List<GameAction> actions = new List<GameAction>();

    public void PlayAction(GameAction action)
    {
        var newAction = Instantiate(action, transform);
        newAction.Action();
        actions.Add(newAction);
        //RefreshActions();
    }

    private void RefreshActions()
    {
        for (int i = actions.Count - 1; i >= 0; i--)
        {
            if (actions[i].isDone)
            {
                Destroy(actions[i].gameObject);
            }
        }
    }
}
