using UnityEngine;

public abstract class Firearm : Weapon
{
    [SerializeField]
    protected int _magazineCapacity = 30;

    [SerializeField]
    protected int _startAdditionalAmmo = 90;

    [SerializeField]
    protected int _shootsInMinute = 600;

    protected int _ammoInMagazine;
    protected int _additionalAmmo;

    public int AmmoInMagazine
    {
        get => _additionalAmmo;
    }
    public int AdditionalAmmo
    {
        get => _additionalAmmo;
    }
    protected float _timer;

    // time between shoots
    protected float _shootRate;

    private void Start()
    {
        _ammoInMagazine = _magazineCapacity;
        _additionalAmmo = _startAdditionalAmmo;
    }

    private void OnEnable()
    {
        _shootRate = 60f / _shootsInMinute;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
    }

    public override void MakeDamage()
    {
        Shoot();
    }

    public virtual void Shoot() { }

    public virtual void Reload() { }
}
