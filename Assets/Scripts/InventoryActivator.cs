using UnityEngine;

public class InventoryActivator : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryDisplayer.Instance.isActive)
                InventoryDisplayer.Instance.Hide();
            else
                InventoryDisplayer.Instance.Show();
        }
    }
}
