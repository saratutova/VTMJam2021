using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAButton : SceneButton
{
    [SerializeField] private GameAction _action = default;

    protected override void Start()
    {
        _model = ScreenManager.Instance.GetSceneModel();
        _controller = ScreenManager.Instance.GetSceneController();
        base.Start();
    }

    protected override void Clicked()
    {
        if (_action != null)
        {
            _action.Action();
        }
    }
}
