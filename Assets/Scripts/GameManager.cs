using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private Scenery _startScenery;
    [SerializeField] private float _fadeTime = 5f;
    [HideInInspector] public UnityEvent FocusChanged = new UnityEvent();

    private int _focus = 0;

    public int Focus => _focus;

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
                FadeManager.Instance.HalfFadeEnded.AddListener(() => 
                { 
                    MessageManager.Instance.TurnOff();
                    DialogueManager.Instance.StartDialogue("Slajd3");
                    DialogueManager.Instance.DialogueCompleted.AddListener(() => FadeManager.Instance.FadeBreak(1f));
                }); 
                //FadeManager.Instance.FadeEnded.AddListener(FadedFinished); 
            }
        );
    }



    public void ChangeFocus(int amount)
    {
        _focus += amount;
        if (_focus < 0)
        {
            _focus = 0;
        }
        if (_focus > 5)
        {
            _focus = 5;
        }
        FocusChanged.Invoke();
    }
}
