using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Animator _animator;

    public override void Die()
    {
        _animator.SetTrigger("die");
        GetComponent<PlayerMovement>().SetSpeed(0f);
    }
}
