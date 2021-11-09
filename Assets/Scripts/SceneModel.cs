using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel : MonoBehaviour
{
    [SerializeField] private SceneController _controller;

    private Scenery _currentScenery;
    private Wall _currentWall;

    public Scenery CurrentScenery { get => _currentScenery; set => _currentScenery = value; }
    public Wall CurrentWall { get => _currentWall; set => _currentWall = value; }

    public Sprite CurrentBackground => _currentWall.background;
}
