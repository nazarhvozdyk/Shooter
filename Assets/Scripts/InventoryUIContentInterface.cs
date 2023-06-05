using UnityEngine;

public class InventoryUIContentInterface : MonoBehaviour
{
    private bool _isOverUI;

    [SerializeField]
    private RectTransform _UITransform;

    private void Update()
    {
        bool isOverIU = RectTransformUtility.RectangleContainsScreenPoint(
            _UITransform,
            Input.mousePosition
        );

        if (isOverIU)
        {
            if (_isOverUI == false)
            {
                InventoryIconsHandler.Instance.OnMouseInsideInventoryInterface();
                _isOverUI = true;
            }
        }
        else
        {
            if (_isOverUI)
            {
                InventoryIconsHandler.Instance.OnMouseLeftInventoryInterface();
                _isOverUI = false;
            }
        }
    }
}
