using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : Manager<GameManager>
{
    [SerializeField] private string sceneName;    
    [SerializeField] private GameManagerModel _model = default;
    [HideInInspector] public UnityEvent FocusChanged = new UnityEvent();

    public int Focus => _model.Focus;

    

    public List<Item> Items => _model.GetItems;
    public List<Item> Memories => _model.GetMemories;
    internal List<Item> GetItemList(EquipmentType currentType) => (currentType == EquipmentType.Item) ? Items : Memories;

    private void Start()
    {
        FadeManager.Instance.FadeInColor(Color.black);
        FadeManager.Instance.FadeOut(FadeManager.startFadeTime);

        ScreenManager.Instance.SetScenery(_model.StartScenery);
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
        var controller = ScreenManager.Instance.GetSceneController();
        controller.ForceRefresh();
    }

    public void RemoveItem(Item item)
    {
        _model.RemoveItem(item);
        var controller = ScreenManager.Instance.GetSceneController();
        controller.ForceRefresh();
    }
    public bool CheckBoolValue(string checkName)
    {
        return _model.Check(checkName);
    }

    public void SetBool(string checkName, bool value)
    {
        _model.SetCheck(checkName, value);
        ScreenManager.Instance.RefreshSceneStuff();
    }
}
