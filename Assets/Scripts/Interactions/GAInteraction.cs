using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAInteraction : Interaction
{
    [SerializeField] private GameAction _gameAction = default;
    [SerializeField] private bool _withGAM = true;

    protected override void Interact()
    {
        base.Interact();
        if (_gameAction != null)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(_gameAction); 
            }
            else
            {
                _gameAction.Action();
            }
        }
    }
}
