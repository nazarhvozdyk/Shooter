using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    [SerializeField]
    private float _takeDistance = 5;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Transform _hintTransform;

    [SerializeField]
    private Inventory _playerInventory;

    private void Update()
    {
        float minDistance = Mathf.Infinity;
        ItemController itemController = null;

        foreach (var item in ItemController.itemControllers)
        {
            Vector3 itemPosition = item.transform.position;
            float distance = Vector3.Distance(itemPosition, _player.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                itemController = item;
            }
        }

        if (minDistance < _takeDistance)
        {
            _hintTransform.gameObject.SetActive(true);
            _hintTransform.position = itemController.transform.position + Vector3.up * 0.5f;
        }
        else
        {
            _hintTransform.gameObject.SetActive(false);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerInventory.AddItem(itemController.Item, itemController.Amount);
            DestroyImmediate(itemController.gameObject);
        }
    }
}
