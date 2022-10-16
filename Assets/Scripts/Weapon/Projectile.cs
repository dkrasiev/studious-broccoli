using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float Damage;
    public float Speed;
    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(_transform.forward * Speed, ForceMode.Impulse);
    }

    public void Init(WeaponData weaponData)
    {
        Damage = weaponData.Damage;
        Speed = weaponData.ProjectileSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
            damageable.GetDamage(Damage);

        Destroy(gameObject);
    }
}