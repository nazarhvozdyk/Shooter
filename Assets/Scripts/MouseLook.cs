using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private static readonly string mouseXAxisKey = "Mouse X";
    private static readonly string mouseYAxisKey = "Mouse Y";

    [SerializeField]
    private float _sensetivity = 3;

    [SerializeField]
    private Transform _playerBodyTransform;
    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis(mouseXAxisKey) * _sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYAxisKey) * _sensetivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _playerBodyTransform.Rotate(Vector3.up * mouseX);
    }
}
