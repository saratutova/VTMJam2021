using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogueAfterWindowDialogue : GameAction
{
    private bool _playedDialogue = false;
    [SerializeField] private GameAction _action = default;

    protected override void DoAction()
    {
        base.DoAction();
        if (!_playedDialogue && SceneStuff.wasWindowDialoge)
        {
            if (_action != null)
            {
                GameActionManager.Instance.PlayAction(_action);
            }
        }
    }
}
