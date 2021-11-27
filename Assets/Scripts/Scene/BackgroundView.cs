using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundView : SceneView
{
    [SerializeField] private SpriteRenderer _image;

    protected override void OnRefresh()
    {
        _image.sprite = _model.CurrentBackground;
    }
}
