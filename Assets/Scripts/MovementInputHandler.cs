using UnityEngine;

public class MovementInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;

    private void Start()
    {
        InventoryDisplayer.Instance.onStateChanged += OnInventoryStateChanged;
    }

    private void OnInventoryStateChanged(bool value)
    {
        enabled = !value;

        _playerMovement.StopRunning();
        _playerMovement.SetInput(0, 0);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _playerMovement.StartRunning();
        else
            _playerMovement.StopRunning();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _playerMovement.SetInput(horizontal, vertical);
    }
}
