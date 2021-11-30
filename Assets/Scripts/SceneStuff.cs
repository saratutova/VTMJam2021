using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class StuffDoSomething
{
    public string name;
    public List<GameAction> actionsOnDoSomething = new List<GameAction>();
}

public class SceneStuff : MonoBehaviour
{
    [SerializeField] private List<Interaction> interactions = new List<Interaction>();
    [SerializeField] private List<GameAction> actionsOnFirstView = new List<GameAction>();
    [SerializeField] private List<GameAction> actionsOnEveryView = new List<GameAction>();
    [SerializeField] private List<StuffDoSomething> actionsOnDoSomethingActions = new List<StuffDoSomething>();

    public bool IsThereSometingImportant => interactions.Any(x => x.important && !x.clicked && x.CanInteract);
    public bool IsThereSometingToClick => interactions.Any(x => !x.clicked && x.CanInteract);

    private bool visited = false;
    private bool wasShownAfterPontence = false;
    private bool wasShownAfterAuspex = false;

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
        if (ScreenManager.Instance.IsUsingPotence && !wasShownAfterPontence)
        {
            wasShownAfterPontence = true;
            interactions.ForEach(x => {
                if (x.onPotenceUsed != null)
                {
                    x.onPotenceUsed.Action();
                }
            });
        }
        
        if (ScreenManager.Instance.IsUsingAuspex && !wasShownAfterAuspex)
        {
            wasShownAfterAuspex = true;
            interactions.ForEach(x => {
                if (x.onAuspexUsed != null)
                {
                    x.onAuspexUsed.Action();
                }
            });
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void DoSomething(string stuffName)
    {
        var stuff = actionsOnDoSomethingActions.FirstOrDefault(x => x.name.Equals(stuffName));
        if (stuff == default)
        {
            Debug.Log($"THERE IS NO STUFF TO DO: {stuffName}");
            return;
        }
        
        stuff.actionsOnDoSomething.ForEach(x => x.Action());
    }
}
