using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemAdded(InventoryItem item);
    public delegate void OnItemRemoved(InventoryItem item);

    private List<InventoryItem> _items = new List<InventoryItem>();

    // max amount of items in one place
    [SerializeField]
    private int _stackNumber = 64;
    public event OnItemAdded onItemAdded;
    public event OnItemRemoved onItemRemoved;

    public void AddItem(Item item, int amount)
    {
        for (int i = 0; i < _items.Count; i++)
        {
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
                return;
            }
        }

        InventoryItem newInventoryItem = new InventoryItem();
        newInventoryItem.amount = amount;
        newInventoryItem.item = item;

        _items.Add(newInventoryItem);
        onItemAdded?.Invoke(newInventoryItem);
    }

    public void RemoveItem(Item item, int amount)
    {
        for (int i = 0; i < _items.Count; i++)
        {
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
                    _items.RemoveAt(i);
                }

                return;
            }
        }
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
        return _items.ToArray();
    }
}
