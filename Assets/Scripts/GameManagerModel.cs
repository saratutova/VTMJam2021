using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerModel : MonoBehaviour
{
    private int _focus = 0;
    private List<Item> _items;
    private List<Memory> _memories;
    

    public int Focus { get => _focus; set => _focus = value; }

    public List<Item> Items => _items;
    public List<Memory> Memories => _memories;

    public void AddItem(Item item)
    {
        _items.Add(item);
    }
    
    public void RemoveItem(Item item)
    {
        _items.Remove(item);
    }
    
    public void AddMemory(Memory memory)
    {
        _memories.Add(memory);
    }
    
    public void RemoveMemory(Memory memory)
    {
        _memories.Remove(memory);
    }
}
