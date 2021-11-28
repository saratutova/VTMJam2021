using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMultipleInteraction : Interaction
{
    [SerializeField] private List<GameAction> _gameActions = default;

    protected override void Interact()
    {
        base.Interact();
        if (_gameActions != null)
        {
            _gameActions.ForEach(x => GameActionManager.Instance.PlayAction(x));
        }
    }
}
