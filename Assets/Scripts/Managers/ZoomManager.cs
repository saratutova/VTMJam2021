using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZoomManager : Manager<ZoomManager>
{
    [HideInInspector] public bool isDuringZoom = false;
    [HideInInspector] public UnityEvent ZoomEnded = new UnityEvent();
    [HideInInspector] public UnityEvent ZoomStarted = new UnityEvent();
    [HideInInspector] public UnityEvent ZoomCompleted = new UnityEvent();
    [SerializeField] private GameObject _all = default;
    [SerializeField] private Image _image = default;
    [SerializeField] private Button _exitButton = default;
    [SerializeField] private Button _otherButton = default;
    [SerializeField] private TMPro.TMP_Text _otherText = default;

    private GameAction _action;
    private bool _isOtherButtonUsed = false;
    private bool _withGAM = false;
    private bool canExit = true;

    private void Start()
    {
        _exitButton.onClick.AddListener(ExitZoom);
        _otherButton.onClick.AddListener(OtherClicked);
        DialogueManager.Instance.DialogueStarted.AddListener(() => SetButtons(false));
        DialogueManager.Instance.DialogueEnded.AddListener(() => SetButtons(true));
    }

    private void OtherClicked()
    {
        if (_action != null)
        {
            if (_withGAM)
            {
                GameActionManager.Instance.PlayAction(_action); 
            }
            else
            {
                _action.Action();
            }
        }
        canExit = true;
    }

    private void ExitZoom()
    {
        if (canExit)
        {
            isDuringZoom = false;
            _all.SetActive(false);
            _action = default;
            ZoomCompleted.Invoke();
            ZoomCompleted.RemoveAllListeners();
            ZoomEnded.Invoke(); 
        }
    }

    public void ShowZoom(Sprite sprite, bool withGAM, bool canExit)
    {
        this.canExit = canExit;
        _withGAM = withGAM;
        isDuringZoom = true;
        ZoomStarted.Invoke();
        _all.SetActive(true);
        _image.sprite = sprite;
        _otherButton.gameObject.SetActive(false);
        _isOtherButtonUsed = false;
    }

    public void CloseZoom()
    {
        ExitZoom();
    }

    public void ShowZoom(Sprite sprite, string buttonName, GameAction action, bool withGAM, bool canExit)
    {
        ShowZoom(sprite, withGAM, canExit);
        _action = action;
        _otherText.text = buttonName;
        _otherButton.gameObject.SetActive(true);
        _isOtherButtonUsed = true;
    }

    private void SetButtons(bool value)
    {
        _otherButton.gameObject.SetActive(value && _isOtherButtonUsed);
        _exitButton.gameObject.SetActive(value);
    }
}
