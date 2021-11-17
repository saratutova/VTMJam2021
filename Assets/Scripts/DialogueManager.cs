using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : Manager<DialogueManager>
{

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
}