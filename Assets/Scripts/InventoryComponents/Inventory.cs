using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemAdded(InventoryItem item);
    public delegate void OnItemRemoved(InventoryItem item);

    private InventoryItem[] _items;

    // max amount of items in one place
    [SerializeField]
    private int _stackNumber = 64;

    [SerializeField]
    private int _capacity = 10;
    public int Capacity
    {
        get => _capacity;
    }
    public event OnItemAdded onItemAdded;
    public event OnItemRemoved onItemRemoved;

    private void Awake()
    {
        _items = new InventoryItem[_capacity];
    }

    public bool AddItem(Item item, int amount)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
                continue;

            if (_items[i].item == item)
            {
                int freeSpace = _stackNumber - _items[i].amount;

                InventoryItem updatedInventoryItem = _items[i];

                if (amount > freeSpace)
                {
                    amount -= freeSpace;
                    updatedInventoryItem.amount = _stackNumber;
                    _items[i] = updatedInventoryItem;
                    onItemAdded?.Invoke(updatedInventoryItem);
                    break;
                }

                updatedInventoryItem.amount += amount;
                _items[i] = updatedInventoryItem;
                onItemAdded?.Invoke(updatedInventoryItem);
                return true;
            }
        }

        int freePlace = GetEmptyIndex();

        if (freePlace == -1)
            return false;

        InventoryItem newInventoryItem = new InventoryItem();
        newInventoryItem.amount = amount;
        newInventoryItem.item = item;

        _items[freePlace] = newInventoryItem;
        onItemAdded?.Invoke(newInventoryItem);
        return true;
    }

    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
                continue;

            if (_items[i].item == item)
            {
                InventoryItem updatedInventoryItem = _items[i];
                updatedInventoryItem.amount -= amount;

                if (updatedInventoryItem.amount > 0)
                {
                    _items[i] = updatedInventoryItem;
                    onItemRemoved?.Invoke(updatedInventoryItem);
                }
                else
                {
                    onItemRemoved?.Invoke(_items[i]);
                    _items[i] = null;
                }

                return;
            }
        }
    }

    private int GetEmptyIndex()
    {
        for (int i = 0; i < _items.Length; i++)
            if (_items[i] == null)
                return i;

        return -1;
    }

    public void ChangeItemsPlace(int firtsIndex, int secondIndex)
    {
        InventoryItem firstItem = _items[firtsIndex];
        InventoryItem secondItem = _items[secondIndex];

        _items[firtsIndex] = secondItem;
        _items[secondIndex] = firstItem;
    }

    public InventoryItem[] GetItems()
    {
        return _items;
    }
}
