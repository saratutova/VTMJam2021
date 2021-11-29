using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button = default;

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        
    }

    internal void Init(Item item)
    {
        _image.sprite = item.inEquipment;
    }
}
