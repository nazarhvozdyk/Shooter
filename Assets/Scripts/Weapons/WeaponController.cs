using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Transform _weaponPosiitonTransform;

    [SerializeField]
    private Firearm _startWeapon;
    private Firearm _currentWeapon;

    private void Start()
    {
        _currentWeapon = Instantiate(_startWeapon, _weaponPosiitonTransform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            _currentWeapon.Reload();

        if (Input.GetMouseButton(0)) 
            _currentWeapon.Shoot();
    }
}
