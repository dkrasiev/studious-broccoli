using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private Transform _gunpoint;
    [SerializeField] private GameObject _projectile;

    public bool equipped;

    private Transform _transform;

    public void Awake()
    {
        _transform = transform;
    }

    public virtual void Shoot()
    {
        // spawn and init projectile
        Projectile projectile = Instantiate(_projectile).GetComponent<Projectile>();
        projectile.Init(_weaponData);

        // set position and rotation
        projectile.transform.position = _gunpoint.position;
        projectile.transform.rotation = _transform.rotation;
    }
}