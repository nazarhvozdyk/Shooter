using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook _cinemachine;

    private void Start()
    {
        InventoryDisplayer.Instance.onStateChanged += OnInventoryStateChanged;
    }

    private void OnInventoryStateChanged(bool value)
    {
        _cinemachine.enabled = !value;
    }
}
