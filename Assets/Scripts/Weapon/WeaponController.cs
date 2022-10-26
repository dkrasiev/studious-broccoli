using UnityEngine;

class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private FindWeapon _weaponFinder;
    [SerializeField] private float _dropWeaponForce;
    private Weapon _weapon;
    private InputManager _input;

    public void PickUp(Weapon weapon)
    {
        if (_weapon)
            DropWeapon();

        weapon.equipped = true;

        _weapon = weapon;
        Transform weaponTransform = _weapon.transform;

        weaponTransform.SetParent(_weaponContainer);
        weaponTransform.localPosition = Vector3.zero;
        weaponTransform.rotation = transform.rotation;

        _weapon.GetComponent<Rigidbody>().isKinematic = true;
        _weapon.GetComponent<Collider>().enabled = false;
    }

    public void DropWeapon()
    {
        if (_weapon == null) return;

        Transform weaponTransform = _weapon.transform;
        weaponTransform.SetParent(null);

        Rigidbody weaponRigidbody = _weapon.GetComponent<Rigidbody>();
        weaponRigidbody.isKinematic = false;
        weaponRigidbody.AddForce(weaponTransform.forward * _dropWeaponForce, ForceMode.Impulse);

        _weapon.equipped = false;
        _weapon.GetComponent<Collider>().enabled = true;
        _weapon = null;
    }

    public void Shoot()
    {
        if (_weapon)
            _weapon.Shoot();
    }

    private void Start()
    {
        _input = InputManager.Instance;

        _input.ShootKeyPressed.AddListener(Shoot);
        _input.DropWeaponKeyPressed.AddListener(DropWeapon);
        _input.PickupWeaponKeyPressed.AddListener(TryPickUp);
    }

    private void OnDestroy()
    {
        _input.ShootKeyPressed.RemoveListener(Shoot);
        _input.DropWeaponKeyPressed.RemoveListener(DropWeapon);
        _input.PickupWeaponKeyPressed.RemoveListener(TryPickUp);
    }

    private void TryPickUp()
    {
        Weapon weapon = _weaponFinder.ClosestWeapon;

        if (weapon)
            PickUp(weapon);
    }
}
