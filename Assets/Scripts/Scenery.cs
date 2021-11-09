using System.Collections.Generic;
using UnityEngine;

public abstract class Scenery : ScriptableObject
{
    public Wall mainWall;
    public List<Wall> surroundings = new List<Wall>();
}
