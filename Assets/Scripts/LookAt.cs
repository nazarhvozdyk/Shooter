using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    private void LateUpdate()
    {
        transform.LookAt(_target);
    }
}
