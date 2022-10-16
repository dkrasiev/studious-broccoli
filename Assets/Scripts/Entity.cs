using UnityEngine;

public class Entity : MonoBehaviour, IDamageable, IKillable
{
    [SerializeField] protected float _maxHealth;
    protected float _health;

    public float Health => _health;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public virtual void GetDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}