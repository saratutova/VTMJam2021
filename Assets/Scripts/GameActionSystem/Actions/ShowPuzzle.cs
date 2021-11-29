using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPuzzle : GameAction
{
    [SerializeField] private Puzzle puzzle = default;
    protected override void DoAction()
    {
        base.DoAction();
        puzzle.Init();
        Done();
    }
}
