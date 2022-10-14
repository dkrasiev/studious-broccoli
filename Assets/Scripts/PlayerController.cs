using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _health;

    public void Start()
    {
        _health = _maxHealth;
    }

    public void Update() {
        if (_health <= 0f) {
            Die();
        }
    }

    public void GetDamage(float damage) {
        _health -= damage;
    }

    public void AddHealh(float heal) {
        _health += heal;
    }

    public void Die() {
        Destroy(gameObject);
    }
}
