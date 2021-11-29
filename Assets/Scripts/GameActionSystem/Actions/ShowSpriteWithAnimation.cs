using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSpriteWithAnimation : GameAction
{
    [SerializeField] private float _time = default;
    [SerializeField] private float _delay = default;
    [SerializeField] private Color _color = default;
    [SerializeField] private GameObject _spriteObj = default;
    [SerializeField] private iTween.EaseType _easetype = default;
    [SerializeField] private iTween.LoopType _looptype = default;
    [SerializeField] private GameAction _onFinishedAction = default;
    //[SerializeField] private bool _withGAM = true;

    protected override void DoAction()
    {
        base.DoAction();
        var hash = new Hashtable();
        hash.Add("time", _time);
        hash.Add("color", _color);
        hash.Add("delay", _delay);
        hash.Add("easetype", _easetype);
        hash.Add("looptype", _looptype);
        hash.Add("oncomplete", "OnAnimationFinished");
        hash.Add("oncompletetarget", gameObject);
        iTween.ColorTo(_spriteObj.gameObject, hash);
    }

    public void OnAnimationFinished()
    {
        if (_onFinishedAction != null)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(_onFinishedAction);
            }
            else
            {
                _onFinishedAction.Action();
            }
            Done();
        }
    }
}
