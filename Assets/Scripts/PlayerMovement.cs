using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Transform _cameraTransform;
    private float _scaledSpeed => _speed * Time.deltaTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTransform = Camera.main.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 forward = _transform.position - _cameraTransform.position;
        forward.y = 0;
        forward.Normalize();

        Vector2 right2d = Vector2.Perpendicular(new Vector2(forward.x, forward.z)) * -1;
        Vector3 right = new Vector3(right2d.x, 0, right2d.y);

        float horizonal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizonal != 0 || vertical != 0) {
            _transform.Translate(forward * vertical * _scaledSpeed);
            _transform.Translate(right * horizonal * _scaledSpeed);
        }
    }
}
