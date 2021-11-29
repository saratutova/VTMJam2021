using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button = default;

    private int _index;
    private EquipmentView _view;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _view.OnItemClicked(_index);
    }

    internal void Init(Sprite itemSprite, int index, EquipmentView view)
    {
        _image.sprite = itemSprite;
        _index = index;
        _view = view;
    }
}
