using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        if (direction.magnitude < 0.1f)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        direction.Normalize();

        float targetAngle =
            Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;

        float angle = Mathf.SmoothDampAngle(
            transform.eulerAngles.y,
            targetAngle,
            ref _turnSmoothVelocity,
            _turnSmoothTime
        );

        transform.rotation = Quaternion.Euler(0, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        moveDir.Normalize();
        _rigidbody.velocity = moveDir * _speed;
    }
}
