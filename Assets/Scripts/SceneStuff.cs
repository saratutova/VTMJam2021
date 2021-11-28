using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneStuff : MonoBehaviour
{
    [SerializeField] private List<Interaction> interactions = new List<Interaction>();
    [SerializeField] private List<GameAction> actionsOnFirstView = new List<GameAction>();

    public bool IsThereSometingImportant => interactions.Any(x => x.important && !x.clicked);
    public bool IsThereSometingToClick => interactions.Any(x => !x.clicked);

    private bool visited = false;

    internal void Init()
    {
        gameObject.SetActive(true);
        if (!visited)
        {
            visited = true;
            if (actionsOnFirstView != null)
            {
                actionsOnFirstView.ForEach(x => GameActionManager.Instance.PlayAction(x));
            }
        }
    }

    internal void Disable()
    {
        gameObject.SetActive(false);
    }
}
