using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WallSide
{
    North, South, West, East, Ceiling
}

[CreateAssetMenu(fileName = "Wall", menuName = "SO/New Wall", order = 2)]
public class Wall : ScriptableObject
{
    public WallSide side;
    public Sprite background;

    public GameAction firstEnter = default;
    public SceneStuff stuff;

    public void OnFirstEnter()
    {
        if (firstEnter != null)
        {
            firstEnter.Action();
        }
    }
}
