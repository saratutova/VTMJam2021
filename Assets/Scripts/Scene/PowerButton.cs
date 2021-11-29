using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power
{
    Auspex, Potence, None
}

public class PowerButton : SceneButton
{
    [SerializeField] private Power power;

    protected override void OnRefresh()
    {
        base.OnRefresh();
        _button.interactable = _model.CanUsePower(power);
    }

    protected override void Clicked()
    {
        _controller.PowerButtonClicked(power);
    }
}
