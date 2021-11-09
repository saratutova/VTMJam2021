using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneController : MonoBehaviour
{
    [HideInInspector] public UnityEvent Refresh = new UnityEvent();
    [SerializeField] private SceneModel _model;

    public void SetScenery(Scenery scenery)
    {
        _model.CurrentScenery = scenery;
        _model.CurrentWall = scenery.mainWall;
        Refresh.Invoke();
    }

}
