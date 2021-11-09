using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    North, South, West, East, Ceiling
}

[CreateAssetMenu(fileName = "Wall", menuName = "SO/New Wall", order = 2)]
public class Wall : ScriptableObject
{
    public Side side;
    public Sprite background;
}
