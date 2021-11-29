using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : GameAction
{
    [SerializeField] private string _dialogueName = default;
    [SerializeField] private GameAction _dialogueEnded = default;

    protected override void DoAction()
    {
        base.DoAction();
        DialogueManager.Instance.StartDialogue(_dialogueName);
        DialogueManager.Instance.DialogueCompleted.AddListener(() =>
        {
            StartCoroutine(AfterDialogue());
        });
    }

    IEnumerator AfterDialogue()
    {
        yield return new WaitForEndOfFrame();
        if (_dialogueEnded != null)
        {
            GameActionManager.Instance.PlayAction(_dialogueEnded);
        }
        Done();
    }
}
