using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : MonoBehaviour
{
    [SerializeField] private SceneController _controller;
    [SerializeField] private Transform _stuff = default;

    private Scenery _currentScenery;
    private Wall _currentWall;

    internal int Focus => GameManager.Instance.Focus;
    public Transform StuffPlace => _stuff;
    public Scenery CurrentScenery { get => _currentScenery; set => _currentScenery = value; }

    private SceneStuff _currentStuff;

    internal bool CanUsePower(Power power)
    {
        switch (power)
        {
            case Power.Auspex:
                return Focus >= 1;
            case Power.Potence:
                return Focus >= 1;
            default:
                return false;
        }
    }

    internal bool ShouldArrowBeVisible(ArrowSide side) => _currentScenery.IsSide(side, _currentWall.side) && ShouldUIBeVisible;
    internal bool ShouldUIBeVisible => !DialogueManager.Instance.IsDuringDialogue;

    public Wall CurrentWall
    {
        get => _currentWall;
        set
        {
            _currentWall = value;
            _currentWall.OnFirstEnter();
        }
    }

    public Sprite CurrentBackground => _currentWall.background;

    public StarState StartState => (CurrentStuff != null && CurrentStuff.IsThereSometingImportant)? StarState.Important 
        : (CurrentStuff.IsThereSometingToClick)? StarState.Something : StarState.Inactive;

    public SceneStuff CurrentStuff { get => _currentStuff; set => _currentStuff = value; }
}
