using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private GameAction _actionOnSolve = default;
    [SerializeField] private GameAction _actionOnInit = default;

    internal void Init()
    {
        gameObject.gameObject.SetActive(true);
        if (_actionOnInit != null)
        {
            _actionOnInit.Action();
        }
    }

    public void SolvePuzzle()
    {
        if (_actionOnSolve != null)
        {
            _actionOnSolve.Action(); 
        }
        gameObject.gameObject.SetActive(false);
    }
}
