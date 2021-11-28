using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameButton : MonoBehaviour
{
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
            _onButtonClickedActions.ForEach(x => GameActionManager.Instance.PlayAction(x));
        }
    }
}
