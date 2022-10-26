using UnityEngine;
using UnityEngine.InputSystem;

class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform _weaponContainer;
    [SerializeField] private FindWeapon _weaponFinder;
    [SerializeField] private float _dropWeaponForce;
    private Weapon _weapon;
    private PlayerInputActions _input;

    private void OnEnable()
    {
        if (_input == null)
            _input = InputManager.playerInputActions;

        _input.Player.Drop.performed += OnDrop;
        _input.Player.Interact.performed += OnPickUp;
        _input.Player.Shoot.performed += OnShoot;
    }

    private void OnDisable()
    {
        _input.Player.Drop.performed -= OnDrop;
        _input.Player.Interact.performed -= OnPickUp;
        _input.Player.Shoot.performed -= OnShoot;
    }

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

    private void OnDrop(InputAction.CallbackContext context)
    {
        DropWeapon();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (_weapon)
            _weapon.Shoot();
    }

    private void OnPickUp(InputAction.CallbackContext context)
    {
        Weapon weapon = _weaponFinder.ClosestWeapon;

        if (weapon)
            PickUp(weapon);
    }
}
