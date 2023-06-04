using UnityEngine;

public class InventoryItemsHandler : MonoBehaviour
{
    [SerializeField]
    private Inventory _playerInventory;

    [SerializeField]
    private Transform _gunParent;

    private GameObject _currentItem;

    private void Awake()
    {
        _playerInventory.onItemAdded += OnItemAdded;
    }

    private void OnItemAdded(InventoryItem item)
    {
        if (item.item.itemType == ItemType.Weapon)
            TakeItem(item.item);
    }

    private void Update() { }

    private void TakeItem(Item item)
    {
        if (item == null)
            return;

        Destroy(_currentItem);

        _currentItem = Instantiate(item.itemPrefab, _gunParent);

        _currentItem.transform.localRotation = Quaternion.identity;
        _currentItem.transform.localPosition = Vector3.zero;
    }
}
