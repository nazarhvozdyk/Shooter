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
        _playerInventory.onItemRemoved += OnItemRemoved;
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

    public void TakeItem(Item item)
    {
        if (item.itemType != ItemType.Weapon)
            return;

        Destroy(_currentItemObject);
        _currentItem = item;

        GameObject newItem = Instantiate(item.itemPrefab, _gunParent);
        _currentItemObject = newItem;
        _currentItemObject.transform.localRotation = Quaternion.identity;
        _currentItemObject.transform.localPosition = Vector3.zero;
    }
}
