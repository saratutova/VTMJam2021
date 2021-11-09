using System;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private Scenery _startScenery;
    [SerializeField] private float _fadeTime = 5f;

    protected override void Awake()
    {

    }

    private void Start()
    {
        FadeManager.Instance.FadeInColor(Color.black);
        FadeManager.Instance.FadeOut(_fadeTime);
        FadeManager.Instance.FadeEnded.AddListener(FadedFinished);

        ScreenManager.Instance.SetScenery(_startScenery);
    }

    private void FadedFinished()
    {
        //After Fade OUT
    }
}
