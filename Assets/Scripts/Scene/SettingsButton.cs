using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SettingsType
{
    Settings, Help
}

public class SettingsButton : SceneButton
{
    [SerializeField] private SettingsType type;

    protected override void Clicked()
    {
        _controller.SettingButtonClicked(type);
    }
}
