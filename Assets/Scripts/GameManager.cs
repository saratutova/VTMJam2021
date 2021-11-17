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

        ScreenManager.Instance.SetScenery(_startScenery);
        MessageManager.Instance.SetMessage("Chapter 1");
        MessageManager.Instance.MessageEnded.AddListener(() => 
            { 
                FadeManager.Instance.FadeBreak(1f); 
                FadeManager.Instance.HalfFadeEnded.AddListener(() => MessageManager.Instance.TurnOff()); 
                FadeManager.Instance.FadeEnded.AddListener(FadedFinished); 
            }
        );
    }

    private void FadedFinished()
    {
        //After Fade OUT - start dialogue
        DialogueManager.Instance.StartDialogue("Slajd4");
    }
}
