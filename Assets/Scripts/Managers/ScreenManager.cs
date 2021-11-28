using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Manager<ScreenManager>
{
    [SerializeField] private SceneController _controller;

    public void SetScenery(Scenery scenery)
    {
        _controller.SetScenery(scenery);
        scenery.OnFirstEnter();
    }

    public void DoSomethingOnSceneStuff()
    {
        _controller.DoSomethingOnSceneStuff();
    }
}
