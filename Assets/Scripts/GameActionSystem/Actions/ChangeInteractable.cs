using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInteractable : GameAction
{
    [SerializeField] private Interaction _interaction = default;
    [SerializeField] private bool value = true;

    protected override void DoAction()
    {
        base.DoAction();
        _interaction.CanInteract = value;
        Done();
    }
}
