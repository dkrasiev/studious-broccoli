using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] new private string name = "New Weapon";
    [SerializeField] private float damage;
    [SerializeField] private float projectileSpeed;

    public string Name => name;
    public float Damage => damage;
    public float ProjectileSpeed => projectileSpeed;
}