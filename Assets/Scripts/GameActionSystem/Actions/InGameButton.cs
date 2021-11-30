using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameButton : MonoBehaviour
{
    [SerializeField] private bool _withGAMUse = true;
    [SerializeField] private List<GameAction> _onButtonClickedActions = default;
    [SerializeField] private Button _button = default;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (_onButtonClickedActions != null)
        {
            if (_withGAMUse)
            {
                _onButtonClickedActions.ForEach(x => GameActionManager.Instance.PlayAction(x)); 
            }
            else
            {
                _onButtonClickedActions.ForEach(x => x.Action());
            }
        }
    }
}
