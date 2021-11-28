using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : MonoBehaviour
{
    [SerializeField] private SceneController _controller;

    private Scenery _currentScenery;
    private Wall _currentWall;

    internal int GetFocus => GameManager.Instance.Focus;
    public Scenery CurrentScenery { get => _currentScenery; set => _currentScenery = value; }

    internal bool ShouldArrowBeVisible(ArrowSide side) => _currentScenery.IsSide(side, _currentWall.side) && ShouldUIBeVisible;
    internal bool ShouldUIBeVisible => !DialogueManager.Instance.IsDuringDialogue;

    public Wall CurrentWall { get => _currentWall; set => _currentWall = value; }

    public Sprite CurrentBackground => _currentWall.background;

    public StarState StartState => StarState.Something;
}