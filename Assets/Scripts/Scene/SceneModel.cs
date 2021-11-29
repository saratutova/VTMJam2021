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
    private Item _currentItemSelected = default;

    internal int Focus => GameManager.Instance.Focus;
    public Transform StuffPlace => _stuff;
    public Scenery CurrentScenery { get => _currentScenery; set => _currentScenery = value; }

    private SceneStuff _currentStuff;

    internal bool CanUsePower(Power power)
    {
        switch (power)
        {
            case Power.Auspex:
                return Focus >= 1 && !IsUsingAuspex;
            case Power.Potence:
                return Focus >= 1 && !IsUsingPotence;
            default:
                return false;
        }
    }

    internal bool ShouldArrowBeVisible(ArrowSide side) => _currentScenery != null
        && _currentScenery.IsSide(side, _currentWall.side) 
        && ShouldUIBeVisible
        && ScreenManager.Instance.ShouldArrowsBeVisible;
    internal bool ShouldUIBeVisible => !DialogueManager.Instance.IsDuringDialogue && !ZoomManager.Instance.isDuringZoom;

    public Wall CurrentWall
    {
        get => _currentWall;
        set
        {
            _currentWall = value;
            _currentWall.OnFirstEnter();
        }
    }

    public Sprite CurrentBackground => (_currentWall != null)? _currentWall.background : null;

    public StarState StartState => (CurrentStuff != null && CurrentStuff.IsThereSometingImportant)? StarState.Important 
        : (CurrentStuff.IsThereSometingToClick)? StarState.Something : StarState.Inactive;

    public SceneStuff CurrentStuff { get => _currentStuff; set => _currentStuff = value; }
    public bool IsUsingPotence { get; internal set; }
    public bool IsUsingAuspex { get; internal set; }
    public Item CurrentItemSelected => _currentItemSelected;

    internal void ItemClicked(Item item)
    {
        if (_currentItemSelected == default || _currentItemSelected != item)
        {
            _currentItemSelected = item;
        }
        else if (_currentItemSelected == item)
        {
            _currentItemSelected = default;
        }
    }
}
