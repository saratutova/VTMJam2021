using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCredits : GameAction
{

    protected override void DoAction()
    {
        base.DoAction();
        CreditsManager.Instance.SetActive(true);
        CreditsManager.Instance.CreditsEnded.AddListener(() => GameManager.Instance.EndGame());
    }
}
