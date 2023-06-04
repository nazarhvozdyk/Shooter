using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private static List<ItemController> _items = new List<ItemController>();
    public static ItemController[] itemControllers
    {
        get => _items.ToArray();
    }

    [SerializeField]
    private Item _item;

    [SerializeField]
    private int _amount;
    public Item Item
    {
        get => _item;
    }
    public int Amount
    {
        get => _amount;
    }

    private void Start()
    {
        _items.Add(this);
    }

    private void OnDestroy()
    {
        _items.Remove(this);
    }
}
