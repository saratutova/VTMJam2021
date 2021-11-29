using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Manager<ScreenManager>
{
    [SerializeField] private SceneController _controller;

    public bool IsUsingPotence => _controller.IsUsingPotence;
    public bool IsUsingAuspex => _controller.IsUsingAuspex;

    public bool ShouldArrowsBeVisible
    {
        get => _shouldArrowsBeVisible;
        set
        {
            _shouldArrowsBeVisible = value;
            _controller.ForceRefresh();
        }
    }
    private bool _shouldArrowsBeVisible = true;

    public void SetScenery(Scenery scenery)
    {
        _controller.SetScenery(scenery);
        scenery.OnFirstEnter();
        GameActionManager.Instance.RefreshActions();
    }

    public void DoSomethingOnSceneStuff(string stuffName)
    {
        _controller.DoSomethingOnSceneStuff(stuffName);
    }
}
