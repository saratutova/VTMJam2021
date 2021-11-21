using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ArrowSide
{
    Right, Left
}

public class ArrowViewer : SceneView
{
    [SerializeField] private Button _button = default;
    [SerializeField] private ArrowSide _side = default;

    protected override void Start()
    {
        base.Start();
        _button.onClick.AddListener(Clicked);
    }

    protected override void OnRefresh()
    {
        gameObject.SetActive(_model.ShouldIBeVisible(_side));
    }

    private void Clicked()
    {
        _controller.ArrowClicked(_side);
    }


}
