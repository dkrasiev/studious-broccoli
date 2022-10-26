using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _animator;
    public Quaternion TargetRotation = Quaternion.identity;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Transform _cameraTransform;
    private InputManager _input;
    private float _scaledSpeed => _speed * Time.deltaTime;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
        _input = InputManager.Instance;
    }

    private void Update()
    {
        Vector3 forward = _transform.position - _cameraTransform.position;
        forward.y = 0;
        forward.Normalize();

        Vector2 right2d = Vector2.Perpendicular(new Vector2(forward.x, forward.z)) * -1;
        Vector3 right = new Vector3(right2d.x, 0, right2d.y);

        Vector3 movementDirection = (_input.VerticalAxis * forward + _input.HorizonalAxis * right).normalized * _scaledSpeed;

        if (movementDirection.magnitude > 0f)
        {
            _transform.position += movementDirection;
            TargetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            _animator.SetFloat("speed", movementDirection.magnitude / Time.deltaTime);
        }
        else
        {
            _animator.SetFloat("speed", 0f);
        }

        _transform.rotation = Quaternion.Lerp(_transform.rotation, TargetRotation, _rotationSpeed * Time.deltaTime);
    }
}
