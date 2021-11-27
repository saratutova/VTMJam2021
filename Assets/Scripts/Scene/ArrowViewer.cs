using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArrowSide
{
    Right, Left
}

public class ArrowViewer : SceneButton
{
    [SerializeField] private ArrowSide _side = default;

    protected override void OnRefresh()
    {
        gameObject.SetActive(_model.ShouldArrowBeVisible(_side));
    }

    protected override void Clicked()
    {
        _controller.ArrowClicked(_side);
    }
}
