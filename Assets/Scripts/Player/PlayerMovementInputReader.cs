using UnityEngine;

public class PlayerMovementInputReader : MonoBehaviour
{
    private static readonly string _horizontalKey = "Horizontal";
    private static readonly string _verticalKey = "Vertical";

    [SerializeField]
    private PlayerMovement _playerMovement;

    private void Update()
    {
        float x_move = Input.GetAxis(_horizontalKey);
        float y_move = Input.GetAxis(_verticalKey);

        Vector2 moveDirection = new Vector2(x_move, y_move);

        _playerMovement.MoveByDirection(moveDirection);

        if (Input.GetKeyDown(KeyCode.Space))
            _playerMovement.Jump();
    }
}
