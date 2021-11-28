using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerModel : MonoBehaviour
{
    [SerializeField] private Scenery _startScenery;
    private int _focus = 0;
    private List<Item> _items;

    public int Focus { get => _focus; set => _focus = value; }
    public Scenery StartScenery => _startScenery;

    public List<Item> AllItems => _items;
    public List<Item> GetMemories => _items.Where(x => x.type == EquipmentType.Memory).ToList();
    public List<Item> GetItems => _items.Where(x => x.type == EquipmentType.Item).ToList();

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
    
    //public void AddMemory(Memory memory)
    //{
    //    _memories.Add(memory);
    //}
    
    //public void RemoveMemory(Memory memory)
    //{
    //    _memories.Remove(memory);
    //}
}
