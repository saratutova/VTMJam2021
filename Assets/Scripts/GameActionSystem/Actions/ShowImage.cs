using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowImage : GameAction
{
    [SerializeField] private Sprite _sprite = default;
    [SerializeField] private StringType _name = default;
    [SerializeField] private GameAction _actionOnButton = default;
    [SerializeField] private GameAction _actionOnClose = default;

    protected override void DoAction()
    {
        base.DoAction();
        if (_actionOnButton != null)
        {
            ZoomManager.Instance.ShowZoom(_sprite, StaticStrings.GetString(_name), _actionOnButton);
        }
        else
        {
            ZoomManager.Instance.ShowZoom(_sprite);
        }
        ZoomManager.Instance.ZoomCompleted.AddListener(() =>
        {
            if (_actionOnClose != null)
            {
                GameActionManager.Instance.PlayAction(_actionOnClose);
            }
        });
    }
}
