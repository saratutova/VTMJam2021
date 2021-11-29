using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GAList
{
    public List<GameAction> actions = new List<GameAction>();
}

public class DoDifferentGAOnAction : GameAction
{
    [SerializeField] private List<GAList> actions = new List<GAList>();

    private int index = 0;

    protected override void DoAction()
    {
        base.DoAction();
        if (index >= actions.Count)
        {
            return;
        }
        actions[index].actions.ForEach(x => GameActionManager.Instance.PlayAction(x));
        index++;
    }
}
