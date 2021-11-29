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
            GameActionManager.Instance.PlayAction(_action);
        }
    }

    private void ExitZoom()
    {
        isDuringZoom = false;
        _all.SetActive(false);
        ZoomCompleted.Invoke();
        ZoomCompleted.RemoveAllListeners();
        ZoomEnded.Invoke();
    }

    public void ShowZoom(Sprite sprite)
    {
        isDuringZoom = true;
        ZoomStarted.Invoke();
        _all.SetActive(true);
        _image.sprite = sprite;
        _otherButton.gameObject.SetActive(false);
    }

    public void CloseZoom()
    {
        ExitZoom();
    }

    public void ShowZoom(Sprite sprite, string buttonName, GameAction action)
    {
        ShowZoom(sprite);
        _action = action;
        _otherText.text = buttonName;
        _otherButton.gameObject.SetActive(true);
    }

    private void SetButtons(bool value)
    {
        _otherButton.gameObject.SetActive(value);
        _exitButton.gameObject.SetActive(value);
    }
}
