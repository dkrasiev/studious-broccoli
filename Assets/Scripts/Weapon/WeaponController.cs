using UnityEngine;

class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform weaponContainer;
    [SerializeField] private float dropWeaponForce;
    private Weapon _weapon;

    public void EquipWeapon(Weapon weapon)
    {
        if (_weapon)
            DropWeapon();

        _weapon = weapon;
        Transform weaponTransform = _weapon.transform;

        weaponTransform.SetParent(weaponContainer);
        weaponTransform.localPosition = Vector3.zero;
        weaponTransform.rotation = transform.rotation;

        _weapon.GetComponent<Rigidbody>().isKinematic = true;
        _weapon.GetComponent<Collider>().enabled = false;
    }

    public void DropWeapon()
    {
        if (_weapon == null) return;

        Rigidbody weaponRigidbody = _weapon.GetComponent<Rigidbody>();
        _weapon.transform.SetParent(null);

        weaponRigidbody.isKinematic = false;
        _weapon.GetComponent<Collider>().enabled = true;
        weaponRigidbody.AddForce(_weapon.transform.forward * dropWeaponForce, ForceMode.Impulse);
        _weapon = null;
    }

    public void Shoot()
    {
        if (_weapon == null) return;

        _weapon.Shoot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (Input.GetKeyDown(KeyCode.G))
            DropWeapon();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Weapon weapon = collision.gameObject.GetComponent<Weapon>();

        if (weapon)
            EquipWeapon(weapon);
    }
}
