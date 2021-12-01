using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForItem : GameAction
{
    [SerializeField] private Item _item;
    [SerializeField] private GAInteraction _interaction;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private List<GameAction> _onRightItem;
    [SerializeField] private List<GameAction> _onWrongItem;

    protected override void DoAction()
    {
        base.DoAction();
        if (ScreenManager.Instance.IsItemRight(_item))
        {
            if (_withGAM)
            {
                _onRightItem.ForEach(x => GameActionManager.Instance.PlayAction(x));
            }
            else
            {
                _onRightItem.ForEach(x => x.Action());
            }
            Done();
            _interaction.CanInteract = false;
            _renderer.sprite = _item.onPlace;
            _interaction.onAuspexUsed = default;
            GameManager.Instance.RemoveItem(_item);
        }
        else
        {
            if (_withGAM)
            {
                _onWrongItem.ForEach(x => GameActionManager.Instance.PlayAction(x));
            }
            else
            {
                _onWrongItem.ForEach(x => x.Action());
            }
        }
    }
}
