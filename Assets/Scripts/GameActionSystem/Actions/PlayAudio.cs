using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : GameAction
{
    [SerializeField] private string _audioName = "";
    protected override void DoAction()
    {
        base.DoAction();
        AudioManager.Instance.PlayClip(_audioName);
    }
}
