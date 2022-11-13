using UnityEngine;

public class AK47 : Firearm
{
    private static readonly int _shootKey = Animator.StringToHash("IsShooting");
    private static readonly int _reloadKey = Animator.StringToHash("Reload");

    [SerializeField]
    private Animator _animator;
    private bool _isReloading;
    protected bool _cantShoot = true;

    public override void Shoot()
    {
        if (_cantShoot)
            return;

        if (_timer < _shootRate)
            return;

        _timer = 0;
        _ammoInMagazine--;
        _animator.SetTrigger(_shootKey);
    }

    public override void Reload()
    {
        if (_isReloading)
            return;
        _isReloading = true;
        _animator.SetTrigger(_reloadKey);
    }

    public void OnReloaded()
    {
        _isReloading = false;
    }

    // called when take weapon animation is end
    public void OnReadyToUse()
    {
        _cantShoot = false;
    }
}
