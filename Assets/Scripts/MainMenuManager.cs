using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    [SerializeField] private string sceneName;

    private void Start()
    {
        _startButton.onClick.AddListener(StartClicked);
    }

    private void StartClicked()
    {
        //Start the Game
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
