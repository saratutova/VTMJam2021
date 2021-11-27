using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SceneButton : SceneUIView
{
    [SerializeField] protected Button _button = default;

    protected override void Start()
    {
        base.Start();
        _button.onClick.AddListener(Clicked);
    }

    protected virtual void Clicked()
    {
        throw new NotImplementedException();
    }
}
