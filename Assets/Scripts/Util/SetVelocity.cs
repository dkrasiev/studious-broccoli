using UnityEngine;

public class SetVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;

    private Rigidbody _rb;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        _rb.velocity = Physics.gravity + _moveDirection;
    }
}
