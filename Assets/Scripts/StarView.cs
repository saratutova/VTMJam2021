using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum StarState
{
    Something, Inactive, Important
}

public class StarView : SceneUIView
{
    [SerializeField] private Color _highlightColor;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _active;
    [SerializeField] private Sprite _inactive;

    protected override void OnRefresh()
    {
        base.OnRefresh();
        switch (_model.StartState)
        {
            case StarState.Something:
                _image.sprite = _active;
                _image.color = Color.white;
                break;
            case StarState.Inactive:
                _image.sprite = _inactive;
                _image.color = Color.white;
                break;
            case StarState.Important:
                _image.sprite = _active;
                _image.color = _highlightColor;
                break;
            default:
                break;
        }
    }
}
