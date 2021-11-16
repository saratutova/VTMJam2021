using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MessageManager : Manager<MessageManager>
{
    [SerializeField] private GameObject _background;
    [SerializeField] private TMPro.TMP_Text _text;
    [HideInInspector] public UnityEvent MessageEnded = new UnityEvent();

    public void SetMessage(string message)
    {
        _background.SetActive(true);
        _text.text = message;
    }

    public void MessageClicked()
    {
        MessageEnded.Invoke();
        MessageEnded.RemoveAllListeners();
    }

    public void TurnOff()
    {
        _background.SetActive(false);
    }
}
