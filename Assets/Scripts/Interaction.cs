using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool important = false;
    public bool clicked = false;

    private void OnMouseDown()
    {
        if (!DialogueManager.Instance.IsDuringDialogue)
        {
            clicked = true;

            Interact();
        }
    }

    protected void Interact()
    {

    }
}
