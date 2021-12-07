using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDialogue : GameAction
{
    [SerializeField] private List<YarnProgram> _dialogues = default;

    protected override void DoAction()
    {
        base.DoAction();

        if (_dialogues.Count > 0)
        {
            var number = Random.Range(0, _dialogues.Count);
            DialogueManager.Instance.StartDialogue(_dialogues[number].name);
            _dialogues.RemoveAt(number);
        }
    }
}
