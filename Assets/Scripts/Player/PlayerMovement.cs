using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _speed = 7;

    [SerializeField]
    private float _jumpHeight = 1;
    private float _jumpVelocity;

    private void OnValidate()
    {
        _jumpVelocity = Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y);
    }

    public void Jump()
    {
        // if is grounded
        Debug.LogWarning("Didn't check is player on ground");
        Vector3 velocity = _rigidbody.velocity;
        velocity.y = 0;
        _rigidbody.AddForce(0, _jumpVelocity, 0, ForceMode.VelocityChange);
    }

    public void MoveByDirection(Vector2 direction)
    {
        Vector3 newVelocity = transform.right * direction.x + transform.forward * direction.y;
        newVelocity *= _speed;
        newVelocity.y = _rigidbody.velocity.y;

        _rigidbody.velocity = newVelocity;
    }
}
