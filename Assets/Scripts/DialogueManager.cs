using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueManager : Manager<DialogueManager>
{
    [SerializeField] private GameObject _backgroundsGO = default;
    [SerializeField] private Image _background = default;
    [SerializeField] private Image _character = default;
    [SerializeField] private DialogueRunner _dialogueRunner = default;
    [SerializeField] private List<DialogueData> _programs = new List<DialogueData>();
    [HideInInspector] public UnityEvent DialogueCompleted = new UnityEvent();

    public bool IsDuringDialogue => _isRunning;

    private bool _isRunning;

    private void Start()
    {
        _dialogueRunner.onDialogueComplete.AddListener(OnDialogueComplite);
    }

    private void OnDialogueComplite()
    {
        _isRunning = false;
        _backgroundsGO.SetActive(false);
        DialogueCompleted.Invoke();
        DialogueCompleted.RemoveAllListeners();
    }

    public void StartDialogue(string name)
    {
        var program = _programs.FirstOrDefault(x => x.name.Equals(name));
        if (program == default)
        {
            Debug.LogError($"Couldn't find program named: {name}");
            return;
        }
        _isRunning = true;
        _backgroundsGO.SetActive(true);
        _background.gameObject.SetActive(program.background != null);
        _background.sprite = program.background;
        _character.gameObject.SetActive(program.character != null);
        _character.sprite = program.character;
        _dialogueRunner.Add(program.program);
        _dialogueRunner.startNode = program.startNode;
        _dialogueRunner.StartDialogue();
    }
}

[System.Serializable]
public class DialogueData
{
    public string name;
    public YarnProgram program;
    public string startNode;
    public Sprite background;
    public Sprite character;
}