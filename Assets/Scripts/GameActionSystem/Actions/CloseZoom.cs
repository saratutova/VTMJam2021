using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseZoom : GameAction
{
    protected override void DoAction()
    {
        base.DoAction();
        ZoomManager.Instance.CloseZoom();
        Done();
    }
}
