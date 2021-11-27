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
        FadeManager.Instance.FadeInColor(Color.black);
        FadeManager.Instance.FadeOut(FadeManager.startFadeTime);
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
        CreditsManager.Instance.SetActive(true);
        CreditsManager.Instance.CreditsEnded.AddListener(() => 
        { 
            FadeManager.Instance.FadeBreak(1);
            FadeManager.Instance.HalfFadeEnded.AddListener(() => CreditsManager.Instance.SetActive(false));
        }
        );
    }

    private void StartClicked()
    {
        //Start the Game
        FadeManager.Instance.FadeIn(FadeManager.startFadeTime);
        FadeManager.Instance.FadeEnded.AddListener(() => { SceneManager.LoadScene(sceneName, LoadSceneMode.Single); });
        
    }
}
