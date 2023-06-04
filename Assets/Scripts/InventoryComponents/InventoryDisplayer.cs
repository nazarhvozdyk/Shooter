using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{
    public delegate void OnStateChanged(bool isActive);
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
    public OnStateChanged onStateChanged;

    private void Awake()
    {
        _instance = this;
    }

    public void Show()
    {
        InventoryItem[] items = _inventory.GetItems();

        for (int i = 0; i < items.Length; i++)
        {
            ItemIcon itemIcon = Instantiate(_itemIconPrefab, _iconsParent);
            itemIcon.SetUp(items[i].item, items[i].amount, i);
        }

        _inventoryIUObject.SetActive(true);
        isActive = true;
        onStateChanged?.Invoke(true);
    }

    public void Hide()
    {
        _inventoryIUObject.SetActive(false);
        isActive = false;
        onStateChanged?.Invoke(false);
        ItemIcon.DestroyAll();
    }
}
