using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Scenery : ScriptableObject
{
    public Wall mainWall;
    public List<Wall> surroundings = new List<Wall>();

    public Wall GetWall(Side side) => surroundings.FirstOrDefault(x => x.side == side);

    internal bool IsSide(Side side) => GetWall(side) != default;

    internal bool IsSide(ArrowSide arrowSide, Side wallSide)
    {
        return true;
    }

    public static Side GetSide(ArrowSide arrowSide, Side wallSide)
    {
        switch (wallSide)
        {
            case Side.North:
                if (arrowSide == ArrowSide.Left)
                {
                    return Side.West;
                }
                else
                {
                    return Side.East;
                }
            case Side.South:
                if (arrowSide == ArrowSide.Left)
                {
                    return Side.East;
                }
                else
                {
                    return Side.West;
                }
            case Side.West:
                if (arrowSide == ArrowSide.Left)
                {
                    return Side.South;
                }
                else
                {
                    return Side.North;
                }
            case Side.East:
                if (arrowSide == ArrowSide.Left)
                {
                    return Side.North;
                }
                else
                {
                    return Side.South;
                }
            case Side.Ceiling:
            default:
                return wallSide;
        }
    }
}
