using UnityEngine;

public class MovementInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;

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
