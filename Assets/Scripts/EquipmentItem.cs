using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;

    private int _index;
    private EquipmentView _view;

    private void OnLeftClick()
    {
        _view.OnItemLeftClicked(_index);
    }
    
    private void OnRightClick()
    {
        _view.OnItemRightClicked(_index);
    }

    internal void Init(Sprite itemSprite, int index, EquipmentView view)
    {
        ChangeImage(itemSprite);
        _index = index;
        _view = view;
    }

    public void ChangeImage(Sprite itemSprite)
    {
        _image.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        else if (eventData.button == PointerEventData.InputButton.Right) 
        {
            OnRightClick();
        }
    }
}
