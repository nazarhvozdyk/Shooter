using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ItemIcon
    : MonoBehaviour,
        IPointerDownHandler,
        IPointerEnterHandler,
        IPointerExitHandler
{
    private static List<ItemIcon> _icons = new List<ItemIcon>();

    [SerializeField]
    private ItemIconContent _contentPrefab;
    private int _itemInvenoryPlaceIndex;
    private ItemIconContent _content;
    private Item _item;
    private int _amount;
    private bool _isEmpty = true;
    public bool IsEmpty
    {
        get => _isEmpty;
    }
    public int PlaceIndex
    {
        get => _itemInvenoryPlaceIndex;
    }

    private void Awake()
    {
        _icons.Add(this);
    }

    public void SetUp(int placeInInventory)
    {
        _itemInvenoryPlaceIndex = placeInInventory;
    }

    public void SetUp(Item item, int amount, int placeInInventory)
    {
        ItemIconContent newContent = Instantiate(_contentPrefab, transform);
        newContent.SetUp(amount, item.sprite);
        _content = newContent;

        _itemInvenoryPlaceIndex = placeInInventory;
        _item = item;
        _amount = amount;

        _isEmpty = false;
    }

    public void SetNewItem(Item item, int amount)
    {
        if (_content)
            DestroyImmediate(_content.gameObject);

        ItemIconContent newContent = Instantiate(_contentPrefab, transform);
        _content = newContent;
        newContent.SetUp(amount, item.sprite);

        _item = item;
        _amount = amount;

        _isEmpty = false;
    }

    public void MakeEmpty()
    {
        _isEmpty = true;
        _item = null;

        if (_content)
            Destroy(_content.gameObject);
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

    public InventoryItem GetInventoryItem()
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

    public void OnPointerDown(PointerEventData eventData)
    {
        InventoryIconsHandler.Instance.OnIconMouseDown(this);
    }

    public static void DestroyAll()
    {
        foreach (var icon in _icons)
            Destroy(icon.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryIconsHandler.Instance.hoveredIcon = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (InventoryIconsHandler.Instance.hoveredIcon == this)
            InventoryIconsHandler.Instance.hoveredIcon = null;
    }
}
