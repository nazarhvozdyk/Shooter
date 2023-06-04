using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerDownHandler
{
    private static List<ItemIcon> _icons = new List<ItemIcon>();

    [SerializeField]
    private ItemIconContent _contentPrefab;
    private int _itemInvenoryPlaceIndex;
    private ItemIconContent _content;
    private Item _item;
    private int _amount;

    private void Start()
    {
        _icons.Add(this);
    }

    public void SetUp(Item item, int amount, int placeInInventory)
    {
        ItemIconContent newContent = Instantiate(_contentPrefab, transform);
        newContent.SetUp(amount, item.sprite);
        _content = newContent;
        _itemInvenoryPlaceIndex = placeInInventory;
        _item = item;
        _amount = amount;
    }

    public void SetNewItem(Item item, int amount)
    {
        DestroyImmediate(_content.gameObject);
        ItemIconContent newContent = Instantiate(_contentPrefab, transform);
        _content = newContent;
        newContent.SetUp(amount, item.sprite);
    }

    public void SetContent(RectTransform rectTransform)
    {
        rectTransform.SetParent(transform, true);
        rectTransform.localPosition = Vector3.zero;
    }

    public RectTransform GetContentTransform()
    {
        return _content.transform as RectTransform;
    }

    public InventoryItem GetItem()
    {
        InventoryItem item = new InventoryItem();
        item.amount = _amount;
        item.item = _item;

        return item;
    }

    private void OnDestroy()
    {
        _icons.Remove(this);
    }

    public static void DestroyAll()
    {
        foreach (var icon in _icons)
            Destroy(icon.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryIconsHandler.Instance.OnIconMouseDown(this);
    }
}
