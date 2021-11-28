using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneStuff : MonoBehaviour
{
    public static bool wasWindowDialoge = false;
    [SerializeField] private List<Interaction> interactions = new List<Interaction>();
    [SerializeField] private List<GameAction> actionsOnFirstView = new List<GameAction>();
    [SerializeField] private List<GameAction> actionsOnEveryView = new List<GameAction>();
    [SerializeField] private List<GameAction> actionsOnDoSomething = new List<GameAction>();

    public bool IsThereSometingImportant => interactions.Any(x => x.important && !x.clicked && x.canInteract);
    public bool IsThereSometingToClick => interactions.Any(x => !x.clicked && x.canInteract);

    private bool visited = false;

    public void Init()
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
        if (actionsOnEveryView != null)
        {
            actionsOnEveryView.ForEach(x => x.Action());
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void DoSomething()
    {
        if (actionsOnDoSomething != null)
        {
            actionsOnDoSomething.ForEach(x => x.Action());
        }
    }
}
