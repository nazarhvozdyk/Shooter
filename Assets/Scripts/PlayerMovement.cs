using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _walkSpeed = 3;

    [SerializeField]
    private float _runSpeed = 7;

    [SerializeField]
    private float _turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;
    private bool _isRunning;
    private readonly int _IdleKey = Animator.StringToHash("Idle");
    private readonly int _WalkKey = Animator.StringToHash("Walk");
    private readonly int _RunKey = Animator.StringToHash("Run");

    private void Start()
    {
        InventoryDisplayer.Instance.onStateChanged += OnInventoryStateChanged;
    }

    private void OnInventoryStateChanged(bool value)
    {
        enabled = !value;
    }

    public void SetInput(float horizontal, float vertical)
    {
        if (enabled == false)
            return;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude < 0.1f)
        {
            _rigidbody.velocity = Vector3.zero;
            _animator.SetTrigger(_IdleKey);
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
        float speed;

        if (_isRunning)
        {
            speed = _runSpeed;
            _animator.SetTrigger(_RunKey);
        }
        else
        {
            speed = _walkSpeed;
            _animator.SetTrigger(_WalkKey);
        }

        _rigidbody.velocity = moveDir * speed;
    }

    public void StartRunning()
    {
        _isRunning = true;
    }

    public void StopRunning()
    {
        _isRunning = false;
    }
}
