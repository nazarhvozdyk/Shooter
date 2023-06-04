using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{
    public static InventoryDisplayer Instance
    {
        get => _instance;
    }
    private static InventoryDisplayer _instance;

    [SerializeField]
    private ItemIcon _itemIconPrefab;

    [SerializeField]
    private RectTransform _iconsParent;

    [SerializeField]
    private GameObject _inventoryIUObject;

    [SerializeField]
    private Inventory _inventory;
    public bool isActive { get; private set; }

    private void Awake()
    {
        _instance = this;
    }

    public void Show()
    {
        InventoryItem[] items = _inventory.GetItems();

        foreach (var item in items)
        {
            ItemIcon itemIcon = Instantiate(_itemIconPrefab, _iconsParent);
            itemIcon.SetUp(item.item, item.amount);
        }

        _inventoryIUObject.SetActive(true);
        isActive = true;
    }

    public void Hide()
    {
        _inventoryIUObject.SetActive(false);
        isActive = false;
        ItemIcon.DestroyAll();
    }
}
