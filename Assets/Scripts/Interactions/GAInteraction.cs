using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAInteraction : Interaction
{
    [SerializeField] private GameAction _gameAction = default;

    protected override void Interact()
    {
        base.Interact();
        if (_gameAction != null)
        {
            _gameAction.Action();
        }
    }
}
