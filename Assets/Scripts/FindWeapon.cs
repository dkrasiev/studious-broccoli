using System.Collections.Generic;
using UnityEngine;

public class FindWeapon : MonoBehaviour
{
    private Transform _transform;
    private List<Weapon> _weaponList = new List<Weapon>();
    private Weapon _closestWeapon;

    public Weapon ClosestWeapon
    {
        get
        {
            UpdateClosestWeapon();
            return _closestWeapon;
        }
    }

    private void Start()
    {
        _transform = transform;
    }

    private void UpdateClosestWeapon()
    {
        Weapon closestWeapon = null;
        float minDistance = float.PositiveInfinity;

        foreach (Weapon weapon in _weaponList)
        {
            if (weapon.equipped) continue;

            float distance = Vector3.Distance(_transform.position, weapon.transform.position);
            minDistance = Mathf.Min(minDistance, distance);

            if (distance == minDistance)
                closestWeapon = weapon;
        }

        if (_closestWeapon != closestWeapon)
            _closestWeapon = closestWeapon;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Weapon weapon = collider.GetComponent<Weapon>();

        if (weapon == null || _weaponList.Contains(weapon)) return;
        _weaponList.Add(weapon);
    }

    private void OnTriggerExit(Collider collider)
    {
        Weapon weapon = collider.GetComponent<Weapon>();

        if (weapon == null) return;
        _weaponList.Remove(weapon);
    }
}
