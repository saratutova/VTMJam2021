using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Power
{
    Auspex, Potence
}

public class PowerButton : SceneButton
{
    [SerializeField] private Power power;

    protected override void OnRefresh()
    {
        base.OnRefresh();
    }

    protected override void Clicked()
    {
        base.Clicked();
    }
}
