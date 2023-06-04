using UnityEngine;

public class InventoryItemsHandler : MonoBehaviour
{
    [SerializeField]
    private Inventory _playerInventory;

    [SerializeField]
    private Transform _gunParent;

    private Item _currentItem;
    private GameObject _currentItemObject;

    private void Awake()
    {
        _playerInventory.onItemAdded += OnItemAdded;
        _playerInventory.onItemRemoved += OnItemRemoved;
    }

    private void OnItemAdded(InventoryItem item)
    {
        if (item.item.itemType == ItemType.Weapon)
            TakeItem(item.item);
    }

    private void OnItemRemoved(InventoryItem item)
    {
        if (item.item == _currentItem)
            Destroy(_currentItemObject);

        GameObject droppedItem = Instantiate(item.item.droppedItemPrefab);
        Transform inventoryTransform = _playerInventory.transform;
        Vector3 dropPosition =
            inventoryTransform.position + Vector3.up + inventoryTransform.forward;
        droppedItem.transform.position = dropPosition;
    }

    private void TakeItem(Item item)
    {
        if (item == null)
            return;

        Destroy(_currentItemObject);
        _currentItem = item;

        GameObject newItem = Instantiate(item.itemPrefab, _gunParent);
        _currentItemObject = newItem;
        _currentItemObject.transform.localRotation = Quaternion.identity;
        _currentItemObject.transform.localPosition = Vector3.zero;
    }
}
