using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interaction : MonoBehaviour
{
    [SerializeField] protected bool _withGAMUse = true;
    public GameAction onAuspexUsed = default;
    public GameAction onPotenceUsed = default;
    public bool important = false;
    public bool clicked = false;
    public bool canInteract = true;

    private void OnMouseDown()
    {
        if (!DialogueManager.Instance.IsDuringDialogue && canInteract)
        {
            clicked = true;

            Interact();
        }
    }

    protected virtual void Interact()
    {

    }
}
