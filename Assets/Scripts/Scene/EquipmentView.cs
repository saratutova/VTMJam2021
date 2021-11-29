using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EquipmentView : SceneUIView
{
    [SerializeField] private Button _changeButton = default;
    [SerializeField] private Sprite _itemSprite = default;
    [SerializeField] private Sprite _memorySprite = default;
    [SerializeField] private Transform _listPlace = default;
    [SerializeField] private EquipmentItem _item = default;

    private EquipmentType _currentType = EquipmentType.Item;
    private List<Item> _currentList = new List<Item>();

    protected override void Start()
    {
        base.Start();
        _changeButton.onClick.AddListener(ChangeEquipment);
    }

    private void ChangeEquipment()
    {
        if (_currentType == EquipmentType.Item)
        {
            _currentType = EquipmentType.Memory;
        }
        else
        {
            _currentType = EquipmentType.Item;
        }
        _changeButton.image.sprite = (_currentType == EquipmentType.Item) ? _itemSprite : _memorySprite;
        SetList();
    }

    private void SetList()
    {
        if (_listPlace.childCount > 0)
        {
            for (int i = _listPlace.childCount - 1; i >= 0; i--)
            {
                Destroy(_listPlace.GetChild(i).gameObject);
            }
        }
        _currentList = GameManager.Instance.GetItemList(_currentType);
        for (int i = 0; i < _currentList.Count; i++)
        {
            var newItem = Instantiate(_item, _listPlace);
            newItem.Init(_currentList[i].inEquipment, i, this);
            if (_currentList[i] == _model.CurrentItemSelected)
            {
                newItem.ChangeImage(_currentList[i].inEquipmentSelected);
            }
        }
    }

    protected override void OnRefresh()
    {
        base.OnRefresh();
        SetList();
    }

    internal void OnItemLeftClicked(int index)
    {
        switch (_currentType)
        {
            case EquipmentType.Item:
                if (_currentList[index].isUsable)
                {
                    _model.ItemClicked(_currentList[index]); 
                }
                break;
            case EquipmentType.Memory:
                break;
            default:
                break;
        }
        _controller.ForceRefresh();
    }
    
    internal void OnItemRightClicked(int index)
    {
        ZoomManager.Instance.ShowZoom(_currentList[index].zoomPic);
    }
}
