using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneController : MonoBehaviour
{
    [HideInInspector] public UnityEvent Refresh = new UnityEvent();
    [SerializeField] private SceneModel _model;

    private void Start()
    {
        DialogueManager.Instance.DialogueStarted.AddListener(() => Refresh.Invoke());
    }

    public void SetScenery(Scenery scenery)
    {
        _model.CurrentScenery = scenery;
        _model.CurrentWall = scenery.mainWall;
        Refresh.Invoke();
    }

    internal void ArrowClicked(ArrowSide side)
    {
        _model.CurrentWall = _model.CurrentScenery.GetWall(Scenery.GetSide(side, _model.CurrentWall.side));
        Refresh.Invoke();
    }
}
