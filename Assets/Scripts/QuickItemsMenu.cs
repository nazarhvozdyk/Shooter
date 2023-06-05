using UnityEngine;

public class QuickItemsMenu : MonoBehaviour
{
    [SerializeField]
    private Transform _itemIconsParent;

    [SerializeField]
    private ItemIcon _itemIconPrefab;

    [SerializeField]
    private InventoryItemsHandler _inventoryItemsHandler;
    private ItemIcon[] _icons;

    private void Update()
    {
        Item item = null;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            item = GetItemByIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            item = GetItemByIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            item = GetItemByIndex(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            item = GetItemByIndex(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            item = GetItemByIndex(4);

        if (item == null)
            return;
        else
            _inventoryItemsHandler.TakeItem(item);
    }

    private Item GetItemByIndex(int index)
    {
        if (index >= _icons.Length)
            return null;

        return _icons[index].GetInventoryItem().item;
    }
}
