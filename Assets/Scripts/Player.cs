using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GetDamage(15);
        }
    }

    public override void Die()
    {
        _animator.SetTrigger("die");
        GetComponent<PlayerMovement>().SetSpeed(0f);
    }
}
