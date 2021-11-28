using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SceneController : MonoBehaviour
{
    [HideInInspector] public UnityEvent Refresh = new UnityEvent();
    [SerializeField] private SceneModel _model = default;

    private List<SceneStuff> stuffs = new List<SceneStuff>();

    private void Start()
    {
        DialogueManager.Instance.DialogueStarted.AddListener(() => Refresh.Invoke());
        GameManager.Instance.FocusChanged.AddListener(() => Refresh.Invoke());
    }

    internal void SettingButtonClicked(SettingsType type)
    {
        switch (type)
        {
            case SettingsType.Settings:
                InGameMenu.Instance.TurnMenuOn();
                break;
            case SettingsType.Help:
                break;
            default:
                break;
        }
    }

    public void SetScenery(Scenery scenery)
    {
        _model.CurrentScenery = scenery;
        _model.CurrentWall = scenery.mainWall;
        SetStuff();
        Refresh.Invoke();
    }

    internal void ArrowClicked(ArrowSide side)
    {
        _model.CurrentWall = _model.CurrentScenery.GetWall(Scenery.GetNextSide(side, _model.CurrentWall.side));
        SetStuff();
        Refresh.Invoke();
    }

    private void SetStuff()
    {
        if (_model.CurrentStuff != null)
        {
            _model.CurrentStuff.Disable();
        }
        if (_model.CurrentWall.stuff != null)
        {
            var stuff = stuffs.FirstOrDefault(x => x.name.Equals(_model.CurrentWall.stuff.name));
            if (stuff == default)
            {
                stuff = Instantiate(_model.CurrentWall.stuff, _model.StuffPlace);
                stuff.name = _model.CurrentWall.stuff.name;
            }
            stuff.Init();
            _model.CurrentStuff = stuff;
        }
        else
        {
            Debug.Log($"THERE WAS NO STUFF: {_model.CurrentWall.name}");
            _model.CurrentStuff = null;
        }
    }
}
