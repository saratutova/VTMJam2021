using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenery : GameAction
{
    [SerializeField] private Scenery _scenery = default;

    protected override void DoAction()
    {
        FadeManager.Instance.FadeBreak(FadeManager.breakTime);
        FadeManager.Instance.HalfFadeEnded.AddListener(() => ScreenManager.Instance.SetScenery(_scenery));
    }
}
