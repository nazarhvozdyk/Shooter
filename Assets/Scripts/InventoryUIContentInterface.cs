using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUIContentInterface : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        InventoryIconsHandler.Instance.OnMouseInsideInventoryInterface();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InventoryIconsHandler.Instance.OnMouseLeftInventoryInterface();
    }
}
