using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    [SerializeField] private string sceneName;

    private void Start()
    {
        _startButton.onClick.AddListener(StartClicked);
        _creditsButton.onClick.AddListener(CreditsClicked);
        _exitButton.onClick.AddListener(ExitClicked);
    }

    private void ExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void CreditsClicked()
    {
        //TODO: Turn on the credits
    }

    private void StartClicked()
    {
        //Start the Game
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
