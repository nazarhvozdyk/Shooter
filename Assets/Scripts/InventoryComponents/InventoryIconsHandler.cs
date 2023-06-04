using UnityEngine;

public class InventoryIconsHandler : MonoBehaviour
{
    public static InventoryIconsHandler Instance
    {
        get => _instance;
    }
    private static InventoryIconsHandler _instance;

    private ItemIcon _currentIcon;
    private RectTransform _currentIconContentTransform;
    private bool _isMouseInsideInventoryInterface;

    [SerializeField]
    private Canvas _inventoryCanvas;

    [SerializeField]
    private Inventory _inventory;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        enabled = false;
    }

    public void OnIconMouseDown(ItemIcon icon)
    {
        _currentIconContentTransform = icon.GetContentTransform();
        _currentIconContentTransform.SetParent(_inventoryCanvas.transform, true);
        _currentIconContentTransform.position = Input.mousePosition;
        _currentIcon = icon;
        enabled = true;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            _currentIconContentTransform.position = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            if (_isMouseInsideInventoryInterface)
            {
                _currentIcon.SetContent(_currentIconContentTransform);
            }
            else
            {
                InventoryItem item = _currentIcon.GetItem();
                _inventory.RemoveItem(item.item, item.amount);
                Destroy(_currentIconContentTransform.gameObject);
            }

            enabled = false;
        }
    }

    public void OnMouseLeftInventoryInterface()
    {
        _isMouseInsideInventoryInterface = false;
    }

    public void OnMouseInsideInventoryInterface()
    {
        _isMouseInsideInventoryInterface = true;
    }
}
