using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : Manager<InGameMenu>
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _all;

    private void Start()
    {
        _resumeButton.onClick.AddListener(ResumeClicked);
        _exitButton.onClick.AddListener(ExitClicked);
    }

    public void TurnMenuOn()
    {
        _all.SetActive(true);
    }

    private void ResumeClicked()
    {
        _all.SetActive(false);
    }

    private void ExitClicked()
    {
        GameManager.Instance.EndGame();
    }
}
