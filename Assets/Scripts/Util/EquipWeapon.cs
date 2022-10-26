using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class EquipWeapon : MonoBehaviour
{
    public GameObject weapon;

    private void Start()
    {
        GameObject newObject = Instantiate(this.weapon);
        Weapon weapon = newObject.GetComponent<Weapon>();

        if (weapon != null)
        {
            WeaponController weaponController = GetComponent<WeaponController>();
            weaponController.PickUp(weapon);
        }
    }
}
