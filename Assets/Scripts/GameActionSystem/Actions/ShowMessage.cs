using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : GameAction
{
    public StringType type;

    protected override void DoAction()
    {
        base.DoAction();
        MessageManager.Instance.SetMessage(StaticStrings.GetString(type));
        MessageManager.Instance.MessageEnded.AddListener(() =>
        {
            AudioManager.Instance.PlayClip("Zofi�wka - budzenie si� poprawiony - slajd");
            FadeManager.Instance.FadeBreak(FadeManager.breakTime);
            FadeManager.Instance.HalfFadeEnded.AddListener(() =>
            {
                MessageManager.Instance.TurnOff();
                DialogueManager.Instance.StartDialogue("Test");
            });
        }
        );
    }
}
