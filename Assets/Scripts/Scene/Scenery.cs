using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class Scenery : ScriptableObject
{
    public Wall mainWall;
    public List<Wall> surroundings = new List<Wall>();
    public GameAction firstEnter = default;

    public void OnFirstEnter()
    {
        if (firstEnter != null)
        {
            GameActionManager.Instance.PlayAction(firstEnter);
        }
    }

    public Wall GetWall(WallSide side) => surroundings.FirstOrDefault(x => x.side == side);

    internal bool IsSide(WallSide side) => GetWall(side) != default;

    internal bool IsSide(ArrowSide arrowSide, WallSide wallSide)
    {
        var wall = GetWall(GetNextSide(arrowSide, wallSide));
        return wall != default;
    }

    public static WallSide GetNextSide(ArrowSide arrowSide, WallSide wallSide)
    {
        switch (wallSide)
        {
            case WallSide.North:
                if (arrowSide == ArrowSide.Left)
                {
                    return WallSide.West;
                }
                else
                {
                    return WallSide.East;
                }
            case WallSide.South:
                if (arrowSide == ArrowSide.Left)
                {
                    return WallSide.East;
                }
                else
                {
                    return WallSide.West;
                }
            case WallSide.West:
                if (arrowSide == ArrowSide.Left)
                {
                    return WallSide.South;
                }
                else
                {
                    return WallSide.North;
                }
            case WallSide.East:
                if (arrowSide == ArrowSide.Left)
                {
                    return WallSide.North;
                }
                else
                {
                    return WallSide.South;
                }
            case WallSide.Ceiling:
            default:
                return wallSide;
        }
    }
}
