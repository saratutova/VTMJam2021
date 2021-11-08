using System;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private Scenery _startScenery;
    [SerializeField] private float _fadeTime = 5f;

    protected override void Awake()
    {
        FadeManager.Instance.FadeInColor(Color.black);
        FadeManager.Instance.FadeOut(_fadeTime);
        FadeManager.Instance.FadeEnded.AddListener(FadedFinished);
    }

    private void FadedFinished()
    {
        Debug.Log("fsdgasdgsdgdg");
    }
}
