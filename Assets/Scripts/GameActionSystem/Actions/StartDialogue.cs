using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : GameAction
{
    [SerializeField] private string _dialogueName = "";

    protected override void DoAction()
    {
        base.DoAction();
        DialogueManager.Instance.StartDialogue(_dialogueName);
    }
}
