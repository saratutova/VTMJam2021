using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusViewer : SceneUIView
{
    [SerializeField] private Image _displayImage = default;
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();

    protected override void OnRefresh()
    {
        base.OnRefresh();
        _displayImage.sprite = _sprites[_model.GetFocus];
    }
}
