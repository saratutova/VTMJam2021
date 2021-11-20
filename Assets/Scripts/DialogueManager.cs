using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueManager : Manager<DialogueManager>
{
    [SerializeField] private Image _background = default;
    [SerializeField] private Image _character = default;
    [SerializeField] DialogueRunner _dialogueRunner = default;
    [SerializeField] List<DialogueData> _programs = new List<DialogueData>();

    public void StartDialogue(string name)
    {
        var program = _programs.FirstOrDefault(x => x.name.Equals(name));
        if (program == default)
        {
            Debug.LogError($"Couldn't find program named: {name}");
            return;
        }
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