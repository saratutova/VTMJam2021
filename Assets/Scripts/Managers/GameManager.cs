using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private string sceneName;
    [SerializeField] private Scenery _startScenery;
    
    [SerializeField] private GameManagerModel _model = default;
    [HideInInspector] public UnityEvent FocusChanged = new UnityEvent();

    public int Focus => _model.Focus;
    public List<Item> Items => _model.Items;
    public List<Memory> Memories => _model.Memories;

    private void Start()
    {
        FadeManager.Instance.FadeInColor(Color.black);
        FadeManager.Instance.FadeOut(FadeManager.startFadeTime);

        ScreenManager.Instance.SetScenery(_startScenery);
    }

    internal void EndGame()
    {
        FadeManager.Instance.FadeIn(2f);
        FadeManager.Instance.FadeEnded.AddListener(() => { SceneManager.LoadScene(sceneName, LoadSceneMode.Single); });
    }

    public void ChangeFocus(int amount)
    {
        _model.Focus += amount;
        if (Focus < 0)
        {
            _model.Focus = 0;
        }
        if (Focus > 5)
        {
            _model.Focus = 5;
        }
        FocusChanged.Invoke();
    }

    public void AddItem(Item item)
    {
        _model.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        _model.RemoveItem(item);
    }

    public void AddMemory(Memory memory)
    {
        _model.AddMemory(memory);
    }

    public void RemoveMemory(Memory memory)
    {
        _model.RemoveMemory(memory);
    }
}
