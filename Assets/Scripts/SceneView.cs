using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneView : MonoBehaviour
{
    [SerializeField] protected SceneController _controller;
    [SerializeField] protected SceneModel _model;

    private void Start()
    {
        _controller.Refresh.AddListener(OnRefresh);
    }

    protected virtual void OnRefresh()
    {
        throw new NotImplementedException();
    }
}