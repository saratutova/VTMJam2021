using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interaction : MonoBehaviour
{
    [SerializeField] protected bool _withGAMUse = false;
    public GameAction onAuspexUsed = default;
    public GameAction onPotenceUsed = default;
    public bool important = false;
    public bool clicked = false;
    private bool canInteract = true;

    private BoxCollider2D boxCollider = null;

    public bool CanInteract
    {
        get => canInteract; 
        set
        {
            canInteract = value;
            if (boxCollider == null)
            {
                boxCollider = GetComponent<BoxCollider2D>();
            }
            boxCollider.enabled = value;
        }
    }

    private void OnMouseDown()
    {
        if (!DialogueManager.Instance.IsDuringDialogue && CanInteract)
        {
            clicked = true;

            Interact();
        }
    }

    protected virtual void Interact()
    {

    }
}
