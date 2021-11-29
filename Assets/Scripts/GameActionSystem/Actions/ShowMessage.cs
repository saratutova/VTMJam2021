using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : GameAction
{
    [SerializeField] private List<GameAction> _massageEnded = new List<GameAction>();
    [SerializeField] private StringType type = default;

    protected override void DoAction()
    {
        base.DoAction();
        MessageManager.Instance.SetMessage(StaticStrings.GetString(type));
        MessageManager.Instance.MessageEnded.AddListener(() =>
        {
            FadeManager.Instance.FadeBreak(FadeManager.breakTime);
            FadeManager.Instance.HalfFadeEnded.AddListener(() =>
            {
                MessageManager.Instance.TurnOff();
                if (_massageEnded != null)
                {
                    _massageEnded.ForEach(x => GameActionManager.Instance.PlayAction(x));
                }
                Done();
            });
        }
        );
    }
}
