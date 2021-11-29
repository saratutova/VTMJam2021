using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchOnPower : GameAction
{
    public GameAction onAuspexUsed = default;
    public GameAction onPotenceUsed = default;
    public GameAction withoutAuspex = default;
    public GameAction withoutPotence = default;
    
    protected override void DoAction()
    {
        base.DoAction();
        if (onAuspexUsed != null && ScreenManager.Instance.IsUsingAuspex)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(onAuspexUsed);
            }
            else
            {
                onAuspexUsed.Action();
            }
        }
        if (withoutAuspex != null && !ScreenManager.Instance.IsUsingAuspex)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(withoutAuspex);
            }
            else
            {
                withoutAuspex.Action();
            }
        }
        if (onPotenceUsed != null && ScreenManager.Instance.IsUsingPotence)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(onPotenceUsed);
            }
            else
            {
                onPotenceUsed.Action();
            }
        }
        if (withoutPotence != null && !ScreenManager.Instance.IsUsingPotence)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(withoutPotence);
            }
            else
            {
                withoutPotence.Action();
            }
        }
    }
}
